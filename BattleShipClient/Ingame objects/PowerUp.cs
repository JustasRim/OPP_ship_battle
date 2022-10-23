
namespace BattleShipClient.Ingame_objects
{
    public enum PowerUpType
    {
        Shield,
        Invulnerability,
    }

    public class PowerUp
    {
        public int RoundsLeft { get; set; }
        public PowerUpType Type{ get; set; }

        public virtual float EffectValue()
        {
            return 0;
        }
    }
}
