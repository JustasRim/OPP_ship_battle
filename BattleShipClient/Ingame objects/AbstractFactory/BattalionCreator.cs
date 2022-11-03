using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipClient.Ingame_objects.AbstractFactory
{
    public class BattalionCreator : Creator
    {
        public override Battalion CreateBattalion(int type)
        {
            switch (type)
            {
                case 1:
                    return new BattalionA();
                case 2:
                    return new BattalionB();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
