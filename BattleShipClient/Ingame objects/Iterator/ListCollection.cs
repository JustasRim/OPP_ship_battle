using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Debug.WriteLine($"ListCollection --- Adding object");
            _list.Add(obj);
        }

        public ListIterator<T> createIterator(int x, int y)
        {
            Debug.WriteLine($"Creating ListCollection Iterator");
            return new ListIterator<T>(_list, x, y);
        }
    }
}
