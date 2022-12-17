using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipClient.Ingame_objects.Iterator
{
    public class ListIterator<T> : IIterator<T>
    {
        List<T> _list = new List<T>();
        int _current = 0;
        int _startX;
        int _startY;

        public List<T> getNext()
        {
            var list = new List<T>();
            Debug.WriteLine($"ListIterator --- Getting next elements of list");
            if(_current == 0) 
            {
                list.Add(_list[_startX + _startY * 10]);
            }
            else
            {
                TryGetByIndex(list, _startX + _current, _startY + _current);
                TryGetByIndex(list, _startX - _current, _startY + _current);
                TryGetByIndex(list, _startX + _current, _startY - _current);
                TryGetByIndex(list, _startX - _current, _startY - _current);
            }
            _current++;
            Debug.WriteLine($"ListIterator --- Returning {list.Count} elements");
            return list;
        }

        bool TryGetByIndex(List<T> list, int x, int y)
        {
            try
            {
                if (x < 0 || y < 0 || x > 9 || y > 9) return false; 
                var obj = _list[x + (y * 10)];
                list.Add(obj);
                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool hasMore()
        {
            Debug.WriteLine($"ListIterator --- Checking if list has more elements");
            var list = new List<T>();
            TryGetByIndex(list, _startX + _current + 1, _startY + _current + 1);
            TryGetByIndex(list, _startX - _current - 1, _startY + _current + 1);
            TryGetByIndex(list, _startX + _current + 1 , _startY - _current - 1);
            TryGetByIndex(list, _startX - _current - 1, _startY - _current - 1);
            return list.Count > 0;
        }

        public ListIterator(List<T> collection, int startX, int startY)
        {
            _list = collection;
            _startX = startX;
            _startY = startY;
        }
    }
}
