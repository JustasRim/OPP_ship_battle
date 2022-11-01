namespace BattleShipClient.Ingame_objects.Adapter
{
    public class ShipTankAdapter : ISinkable
    {
        private Tank _tank;

        public ShipTankAdapter(Tank tank)
        {
            _tank = tank;
        }

        public void Sink()
        {
            _tank.Explode();
        }
    }
}
