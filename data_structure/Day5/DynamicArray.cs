using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
        public class DynamicArray<T>
        {
            private T[] _items;
            private int _size;
            private int _capacity;
            private const int DEFAULT_CAPACITY = 4;

            public int Count => _size;
            public int Capacity => _capacity;

            public DynamicArray(int initialCapacity = 0)
            {
                _capacity = initialCapacity > 0 ? initialCapacity : DEFAULT_CAPACITY;
                _items = new T[_capacity];
                _size = 0;
            }

            // Indexer
            public T this[int index]
            {
                get
                {
                    if (index < 0 || index >= _size) throw new IndexOutOfRangeException();
                    return _items[index];
                }
                set
                {
                    if (index < 0 || index >= _size) throw new IndexOutOfRangeException();
                    _items[index] = value;
                }
            }

           
            public void Add(T item)
            {
                if (_size == _capacity) Resize(_capacity * 2);
                _items[_size++] = item;
            }

           
            public void Insert(int index, T item)
            {
                if (index < 0 || index > _size) throw new IndexOutOfRangeException();
                if (_size == _capacity) Resize(_capacity * 2);

                // Shift elements to the right
                Array.Copy(_items, index, _items, index + 1, _size - index);

                _items[index] = item;
                _size++;
            }

           
            public bool Contains(T item) => IndexOf(item) != -1;

           
            public int IndexOf(T item)
            {
                for (int i = 0; i < _size; i++)
                {
                    if (Equals(_items[i], item)) return i;
                }
                return -1;
            }
        public int FirstIndexOf(T item)
        {
            for (int i = 0; i < _size; i++)
            {
                if (Equals(_items[i], item)) return i;
            }
            return -1;
        }

       
        public int LastIndexOf(T item)
            {
                for (int i = _size - 1; i >= 0; i--)
                {
                    if (Equals(_items[i], item)) return i;
                }
                return -1;
            }

           
            public void RemoveAt(int index)
            {
                if (index < 0 || index >= _size) throw new IndexOutOfRangeException();

                int shiftCount = _size - index - 1;
                if (shiftCount > 0)
                {
                    Array.Copy(_items, index + 1, _items, index, shiftCount);
                }
                _size--;
                _items[_size] = default(T); 
            }

           
            public bool Remove(T item)
            {
                int index = IndexOf(item);
                if (index >= 0)
                {
                    RemoveAt(index);
                    return true;
                }
                return false;
            }

           
            public void Clear()
            {
                Array.Clear(_items, 0, _size);
                _size = 0;
            }

            public void Reverse()
            {
                for (int i = 0; i < _size / 2; i++)
                {
                    T temp = _items[i];
                    _items[i] = _items[_size - 1 - i];
                    _items[_size - 1 - i] = temp;
                }
            }

           
            public void TrimExcess()
            {
                if (_size < _capacity)
                {
                    Resize(_size);
                }
            }

            private void Resize(int newCapacity)
            {
                if (newCapacity < _size) newCapacity = _size;
                T[] newDataArray = new T[newCapacity];
                Array.Copy(_items, 0, newDataArray, 0, _size);
                _capacity = newCapacity;
                _items = newDataArray;
            }
        }
    }
