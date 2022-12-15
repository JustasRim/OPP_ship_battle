using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipClient.Ingame_objects.Iterator
{
    public class ListIterator<T> : IIterator<T> 
    {
        List<T> _list = new List<T>();
        int _current = 0;

        public T getNext()
        {
            Debug.WriteLine($"ListIterator --- Getting next element of list");
            return _list[_current++];
        }

        public bool hasMore()
        {
            Debug.WriteLine($"ListIterator --- Checking if list has more elements");
            return (_list.Count > _current);
        }

        public ListIterator(List<T> collection)
        {
            _list = collection;
        }
    }
}
