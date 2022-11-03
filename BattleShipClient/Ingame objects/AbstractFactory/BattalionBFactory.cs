using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipClient.Ingame_objects.AbstractFactory
{
    public class BattalionBFactory : AbstractFactory
    {
        public override Tank CreateTank()
        {
            return new BattalionBTank();
        }
        public override Ship CreateShip()
        {
            return new BattalionBShip();
        }
    }
}
