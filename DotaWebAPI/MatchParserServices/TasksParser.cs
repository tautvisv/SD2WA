using System.Collections.Generic;
using System.Linq;
using Data;
using DatabaseEntities.Entities;
using DataRepositoriesInterfaces;

namespace MatchParserServices
{
    internal static class TaskParserHelper
    {
        public static ICollection<Task> CreateTaks(ICollection<MinimizedMatchDto> matches)
        {
            var i = 0;
            Task[] tasks = new Task[matches.Count];
            foreach (var match in matches)
            {
                tasks[i++] = new Task
                {
                    RequestID = match.MatchID,
                    Finished = false,
                    Priority = TaskPriorityEnum.Normal,
                    TaskType = TaskTypeEnum.FindMatch
                };
            }
            return tasks;
        }

        public static Task CreateTak(Task task, int lastMatchID, int? matchCount)
        {
            var newTask = (Task)task.Clone();
            newTask.Priority = TaskPriorityEnum.Superior;
            newTask.RequestFrom = lastMatchID;
            newTask.Finished = false;
            if (matchCount != null)
            {
                newTask.Count = matchCount;
            }
            return newTask;
        }
    }
    public class TasksParser : ITasksParser
    {
        protected readonly ITaskParserRepository TasksRepostory;
        protected readonly ISteamRepository SteamRepostory;
        protected readonly IMatchRepository MatchRepostory;
        protected readonly IUnitOfWork UnitOfWork;

        public TasksParser(ITaskParserRepository tasksRepostory, ISteamRepository steamRepostory, IMatchRepository matchRepostory, IUnitOfWork unitOfWork)
        {
            TasksRepostory = tasksRepostory;
            SteamRepostory = steamRepostory;
            MatchRepostory = matchRepostory;
            UnitOfWork = unitOfWork;
        }

        public void ParserTask()
        {
            while (true)
            {
                var task = TasksRepostory.GetNewTask();
                if (task == null)
                {
                    return;
                }
                switch (task.TaskType)
                {
                    case TaskTypeEnum.FindMatch:
                        var match = MatchRepostory.GetByWebApiId(task.RequestID);
                        if (match == null)
                        {
                            var onlineMatch = SteamRepostory.GetMatchById(task.RequestID);
                            if (onlineMatch != null)
                            {
                                MatchRepostory.AddWithChilds(onlineMatch);
                            }
                            TasksRepostory.CompleteTask(task);
                            UnitOfWork.Commit();
                            return;
                        }
                        TasksRepostory.CompleteTask(task);
                        UnitOfWork.Commit();
                        break;
                    case TaskTypeEnum.FindMatchList:
                        var data = SteamRepostory.GetMatches(playerID: task.RequestID, matchID: task.RequestFrom, heroID: task.HeroID, matchCount: task.Count);
                        var matchRemaining = task.Count - (data.Result.TotalResults - data.Result.ResultsRemaining);
                        if (matchRemaining > 0)
                        {
                            if (data.Result.Matches != null && data.Result.Matches.Count > 0)
                            {
                                var newTask = TaskParserHelper.CreateTak(task, data.Result.Matches.Last().MatchID - 1, matchRemaining < 100 ? matchRemaining : null);
                                TasksRepostory.AddTask(newTask);
                            }
                        }
                        if (data.Result.Matches != null && data.Result.Matches.Count > 0)
                        {
                            var tasks = TaskParserHelper.CreateTaks(data.Result.Matches);
                            TasksRepostory.AddTasks(tasks);
                        }
                            TasksRepostory.CompleteTask(task);
                        UnitOfWork.Commit();
                        return;
                }
            }
        }
    }
}
