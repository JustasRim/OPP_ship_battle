
using BattleShipClient.Ingame_objects.Adapter;

namespace BattleShipClient.Ingame_objects
{
    public class Ship : Unit, ISinkable
    {
        public void Sink()
        {
            Parts.ForEach(q => q.Health = 0);
        }
    }
}
