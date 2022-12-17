using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipClient.Ingame_objects.Iterator
{
    public interface ICollectionList<T>
    {
        ListIterator<T> createIterator(int x, int y);
    }
    public interface ICollectionArray<T>
    {
        ArrayIterator<T> createIterator();
    }
    public interface ICollectionLinkedList<T>
    {
        LinkedListIterator<T> createIterator();
    }
}
