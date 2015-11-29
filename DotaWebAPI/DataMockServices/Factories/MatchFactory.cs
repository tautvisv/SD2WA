using System.Collections.Generic;
using DatabaseEntities.Entities;

namespace DataMockServices.Factories
{
    internal static class MatchFactory
    {
        public static Match GenerateMath(int id)
        {
            var match = new Match
            {
                ID = id,
                StartTime = 97856321,
            };
            switch (id)
            {
                case 1:
                    match.BarracksStatusDire = 3;
                    match.BarracksStatusRadiant = 9;
                    match.Cluster = 5;
                    match.Duration = 6845;
                    match.Engine = 14;
                    match.FirstBloodTime = 69;
                    match.HumanPlayers = 1;
                    match.GameMode = 1;
                    match.RadiantWin = true;
                    match.TowerStatusDire = 9;
                    match.TowerStatusRadiant = 8;
                    break;
                case 2:
                    match.BarracksStatusDire = 8;
                    match.BarracksStatusRadiant = 7;
                    match.Cluster = 53;
                    match.Duration = 7835;
                    match.Engine = 2;
                    match.FirstBloodTime = 453;
                    match.HumanPlayers = 1;
                    match.GameMode = 12;
                    match.RadiantWin = false;
                    match.TowerStatusDire = 1;
                    match.TowerStatusRadiant = 7;
                    break;
                default:
                    match.BarracksStatusDire = 3;
                    match.BarracksStatusRadiant = 89;
                    match.Cluster = 9;
                    match.Duration = 12387;
                    match.Engine = 35;
                    match.FirstBloodTime = 25;
                    match.HumanPlayers = 35;
                    match.GameMode = 7;
                    match.RadiantWin = true;
                    match.TowerStatusDire = 8;
                    match.TowerStatusRadiant = 1;
                    break;
            }
            match.Players = new List<InGamePlayer>();
            for (int i = 0; i < 10; i++)
            {
                ((List<InGamePlayer>)match.Players).Add(PlayersFacotry.GeneratePlayer(i%5,i%5));
            }
            return match;
        }
    }
}
