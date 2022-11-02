
using BattleShipClient.Ingame_objects.Adapter;
using System.Collections.Generic;

namespace BattleShipClient.Ingame_objects
{
    public class Ship : Unit, ISinkable
    {
        public void Sink()
        {
            Parts.ForEach(q => q.Health = 0);
        }

        public override object DeepCopy()
        {
            Ship copy = new Ship();
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

            return (Ship)copy;
        }
        public override object ShallowCopy()
        {
            return (Tank)this.MemberwiseClone();
        }
    }

}
