using System.Collections.Generic;
using DatabaseEntities.Entities;

namespace DataMockServices.Factories
{
    internal static class PlayersFacotry
    {
        public static InGamePlayer GeneratePlayer(int hero, int position)
        {
            var player = new InGamePlayer
            {
                Slot = position,
                HeroID = hero
            };
            switch (hero)
            {
                case 1:
                    player.AccountID = 6543215;
                    player.Kills = 24;
                    player.Assists = 3;
                    player.Deaths = 8;
                    player.Denies = 55;
                    player.Gold = 15000;
                    player.GoldPerMin = 515;
                    player.GoldSpent = 13500;
                    player.HeroDamage = 25000;
                    player.HeroHealing = 0;
                    player.ItemID0 = 1;
                    player.ItemID1 = 35;
                    player.ItemID2 = 77;
                    player.ItemID3 = 89;
                    player.ItemID4 = 88;
                    player.ItemID5 = 33;
                    player.Level = 25;
                    player.LastHits = 403;
                    player.XpPerMin = 750;
                    //player.MatchID = 1654845;
                    player.TowerDamage = 3500;
                    player.HeroID = 23;
                    break;
                case 2:
                    player.AccountID = 735354;
                    player.Kills = 0;
                    player.Assists = 12;
                    player.Deaths = 7;
                    player.Denies = 5;
                    player.Gold = 1500;
                    player.GoldPerMin = 170;
                    player.GoldSpent = 1350;
                    player.HeroDamage = 3100;
                    player.HeroHealing = 1000;
                    player.ItemID0 = 1;
                    player.ItemID1 = 8;
                    player.ItemID2 = 38;
                    player.ItemID3 = 12;
                    player.ItemID4 = 98;
                    player.ItemID5 = 88;
                    player.Level = 16;
                    player.LastHits = 103;
                    player.XpPerMin = 350;
                   // player.MatchID = 1654845;
                    player.TowerDamage = 800;
                    player.HeroID = 28;
                    break;
                case 3:
                    player.AccountID = 1234;
                    player.Kills = 5;
                    player.Assists = 15;
                    player.Deaths = 2;
                    player.Denies = 150;
                    player.Gold = 23000;
                    player.GoldPerMin = 400;
                    player.GoldSpent = 13500;
                    player.HeroDamage = 17500;
                    player.HeroHealing = 2500;
                    player.ItemID0 = 1;
                    player.ItemID1 = 8;
                    player.ItemID2 = 56;
                    player.ItemID3 = 35;
                    player.ItemID4 = 83;
                    player.ItemID5 = 75;
                    player.Level = 23;
                    player.LastHits = 250;
                    player.XpPerMin = 400;
                   // player.MatchID = 1654845;
                    player.TowerDamage = 950;
                    player.HeroID = 39;
                    break;
                default:
                    player.AccountID = 2344965;
                    player.Kills = 17;
                    player.Assists = 8;
                    player.Deaths = 23;
                    player.Denies = 87;
                    player.Gold = 19507;
                    player.GoldPerMin = 435;
                    player.GoldSpent = 18008;
                    player.HeroDamage = 21478;
                    player.HeroHealing = 1000;
                    player.ItemID0 = 1;
                    player.ItemID1 = 5;
                    player.ItemID2 = 9;
                    player.ItemID3 = 53;
                    player.ItemID4 = 12;
                    player.ItemID5 = 35;
                    player.Level = 19;
                    player.LastHits = 398;
                    player.XpPerMin = 469;
                    //player.MatchID = 1654845;
                    player.TowerDamage = 4589;
                    player.HeroID = 99;
                    break;
            }
            player.AbilityUpgrades = new List<AbilityUpgrade>();
            for (int i = 0; i < player.Level; i++)
            {
                ((List<AbilityUpgrade>)player.AbilityUpgrades).Add(AbilitiesFactory.GenerateAbility(i % 5, i + 1, i * 10));
            }
            return player;
        }
    }
}
