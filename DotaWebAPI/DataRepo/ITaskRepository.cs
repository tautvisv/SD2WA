using DatabaseEntities.Entities;

namespace DataRepositoriesInterfaces
{
    public interface ITaskRepository:IGenericRepository<Task>
    {
        int TaskCount(TaskPriorityEnum priority);
        bool DoesExist(int requestID, TaskTypeEnum type);
    }
}
