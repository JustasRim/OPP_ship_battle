namespace BattleShipClient.Ingame_objects.Builder
{
    public interface IBuilder
    {
        void AddKeel();

        void AddHull();

        void AddEngine();

        void AddCanon();

        Ship GetShip();
    }
}
