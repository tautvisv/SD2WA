namespace DataServices
{
    public interface IRegister
    {
        int RegisterMatchListCommand(int playerID, int? heroID, int? enemyHeroID, int? matchCount);
        int RegisterMatchCommand(int matchID);
    }
}
