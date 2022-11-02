using BattleShipClient.Ingame_objects.Strategy;
using System.Collections.Generic;

namespace BattleShipClient.Ingame_objects
{
    public class Tank : Unit
    {
        public void Explode()
        {
            Parts.ForEach(q => q.Health = 0);
        }

        public void TakeCover()
        {
            if (DamageReduction < 20)
            {
                DamageReduction = 20;
            } else
            {
                DamageReduction *= 10;
            }
        }
        
        public Tank(IDamageStrategy damageStrategy)
        {
            _damageContext = new DamageContext(damageStrategy);
        }

        public Tank()
        {
        }

        public override object DeepCopy()
        {
            Tank copy = new Tank();
            copy.DamageReduction = this.DamageReduction;
            copy.PowerUpType = this.PowerUpType;
            copy.PowerUpValue = this.PowerUpValue;
            copy.Parts = new List<Part>();
            if (this.Parts != null)
            {
                copy.Parts.AddRange(this.Parts);
            }

            return (Tank)copy;
        }
        public override object ShallowCopy()
        {
            return (Tank)this.MemberwiseClone();
        }
    }
}
