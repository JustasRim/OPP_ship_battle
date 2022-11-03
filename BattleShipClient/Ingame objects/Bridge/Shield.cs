
namespace BattleShipClient.Ingame_objects
{
    public class Shield : PowerUp
    {
        private readonly int CurrentArmorValue = 0;
        public Shield(int value)
        {
            CurrentArmorValue = value;
        }
        public override bool CanTakeDamage(int damage)
        {
            return CurrentArmorValue < damage;
        }
        public override int GetDamageTaken(int damage)
        {
            return damage - CurrentArmorValue;
        }
        public override PowerUpType GetPowerUpType()
        {
            return PowerUpType.Shield;
        }
    }
}
