using System.ServiceProcess;
using System.Threading;
using DataAPIRepositories.Repositories;
using DataRepositories;
using DataRepositories.Repositories;
using DataRepositoriesInterfaces;
using MatchParserServices;

namespace MatcheParserService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //static void Main()
        //{
        //    ServiceBase[] ServicesToRun;
        //    ServicesToRun = new ServiceBase[] 
        //    { 
        //        new MatchParserService() 
        //    };
        //    ServiceBase.Run(ServicesToRun);
        //}
        static void Main(string[] args)
        {

            Dota2DbContext dbContext = new Dota2DbContext();
            IUnitOfWork unitOfWork = new UnitOfWork(dbContext);
            ITaskParserRepository taskRepository = new TaskParserRepository(dbContext);
            ISteamRepository onlineMatchRepository = new SteamRepository();
            IMatchRepository matchRepository = new MatchRepository(dbContext);
            ITasksParser taskParser = new TasksParser(taskRepository, onlineMatchRepository, matchRepository, unitOfWork);
#if DEBUG
            var service = new MatchParserService(taskParser);
            service.OnDebug();
            Thread.Sleep(Timeout.Infinite);

#else
            ServiceBase[] ServicesToRun; 
            ServicesToRun = new ServiceBase[]
            {
                new MatchParserService(taskParser),
            }; 
            ServiceBase.Run(ServicesToRun);
#endif
        }
    }
}
