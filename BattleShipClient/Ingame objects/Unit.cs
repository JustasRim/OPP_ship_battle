using BattleShipClient.Ingame_objects.Prototype;
using BattleShipClient.Ingame_objects.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleShipClient.Ingame_objects
{
    public class Unit : IPrototype
    {
        protected DamageContext _damageContext;

        public int Health { get => Parts.Sum(q => q.Health); }

        public bool CanTakeDamage { get; set; }

        public float DamageReduction { get; set; } = 0;

        public List<Part> Parts { get; set; } = new List<Part>();

        public List<PowerUp> PowerUps { get; set; }

        public Unit()
        {
            _damageContext = new DamageContext(new BaseDamageStrategy());
        }

        public virtual void TakeDamage(int damage)
        {
            _damageContext.TakeDamage(Parts, damage, DamageReduction);
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

        public virtual object DeepCopy()
        {
            Unit copy = new Unit();
            copy._damageContext = this._damageContext;
            copy.CanTakeDamage = this.CanTakeDamage;
            copy.DamageReduction = this.DamageReduction;
            copy.Parts = new List<Part>();
            if (this.Parts != null)
            {
                copy.Parts.AddRange(this.Parts);
            }
            copy.PowerUps = new List<PowerUp>();//cannot be null

            if (this.PowerUps != null)
            {
                copy.PowerUps.AddRange(this.PowerUps);
            }

            return (Unit)copy;
        }
        public virtual object ShallowCopy()
        {
            return (Unit)this.MemberwiseClone();
        }
    }

}
