using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleShipClient.Ingame_objects
{
    public class Unit : ICloneable
    {
        public int Health { get => Parts.Sum(q => q.Health); }
        public bool CanTakeDamage { get; set; }
        public float DamageReduction { get; set; } = 0;
        public List<Part> Parts { get; set; } = new List<Part>();
        public List<PowerUp> PowerUps { get; set; }

        public virtual void TakeDamage(int damage)
        {
            var damageAfterReduction = (int)(damage * (1 - DamageReduction));
            var rnd = new Random();
            var partIndex = rnd.Next(0, Parts.Count);
            var damageDealt = damageAfterReduction - Parts[partIndex].Armor;
            if (damageDealt < 0)
            {
                damageDealt = 0;
            }

            Parts[partIndex].Health -= damageDealt;
        }

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

        public Object Clone()
        {
            return (Unit)this.MemberwiseClone();
        }

        public Unit CopyDeep()
        {
            Unit copy = (Unit)this.Clone();
            copy.PowerUps = new List<PowerUp>();
            copy.PowerUps.AddRange(PowerUps);
            return copy;
        }
    }

}
