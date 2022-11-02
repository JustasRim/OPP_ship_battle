
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
            copy.Parts.AddRange(this.Parts);
            copy.PowerUps = new List<PowerUp>();
            copy.PowerUps.AddRange(this.PowerUps);

            return (Ship)copy;
        }
        public override object ShallowCopy()
        {
            return (Tank)this.MemberwiseClone();
        }
    }

}
