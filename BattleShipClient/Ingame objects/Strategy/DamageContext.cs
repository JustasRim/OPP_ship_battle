using System.Collections.Generic;

namespace BattleShipClient.Ingame_objects.Strategy
{
    public class DamageContext
    {
        private IDamageStrategy _damageStrategy;

        public DamageContext(IDamageStrategy damageStrategy)
        {
            _damageStrategy = damageStrategy;   
        }

        public void TakeDamage(List<Part> parts, int damage, double damageReduction)
        {
            _damageStrategy.DealDamage(parts, damage, damageReduction);
        }
    }
}
