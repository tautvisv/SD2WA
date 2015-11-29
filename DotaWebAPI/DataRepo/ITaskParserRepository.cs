using System.Collections.Generic;
using DatabaseEntities.Entities;

namespace DataRepositoriesInterfaces
{

    public interface ITaskParserRepository
    {
        Task CompleteTask(Task task);
        void AddTask(Task task);
        void AddTasks(IEnumerable<Task> tasks);
        Task GetNewTask();
    }
}
