
using BattleShipClient.Ingame_objects.Prototype;
using System;

namespace BattleShipClient.Ingame_objects
{
    public abstract class PowerUpImplementor
    {
        public abstract bool CanTakeDamage(int health);
        public abstract double GetDamageTaken(int damage);
    }
}
