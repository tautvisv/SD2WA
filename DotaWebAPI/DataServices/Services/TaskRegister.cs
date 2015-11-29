using DatabaseEntities.Entities;
using DataRepositoriesInterfaces;

namespace DataServices.Services
{
    public class TaskRegister:IRegister
    {
        private readonly ITaskRepository _taskRepository;
        public TaskRegister(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public int RegisterMatchListCommand(int playerID, int? heroID, int? enemyHeroID, int? matchCount)
        {
            //if (_taskRepository.DoesExist(playerID, heroID, enemyHeroID, matchCount, TaskTypeEnum.FindMatch)) return -1;
            var task = new Task
            {
                RequestID = playerID,
                HeroID = heroID,
                EnemyHeroID = enemyHeroID,
                Count = matchCount,
                TaskType = TaskTypeEnum.FindMatchList,
                Priority = TaskPriorityEnum.VeryHigh
            };
            _taskRepository.Add(task);
            return _taskRepository.TaskCount(TaskPriorityEnum.Normal) + matchCount ?? 1;
        }

        public int RegisterMatchCommand(int matchID)
        {
            if (_taskRepository.DoesExist(matchID, TaskTypeEnum.FindMatch)) return -1;
            var task = new Task
            {
                RequestID = matchID,
                TaskType = TaskTypeEnum.FindMatch,
                Priority = TaskPriorityEnum.High
            };
            _taskRepository.Add(task);
            return _taskRepository.TaskCount(TaskPriorityEnum.High)+1;
        }

    }
}
