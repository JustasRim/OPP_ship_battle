
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

        public override object DeepCopy()
        {
            Tank copy = new Tank();
            copy.CanTakeDamage = CanTakeDamage;
            copy.DamageReduction = this.DamageReduction;
            copy.Parts = new List<Part>();
            copy.Parts.AddRange(this.Parts);
            copy.PowerUps = new List<PowerUp>();
            copy.PowerUps.AddRange(this.PowerUps);

            return (Tank)copy;
        }
        public override object ShallowCopy()
        {
            return (Tank)this.MemberwiseClone();
        }
    }
}
