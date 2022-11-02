
namespace BattleShipClient.Ingame_objects
{
    public class ShieldImplementor : PowerUpImplementor
    {
        private readonly int CurrentArmorValue = 0;
        public ShieldImplementor(int value)
        {
            CurrentArmorValue = value;
        }
        public override bool CanTakeDamage(int health)
        {
            return CurrentArmorValue < health;
        }
        public override double GetDamageTaken(int damage)
        {
            return damage - CurrentArmorValue;
        }
    }
}
