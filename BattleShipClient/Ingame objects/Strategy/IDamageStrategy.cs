using System.Collections.Generic;

namespace BattleShipClient.Ingame_objects.Strategy
{
    public interface IDamageStrategy
    {
        void DealDamage(List<Part> parts, int damage, double damageReduction);
    }
}
