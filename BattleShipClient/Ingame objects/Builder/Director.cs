namespace BattleShipClient.Ingame_objects.Builder
{
    public class Director
    {
        public void Construct(IBuilder builder)
        {
            builder.AddKeel();
            builder.AddHull();
            builder.AddEngine();
            builder.AddCanon();
        }
    }
}
