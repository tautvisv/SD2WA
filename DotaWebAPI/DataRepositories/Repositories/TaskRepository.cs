using System.Linq;
using DatabaseEntities.Entities;
using DataRepo;
using DataRepositoriesInterfaces;

namespace DataRepositories.Repositories
{
    public class TaskRepository : GenericRepositoryBase<Task>, ITaskRepository
    {
        public TaskRepository(Dota2DbContext dbContext) : base(dbContext)
        {
        }

        public int TaskCount(TaskPriorityEnum priority)
        {
            return DBSet.Count(x => x.Priority >= priority && !x.Finished);//
        }

        public bool DoesExist(int requestID, TaskTypeEnum type)
        {
            return DBSet.Any(x => x.RequestID == requestID && x.Finished && x.TaskType == type);
        }
    }
}
