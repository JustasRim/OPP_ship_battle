
using BattleShipClient.Ingame_objects.Prototype;
using System;

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

        public PowerUp(int roundsLeft, PowerUpType type)
        {
            this.RoundsLeft = roundsLeft;
            this.Type = type;
        }
    }
}
