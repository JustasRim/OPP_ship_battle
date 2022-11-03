
using System;

namespace BattleShipClient.Ingame_objects
{
    public class Evasion : PowerUp
    {
        private readonly int CurrentEvasionValue = 0;
        public Evasion(int value)
        {
            CurrentEvasionValue = value;
        }
        public override bool CanTakeDamage(int damage)
        {
            if (CurrentEvasionValue < 100)
            {
                Random rnd = new Random();
                int generated = rnd.Next(1, 100);
                if (generated > CurrentEvasionValue)
                    return true;
            }
            return false;
        }
        public override int GetDamageTaken(int damage)
        {
            return damage;
        }
        public override PowerUpType GetPowerUpType()
        {
            return PowerUpType.Evasion;
        }
    }
}
