using System;
using System.Collections.Generic;
using CustomCalculationServiceConnectionLib;
using Data;
using DatabaseEntities.Entities;

namespace DataServices.Services
{
    public class DotaCalculationBridge:IBridgeDotaCalculation
    {
        private const string Key = "raktas";
        private readonly IServiceConnection _connectioToApi;
        public DotaCalculationBridge(IServiceConnection connectioToApi)
        {
            _connectioToApi = connectioToApi;
        }

        public Match GetMatchStatistics(Match match)
        {
            var request = new CustomCalculationServiceRequest
            {
                MethodType = CustomCalculationServiceRequest.RequestTypeEnum.POST,
                MethodController = "Calculation",
                Key = Key,
                MethodName = "Statistics",
                Body = match,
            };
            return _connectioToApi.Request<Match>(request);
        }

        public WinrateItem GetWinrate(IEnumerable<Match> matches)
        {
            var request = new CustomCalculationServiceRequest
            {
                MethodType = CustomCalculationServiceRequest.RequestTypeEnum.POST,
                MethodController = "Calculation",
                Key = Key,
                MethodName = "Winrate",
                Body = matches,
            };
            return _connectioToApi.Request<WinrateItem>(request);
        }

        public PlayerRating GetPlayerRating(IEnumerable<Match> matches)
        {
            var request = new CustomCalculationServiceRequest
            {
                MethodType = CustomCalculationServiceRequest.RequestTypeEnum.POST,
                MethodController = "Calculation",
                Key = Key,
                MethodName = "Rating",
                Body = matches,
            };
            return _connectioToApi.Request<PlayerRating>(request);
        }

        public Information GetBestAgainst(IEnumerable<Match> matches)
        {
            var request = new CustomCalculationServiceRequest
            {
                MethodType = CustomCalculationServiceRequest.RequestTypeEnum.POST,
                MethodController = "Calculation",
                Key = Key,
                MethodName = "Best",
                Body = matches,
            };
            return _connectioToApi.Request<Information>(request);
        }

        public Information GetWorstAgainst(IEnumerable<Match> matches)
        {
            var request = new CustomCalculationServiceRequest
            {
                MethodType = CustomCalculationServiceRequest.RequestTypeEnum.POST,
                MethodController = "Calculation",
                Key = Key,
                MethodName = "Worst",
                Body = matches,
            };
            return _connectioToApi.Request<Information>(request);
        }
    }
}
