
using BattleShipClient.Ingame_objects.Prototype;
using System;

namespace BattleShipClient.Ingame_objects
{
    public enum PowerUpType
    {
        None,
        Shield,
        Evasion,
    }

    public abstract class PowerUp
    {
        public abstract bool CanTakeDamage(int damage);
        public abstract int GetDamageTaken(int damage);
        public abstract PowerUpType GetPowerUpType();
    }
}
