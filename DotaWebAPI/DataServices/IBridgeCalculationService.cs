using DatabaseEntities.Entities;

namespace DataServices
{
    interface IBridgeCalculationService
    {
        Match CalculateMatchDetails(Match match);
    }
}
