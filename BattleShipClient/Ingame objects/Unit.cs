using BattleShipClient.Ingame_objects.Observer;
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

        protected PowerUp powerUp;

        public int Health { get => Parts.Sum(q => q.Health); }

        public float DamageReduction { get; set; } = 0;

        public List<Part> Parts { get; set; } = new List<Part>();

        public Publisher Publisher { get; set; }

        public PowerUp PowerUp
        {
            set { powerUp = value; }
        }

        public void AddPowerUp(PowerUpType type, int value)
        {
            PowerUp newPowerUp = new Shield(value);
            if (type == PowerUpType.Evasion)
            {
                newPowerUp = new Evasion(value);
            }
            this.powerUp = newPowerUp;
        }

        public virtual bool CanTakeDamage(int damage)
        {
            return powerUp.CanTakeDamage(damage);
        }

        public virtual int GetDamageTaken(int damage)
        {
            return powerUp.GetDamageTaken(damage);
        }

        public virtual PowerUpType GetPowerUpType()
        {
            return powerUp.GetPowerUpType();
        }
        public string GetName()
        {
            return this.GetType().Name;
        }

        public Unit()
        {
            Publisher = new Publisher();
            _damageContext = new DamageContext(new BaseDamageStrategy());
        }

        public virtual void TakeDamage(int damage)
        {
            _damageContext.TakeDamage(Parts, damage, DamageReduction);
        }

        public virtual object DeepCopy()
        {
            Unit copy = new Unit();
            copy.Publisher = this.Publisher;
            copy._damageContext = this._damageContext;
            copy.powerUp = this.powerUp;
            copy.DamageReduction = this.DamageReduction;
            copy.Parts = new List<Part>();
            if (this.Parts != null)
            {
                copy.Parts.AddRange(this.Parts);
            }

            return (Unit)copy;
        }
        public virtual object ShallowCopy()
        {
            return (Unit)this.MemberwiseClone();
        }
    }

}
