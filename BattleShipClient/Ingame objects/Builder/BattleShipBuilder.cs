using BattleShipClient.Ingame_objects.Strategy;

namespace BattleShipClient.Ingame_objects.Builder
{
    internal class BattleShipBuilder : IBuilder
    {
        private Ship ship = new Ship(new BattleShipDamageStrategy());

        public void AddCanon()
        {
            ship.Parts.Add(new Part("Cannon", 60, 100, 5, -200));
        }

        public void AddEngine()
        {
            ship.Parts.Add(new Part("Diesel engine", 0, 100, 1, 500));
        }

        public void AddHull()
        {
            ship.Parts.Add(new Part("Metal hull", 0, 1000, 50, -250));
        }

        public void AddKeel()
        {
            ship.Parts.Add(new Part("Metal keel", 0, 1000, 80,-40));
        }

        public Ship GetShip()
        {
            return ship;
        }
    }
}
