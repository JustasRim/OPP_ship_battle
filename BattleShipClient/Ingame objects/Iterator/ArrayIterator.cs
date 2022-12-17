using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipClient.Ingame_objects.Iterator
{
    public class ArrayIterator<T>
    {
        T[] _list = new T[16];
        int _current = 0;

        public T getNext()
        {
            return _list[_current++];
        }

        public bool hasMore()
        {
            return(_list.Length > _current);
        }

        public ArrayIterator(T[] collection)
        {
            _list = collection;
        }
    }
}
