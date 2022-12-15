using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipClient.Ingame_objects.Iterator
{
    public class LinkedListCollection<T> : ICollectionLinkedList<T> 
    {
        private LinkedList<T> _list = new LinkedList<T>();

        //Add items to the collection
        public void Add(T obj)
        {
            _list.AddLast(obj);
        }

        public LinkedListIterator<T> createIterator()
        {
            return new LinkedListIterator<T>(_list);
        }
    }
}
