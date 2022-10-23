
namespace BattleShipClient.Ingame_objects
{
    public class Shield : PowerUp
    {
        public float ArmourValue { get; set; }

        public override float EffectValue()
        {
            return ArmourValue;
        }

        public Shield()
        {
            Type = PowerUpType.Shield;
        }
    }
}
