using Data;
using DatabaseEntities.Entities;
using DataRepositoriesInterfaces;

namespace DataServices.Services
{
    public class StatisticsService:BaseService<Match>, IStatisticsService
    {
        protected readonly IMatchRepository MatchesRepository;
        protected readonly IBridgeDotaCalculation CalculationService;
        protected readonly IRegister TaskRegistrator;
        public StatisticsService(IUnitOfWork unitOfWork, IMatchRepository matchesRepository, IBridgeDotaCalculation calculationService, IRegister taskRegistrator)
            : base(unitOfWork, matchesRepository)
        {
            MatchesRepository = matchesRepository;
            CalculationService = calculationService;
            TaskRegistrator = taskRegistrator;
        }

        public MatchDto GetMatchStatistics(int id)
        {
            var matchDto = new MatchDto();
            var match = MatchesRepository.GetByWebApiId(id);
            if (match == null)
            {
                //https://api.steampowered.com/IDOTA2Match_570/GetMatchDetails/V1/?key=893F592E19918CA8A9CB5A847C94E2ED&match_id=46512132
                matchDto.WaitingTime = TaskRegistrator.RegisterMatchCommand(id);
                if (matchDto.WaitingTime == -1) return null;
                _unitOfWork.Commit();
                return matchDto;
            }
            matchDto.Match = CalculationService.GetMatchStatistics(match);
            matchDto.WaitingTime = 0;
            return matchDto;
        }
        public HeroWinrateDto WinrateAgainstHero(int playerId, int enemyHeroID, bool refresh)
        {
            var data = new HeroWinrateDto();
            if (refresh)
            {
                data.WaitingTime = TaskRegistrator.RegisterMatchListCommand(playerId, null, enemyHeroID, null);
                _unitOfWork.Commit();
                return data;
            }
            var matches = MatchesRepository.FilteredList(playerId, enemyHeroID);
            if (matches.Count == 0) return null;
            data.Winrate = CalculationService.GetWinrate(matches, playerId, enemyHeroID);
            data.WaitingTime = 0;
            _unitOfWork.Commit();
            return data;
        }
        public HeroWinrateDto WinrateAgainstHero(int playerId, int enemyHeroID, int matchCount, bool refresh)
        {
            var data = new HeroWinrateDto();
            if (refresh)
            {
                data.WaitingTime = TaskRegistrator.RegisterMatchListCommand(playerId, null, enemyHeroID, matchCount);
                _unitOfWork.Commit();
                return data;
            }
            var matches = MatchesRepository.FilteredList(playerId, enemyHeroID, matchCount);
            data.Winrate = CalculationService.GetWinrate(matches, playerId, enemyHeroID);
            data.WaitingTime = 0;
            return data;
        }

        public HeroWinrateDto ChoosenWinrateAgainstHero(int playerId, int choosenHeroID, int enemyHeroID, bool refresh)
        {
            var data = new HeroWinrateDto();
            if (refresh)
            {
                data.WaitingTime = TaskRegistrator.RegisterMatchListCommand(playerId, choosenHeroID, enemyHeroID, null);
                //https://api.steampowered.com/IDOTA2Match_570/GetMatchHistory/V1/?key=893F592E19918CA8A9CB5A847C94E2ED&account_id=48276679&hero_id=11
                _unitOfWork.Commit();
                return data;
            }
            var matches = MatchesRepository.FilteredListByHero(playerId, choosenHeroID, enemyHeroID);
            if (matches.Count == 0) return null;
            data.Winrate = CalculationService.GetWinrate(matches,playerId,enemyHeroID);
            data.WaitingTime = 0;
            return data;
        }

        public HeroWinrateDto ChoosenWinrateAgainstHero(int playerId, int choosenHeroID, int enemyHeroID, int matchesCount, bool refresh)
        {
            var data = new HeroWinrateDto();
            if (refresh)
            {
                data.WaitingTime = TaskRegistrator.RegisterMatchListCommand(playerId, choosenHeroID, enemyHeroID, matchesCount);
                //https://api.steampowered.com/IDOTA2Match_570/GetMatchHistory/V1/?key=893F592E19918CA8A9CB5A847C94E2ED&account_id=48276679&hero_id=11&matches_requested=9
                _unitOfWork.Commit();
                return data;
            }
            var matches = MatchesRepository.FilteredListByHero(playerId, choosenHeroID, enemyHeroID, matchesCount);
            if (matches.Count == 0) return null;
            data.Winrate = CalculationService.GetWinrate(matches, playerId, enemyHeroID);
            data.WaitingTime = 0;
            return data;
        }

