
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
    }
}
