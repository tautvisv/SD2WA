using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DatabaseEntities.Entities;
using DataRepositoriesInterfaces;

namespace DataRepositories.Repositories
{

    public class TaskParserRepository : ITaskParserRepository
    {
        private readonly Dota2DbContext _dbContext;
        private readonly DbSet<Task> _dbSet;
        public TaskParserRepository(Dota2DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<Task>();
        }

        public Task CompleteTask(Task task)
        {
            task.Finished = true;
            
            _dbSet.Attach(task);
            _dbContext.Entry(task).State = EntityState.Modified;
            return task;
        }

        public void AddTask(Task task)
        {
            AddTasks(new []{ task });
        }

        public void AddTasks(IEnumerable<Task> tasks)
        {
            _dbSet.AddRange(tasks);
        }

        public Task GetNewTask()
        {
            return _dbSet.Where(x => !x.Finished).OrderByDescending(x => x.Priority).ThenBy(x => x.ID).FirstOrDefault();
        }
    }
}