        public PlayerRatingDto PlayerRating(int playerID, bool refresh)
        {
            var data = new PlayerRatingDto();
            if (refresh)
            {
                data.WaitingTime = TaskRegistrator.RegisterMatchListCommand(playerID, null, null, null);
            //https://api.steampowered.com/IDOTA2Match_570/GetMatchHistory/V1/?key=893F592E19918CA8A9CB5A847C94E2ED&account_id=48276679
                _unitOfWork.Commit();
                return data;
            }
            var matches = MatchesRepository.FilteredList(playerID);
            if (matches.Count == 0) return null;
            data.Rating = CalculationService.GetPlayerRating(matches, playerID);
            return data;
        }

        public PlayerRatingDto PlayerRating(int playerID, int matchCount, bool refresh)
        {
            var data = new PlayerRatingDto();
            if (refresh)
            {
                data.WaitingTime = TaskRegistrator.RegisterMatchListCommand(playerID, null, null, matchCount);
                //https://api.steampowered.com/IDOTA2Match_570/GetMatchHistory/V1/?key=893F592E19918CA8A9CB5A847C94E2ED&account_id=48276679&matches_requested=9
                _unitOfWork.Commit();
                return data;
            }
            var matches = MatchesRepository.FilteredListCount(playerID, matchCount);
            if (matches.Count == 0) return null;
            data.Rating = CalculationService.GetPlayerRating(matches, playerID);
            return data;
        }

        public HeoresInfoDto BestVs(int playerID, bool refresh)
        {
            var data = new HeoresInfoDto();
            if (refresh)
            {
                data.WaitingTime = TaskRegistrator.RegisterMatchListCommand(playerID, null, null, null);
                //https://api.steampowered.com/IDOTA2Match_570/GetMatchHistory/V1/?key=893F592E19918CA8A9CB5A847C94E2ED&account_id=48276679
                _unitOfWork.Commit();
                return data;
            }
            var matches = MatchesRepository.FilteredList(playerID);
            if (matches.Count == 0) return null;
            data.Information = CalculationService.GetBestAgainst(matches);
            return data;
        }

        public HeoresInfoDto BestVs(int playerID, int matchCount, bool refresh)
        {
            var data = new HeoresInfoDto();
            if (refresh)
            {
                data.WaitingTime = TaskRegistrator.RegisterMatchListCommand(playerID, null, null, matchCount);
                //https://api.steampowered.com/IDOTA2Match_570/GetMatchHistory/V1/?key=893F592E19918CA8A9CB5A847C94E2ED&account_id=48276679&matches_requested=9
                _unitOfWork.Commit();
                return data;
            }
            var matches = MatchesRepository.FilteredList(playerID, matchCount);
            if (matches.Count == 0) return null;
            data.Information = CalculationService.GetBestAgainst(matches);
            return data;
        }

        public HeoresInfoDto WorstVs(int playerID, bool refresh)
        {
            var data = new HeoresInfoDto();
            if (refresh)
            {
                data.WaitingTime = TaskRegistrator.RegisterMatchListCommand(playerID, null, null, null);
                _unitOfWork.Commit();
                return data;
            }
            var matches = MatchesRepository.FilteredList(playerID);
            if (matches.Count == 0) return null;
            data.Information = CalculationService.GetWorstAgainst(matches);
            return data;
        }

        public HeoresInfoDto WorstVs(int playerID, int matchCount, bool refresh)
        {
            var data = new HeoresInfoDto();
            if (refresh)
            {
                data.WaitingTime = TaskRegistrator.RegisterMatchListCommand(playerID, null, null, matchCount);
                _unitOfWork.Commit();
                return data;
            }
            var matches = MatchesRepository.FilteredList(playerID, matchCount);
            if (matches.Count == 0) return null;
            data.Information = CalculationService.GetWorstAgainst(matches);
            return data;
        }

    }
}
