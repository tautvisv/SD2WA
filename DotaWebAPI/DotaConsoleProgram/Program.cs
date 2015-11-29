using System;
using CustomCalculationServiceConnectionLib;
using DatabaseEntities.Entities;
using Newtonsoft.Json;

namespace DotaConsoleProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            var match = new Match
            {
                ID = 69
            };
            //BridgeTest();

            var request = new CustomCalculationServiceRequest
            {
                MethodType = CustomCalculationServiceRequest.RequestTypeEnum.POST,
                MethodController = "Calculation",
                Key = "raktelis",
                MethodName = "CalculateStatistics",
                Body = new Match() { ID = 69, Duration = 123456789 },
            };


            var connection = new CustomCalculationServiceConnection();
            var mt = JsonConvert.SerializeObject(new Match() { ID = 5 });
            var re = JsonConvert.DeserializeObject(mt);
            var re2 = JsonConvert.DeserializeObject<Match>(mt);
            var c = connection.Request(request);

            Console.WriteLine("GREAT success!");
            Console.ReadKey();
        }
    }
}
