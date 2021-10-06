using System;
using System.Collections;
using System.Collections.Generic;

namespace Seasons_App
{
    class Program
    {
        static void Main(string[] args)
        {
            Seasons<string> seasons = new Seasons<string>();
            seasons.Add("Winter");
            seasons.Add("Spring");
            seasons.Add("Summer");
            seasons.Add("Autumn");

            foreach (var item in seasons)
            {
                Console.WriteLine(item);
            }
        }
    }
    public class Seasons<T> : IEnumerable<T> 
    {
        static readonly T[] _emptyArray = new T[0];
        private const int _defaultCapacity = 0;
        private T[] _items = new T[_defaultCapacity];
        private int _size;
        private int _version;
        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator<T>(_items);
         }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator<T>(_items);
        }
        public int Capacity
        {
            get
            {
                return _items.Length;
            }
            set
            {
                if (value != _items.Length)
                {
                    if (value > 0)
                    {
                        T[] newItems = new T[value];
                        if (_size > 0)
                        {
                            Array.Copy(_items, 0, newItems, 0, _size);
                        }
                        _items = newItems;
                    }
                    else
                    {
                        _items = _emptyArray;
                    }
                }
            }
        }
        public void Add(T item)
        {
            if (_size == _items.Length) EnsureCapacity(_size + 1);
            _items[_size++] = item;
            _version++;
        }
        private void EnsureCapacity(int min)
        {
            if (_items.Length < min)
            {
                int newCapacity = _items.Length == 0 ? _defaultCapacity : _items.Length * 2;
                if ((uint)newCapacity > 0X7FEFFFFF) newCapacity = 0X7FEFFFFF;
                if (newCapacity < min) newCapacity = min;
                Capacity = newCapacity;
            }
        }
    }
    public class Enumerator<T> : IEnumerator<T>
    {
        private T[] _items;
        private int count;
        public Enumerator(T[] items)
        {
            _items = items;
        }
        public T Current => _items[count++];
        object IEnumerator.Current => Current;
        public void Dispose()
        {
            
        }
        public bool MoveNext()
        {
            return count < _items.Length;
        }
        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}