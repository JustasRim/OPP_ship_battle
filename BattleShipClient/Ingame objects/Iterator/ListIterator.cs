using System;
using System.Collections.Generic;
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
            return _list[_current++];
        }

        public bool hasMore()
        {
            return(_list.Count > _current);
        }

        public ListIterator(List<T> collection)
        {
            _list = collection;
        }
    }
}
