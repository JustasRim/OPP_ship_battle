using System.Collections.Generic;

namespace BattleShipClient.Ingame_objects
{
    public class Unit
    {
        public float Health { get; set; }
        public bool CanTakeDamage { get; set; }
        public float DamageReduction { get; set; }
        public List<PowerUp> PowerUps { get; set; }

        public void RefreshPowerUps()
        {
            float damageReduction = 0;
            foreach (var powerUp in PowerUps)
            {
                if (powerUp.RoundsLeft == 0)
                {
                    if (powerUp.Type == PowerUpType.Invulnerability)
                        CanTakeDamage = true;
                    PowerUps.Remove(powerUp);
                }

                switch (powerUp.Type)
                {
                    case PowerUpType.Invulnerability:
                        CanTakeDamage = false;
                        break;
                    case PowerUpType.Shield:
                        damageReduction += powerUp.EffectValue();
                        break;
                }
            }
            DamageReduction = damageReduction;
        }
    }

}
