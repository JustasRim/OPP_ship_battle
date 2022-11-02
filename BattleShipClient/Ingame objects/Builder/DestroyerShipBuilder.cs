using BattleShipClient.Ingame_objects.Strategy;

namespace BattleShipClient.Ingame_objects.Builder
{
    public class DestroyerShipBuilder : IBuilder
    {
        private Ship ship = new Ship(new DestroyerDamageStrategy());

        public void AddCanon()
        {
            ship.Parts.Add(new Part("Cannon", 20, 100, 0, -2));
        }

        public void AddEngine()
        {
            ship.Parts.Add(new Part("Diesel engine", 0, 100, 3, 90));
        }

        public void AddHull()
        {
            ship.Parts.Add(new Part("Metal hull", 0, 100, 20, -10));
        }

        public void AddKeel()
        {
            ship.Parts.Add(new Part("Metal keel", 0, 100, 40, -6));
        }

        public void AddDamageStrategy()
        {

        }

        public Ship GetShip()
        {
            return ship;
        }
    }
}
