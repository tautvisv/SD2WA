using System.Runtime.Remoting.Messaging;
using DatabaseEntities.Entities;

namespace DataMockServices.Factories
{
    internal static class AbilitiesFactory
    {
        public static AbilityUpgrade GenerateAbility(int type, int level, int time)
        {
            var ability = new AbilityUpgrade
            {
                Ability = 5110+type,
                Level = level,
                Time = time
            };
            
            return ability;
        }
    }
}
