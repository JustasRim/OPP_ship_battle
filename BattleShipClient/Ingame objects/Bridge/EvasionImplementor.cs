
using System;

namespace BattleShipClient.Ingame_objects
{
    public class EvasionImplementor : PowerUpImplementor
    {
        private int CurrentEvasionValue = 0;
        public EvasionImplementor(int value)
        {
            CurrentEvasionValue = value;
        }
        public override bool CanTakeDamage(int health)
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
        public override double GetDamageTaken(int damage)
        {
            return damage;
        }
    }
}
