using System;
using System.Collections.Generic;

namespace BattleShipClient.Ingame_objects.Strategy
{
    internal class TankDamageStrategy : IDamageStrategy
    {
        public void DealDamage(List<Part> parts, int damage, double damageReduction)
        {
            if (damageReduction <= 0)
            {
                damageReduction = 0;
            }
            else
            {
                damageReduction *= 1.1;
            }

            if (damageReduction > 0.9)
            {
                damageReduction = 0.9;
            }


            var damageAfterReduction = (int)(damage * (1 - damageReduction));
            var rnd = new Random();
            var partIndex = rnd.Next(0, parts.Count);
            var damageDealt = damageAfterReduction - parts[partIndex].Armor;
            if (damageDealt < 0)
            {
                damageDealt = 0;
            }

            parts[partIndex].Health -= damageDealt;
        }
    }
}
