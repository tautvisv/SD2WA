using System;
using CustomCalculationServiceConnectionLib;
using DatabaseEntities.Entities;

namespace DataServices.Services
{
    public class BridgeCalculationService : IBridgeCalculationService
    {
        public Match CalculateMatchDetails(Match match)
        {
            var request = new CustomCalculationServiceRequest
            {
                MethodName = "MyMethod",
                MethodController = "Calculation",
                Body = match,
                URLParameters = new[] { "2" },
                MethodType = CustomCalculationServiceRequest.RequestTypeEnum.POST
            };
            CustomCalculationServiceConnection a = new CustomCalculationServiceConnection();
            object response = a.Request(request);
            return null;
        }
    }
}
