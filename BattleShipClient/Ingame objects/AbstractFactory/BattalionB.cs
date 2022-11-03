using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipClient.Ingame_objects.AbstractFactory
{
    public class BattalionB : Battalion
    {
        public override AbstractFactory GetAbstractFactory()
        {
            return new BattalionAFactory();
        }
    }
}
