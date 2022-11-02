using BattleShipClient.Ingame_objects.Observer;
using BattleShipClient.Ingame_objects.Prototype;
using BattleShipClient.Ingame_objects.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleShipClient.Ingame_objects
{
    public enum PowerUpType
    {
        None,
        Shield,
        Evasion,
    }
    public class Unit : IPrototype
    {
        protected DamageContext _damageContext;

        protected PowerUpImplementor implementor;

        public int Health { get => Parts.Sum(q => q.Health); }

        public float DamageReduction { get; set; } = 0;

        public List<Part> Parts { get; set; } = new List<Part>();

        public Publisher Publisher { get; set; }

        public PowerUpType PowerUpType = PowerUpType.None;

        public PowerUpImplementor PowerUpImplementor
        {
            set { implementor = value; }
        }

        public int PowerUpValue = 0;

        public void AddPowerUp(int value)
        {
            PowerUpValue += value;
        }

        public virtual bool CanTakeDamage()
        {
            return implementor.CanTakeDamage(Health);
        }

        public virtual double GetDamageTaken(int damage)
        {
            return implementor.GetDamageTaken(damage);
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
            copy.PowerUpType = this.PowerUpType;
            copy.PowerUpValue = this.PowerUpValue;
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
