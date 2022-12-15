using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipClient.Ingame_objects.Iterator
{
    public class LinkedListIterator<T> : IIterator<T> 
    {
        LinkedList<T> _list = new LinkedList<T>();
        int _current = 0;
        LinkedListNode<T> _head;

        public T getNext()
        {
            var val = _current == 0 ? _head.Value : _head.Next.Value;
            _current++;
            return val;
        }

        public bool hasMore()
        {
            return(_list.Count > _current);
        }

        public LinkedListIterator(LinkedList<T> collection)
        {
            _list = collection;
            _head = _list.First;
        }
    }
}
