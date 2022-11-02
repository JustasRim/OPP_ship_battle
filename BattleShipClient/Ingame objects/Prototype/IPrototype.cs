using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipClient.Ingame_objects.Prototype
{
    public interface IPrototype
    {
        object DeepCopy();

        object ShallowCopy();
    }
}
