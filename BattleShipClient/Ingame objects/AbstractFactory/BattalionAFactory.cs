using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipClient.Ingame_objects.AbstractFactory
{
    public class BattalionAFactory : AbstractFactory
    {
        public override Tank CreateTank()
        {
            return new BattalionATank();
        }
        public override Ship CreateShip()
        {
            return new BattalionAShip();
        }
    }
}
