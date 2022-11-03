using BattleShipClient.Ingame_objects.Adapter;
using BattleShipClient.Ingame_objects.Strategy;
using System.Collections.Generic;

namespace BattleShipClient.Ingame_objects
{
    public class Ship : Unit, ISinkable
    {
        public Ship(IDamageStrategy damageStrategy)
        {
            _damageContext = new DamageContext(damageStrategy);
        }

        public Ship()
        {

        }

        public void Sink()
        {
            Parts.ForEach(q => q.Health = 0);
            Publisher.Notify();
        }

        public override object DeepCopy()
        {
            Ship copy = new Ship();
            copy.DamageReduction = this.DamageReduction;
            copy.Parts = new List<Part>();
            if (this.Parts != null)
            {
                copy.Parts.AddRange(this.Parts);
            }

            return (Ship)copy;
        }
        public override object ShallowCopy()
        {
            return (Ship)this.MemberwiseClone();
        }
    }

}
