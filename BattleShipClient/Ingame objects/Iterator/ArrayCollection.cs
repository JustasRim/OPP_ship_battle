using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipClient.Ingame_objects.Iterator
{
    public class ArrayCollection<T> : ICollectionArray<T> 
    {
        private T[] _arr = new T[16];
        int _capacity = 16;

        //Add items to the collection
        public void Add(T obj)
        {
            _arr[_arr.Length] = obj;
            if (_arr.Length == _capacity) EnsureCapacity(_capacity * 2);
        }

        void EnsureCapacity(int newCapacity)
        {
            T[] temp = new T[newCapacity];
            for (int i = 0; i < _arr.Length; i++)
            {
                temp[i] = _arr[i];
            }
            _capacity = newCapacity;
            _arr = temp;
        }

        public ArrayIterator<T> createIterator()
        {
            return new ArrayIterator<T>(_arr);
        }
    }
}
