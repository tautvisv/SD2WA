using System.Web.Http;
using Data;
using DataServices;

namespace Dota2WebAPI.Controllers
{
    [RoutePrefix(Globals.ApiPrefix + "/dota")]
    public class DotaController : BaseController.BaseController
    {
        //Steam api key: 893F592E19918CA8A9CB5A847C94E2ED
        
        private readonly IStatisticsService _statisticsService;
        public DotaController(IStatisticsService  statisticsService)
        {
            _statisticsService = statisticsService;
        }

        [Route("PlayerEfficiencyInMatch/Match/{matcId}")]
        public IHttpActionResult GetPlayerEfficiencyInMatch(int matcId)
        {
            var match = _statisticsService.GetMatchStatistics(matcId);
            return CreateResponse(match);
        }

        [Route("WinrateAgaintOtherHero/Player/{playerId}/Hero/{heroId}")]
        [Route("WinrateAgaintOtherHero/Player/{playerId}/Hero/{heroId}/refresh/{refresh}")]
        public IHttpActionResult GetWinrateAgaintOtherHero(int playerId, int heroId, bool refresh = false)
        {
            //1868919644
            var data = _statisticsService.WinrateAgainstHero(playerId, heroId, refresh);
            return CreateResponse(data);
        }
        [Route("WinrateAgaintOtherHero/Player/{playerId}/Hero/{heroId}/Count/{count}")]
        [Route("WinrateAgaintOtherHero/Player/{playerId}/Hero/{heroId}/Count/{count}/refresh/{refresh}")]
        public IHttpActionResult GetWinrateAgaintOtherHero(int playerId, int heroId, int count, bool refresh = false)
        {
            //1868919644
            var data = _statisticsService.WinrateAgainstHero(playerId, heroId, count, refresh);
            return CreateResponse(data);
        }

        [Route("MatchInfo/Match/{id}")]
        public IHttpActionResult GetMatchInfo(int id)
        {
            var data = _statisticsService.GetMatchStatistics(id);
            return CreateResponse(data);
        }
        [Route("ChoosenWinrateAgainstHero/Player/{playerId}/Hero/{heroId}/EnemyHero/{enemyHeroId}")]
        [Route("ChoosenWinrateAgainstHero/Player/{playerId}/Hero/{heroId}/EnemyHero/{enemyHeroId}/refresh/{refresh}")]
        public IHttpActionResult GetChoosenWinrateAgainstHero(int playerId, int heroId, int enemyHeroId, bool refresh = false)
        {
            var data = _statisticsService.ChoosenWinrateAgainstHero(playerId, heroId, enemyHeroId, refresh);
            return CreateResponse(data);
        }
        [Route("ChoosenWinrateAgainstHero/Player/{playerId}/Hero/{heroId}/EnemyHero/{enemyHeroId}/Count/{matchesCount}")]
        [Route("ChoosenWinrateAgainstHero/Player/{playerId}/Hero/{heroId}/EnemyHero/{enemyHeroId}/Count/{matchesCount}/refresh/{refresh}")]
        public IHttpActionResult GetChoosenWinrateAgainstHero(int playerId, int heroId, int enemyHeroId, int matchesCount, bool refresh = false)
        {
            var data = _statisticsService.ChoosenWinrateAgainstHero(playerId, heroId, enemyHeroId, matchesCount, refresh);
            return CreateResponse(data);
        }

        [Route("PlayerRating/Player/{id}")]
        [Route("PlayerRating/Player/{id}/refresh/{refresh}")]
        public IHttpActionResult GetPlayerRating(int id, bool refresh = false)
        {
            var data = _statisticsService.PlayerRating(id, refresh);
            return CreateResponse(data);
        }
        [Route("PlayerRating/Player/{id}/Count/{matchesCount}")]
        [Route("PlayerRating/Player/{id}/Count/{matchesCount}/refresh/{refresh}")]
        public IHttpActionResult GetPlayerRating(int id, int matchesCount, bool refresh = false)
        {
            var data = _statisticsService.PlayerRating(id, matchesCount, refresh);
            return CreateResponse(data);
        }

        [Route("BestVinrateVersus/Player/{id}")]
        [Route("BestVinrateVersus/Player/{id}/refresh/{refresh}")]
        public IHttpActionResult GetBestVinrateVersus(int id, bool refresh = false)
        {
            var data = _statisticsService.BestVs(id, refresh);
            return CreateResponse(data);
        }
        [Route("BestVinrateVersus/Player/{id}/Count/{matchesCount}")]
        [Route("BestVinrateVersus/Player/{id}/Count/{matchesCount}/refresh/{refresh}")]
        public IHttpActionResult GetBestVinrateVersus(int id, int matchesCount, bool refresh = false)
        {
            var data = _statisticsService.BestVs(id, matchesCount, refresh);
            return CreateResponse(data);
        }

        [Route("WorstVs/Player/{id}")]
        [Route("WorstVs/Player/{id}/refresh/{refresh}")]
        public IHttpActionResult GetWorstVs(int id, bool refresh = false)
        {
            var data = _statisticsService.WorstVs(id, refresh);
            return CreateResponse(data);
        }
        [Route("WorstVs/Player/{id}/Count/{matchesCount}")]
        [Route("WorstVs/Player/{id}/Count/{matchesCount}/refresh/{refresh}")]
        public IHttpActionResult GetWorstVs(int id, int matchesCount, bool refresh = false)
        {
            var data = _statisticsService.WorstVs(id, matchesCount, refresh);
            return CreateResponse(data);
        }
    }
}
