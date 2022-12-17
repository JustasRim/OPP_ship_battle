using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipClient.Ingame_objects.Iterator
{
    interface IIterator<T>
    {
        List<T> getNext();
        bool hasMore();
    }
}
