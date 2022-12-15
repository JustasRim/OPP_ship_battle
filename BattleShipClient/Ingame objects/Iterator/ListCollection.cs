using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipClient.Ingame_objects.Iterator
{
    public class ListCollection<T> : ICollectionList<T> 
    {
        private List<T> _list = new List<T>();

        public void Add(T obj)
        {
            _list.Add(obj);
        }

        public ListIterator<T> createIterator()
        {
            return new ListIterator<T>(_list);
        }
    }
}
