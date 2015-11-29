using System;
using CustomCalculationServiceConnectionLib;
using DatabaseEntities.Entities;
using DataServices;
using DataServices.Services;
using Newtonsoft.Json;

namespace Test
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
            var mt = JsonConvert.SerializeObject(new Match(){ID = 5});
            var re = JsonConvert.DeserializeObject(mt);
            var re2 = JsonConvert.DeserializeObject<Match>(mt);
            var c = connection.Request(request);

            Console.WriteLine("GREAT success!");
            Console.ReadKey();
        }

        private static void BridgeTest()
        {
            //DotaCalculationBridge bridge = new DotaCalculationBridge();
            //var result = bridge.GetMatchStatistics(new Match { ID = 21, Duration = 99999 });
            //Console.WriteLine("id:{0}, duration: {1}", result.ID, result.Duration);
            //DotaCalculationBridge a = new DotaCalculationBridge();
        }
        private static void RequestTest()
        {
            CustomCalculationServiceRequest test = new CustomCalculationServiceRequest
            {
                MethodController = "Calculation",
                Key = "raktelis",
                MethodName = "CalculateStatistics"
            };
            test.AddParamater("vardas", "vardenis");
            test.AddParamater("amzius", "99");
            test.AddParamater("pavarde", "pavardenis");
            Console.WriteLine("url: {0}", test.ToRequestString());
            test.ToRequestString();
        }
    }
    
}
