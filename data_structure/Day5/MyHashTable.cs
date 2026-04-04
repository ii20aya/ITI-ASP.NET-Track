using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public class MyHashTable<TKey, TValue>
    {
        private List<List<TableData<TKey, TValue>>> _table;
        private int _capacity;
        private int _count;
        private const double LOAD_FACTOR_THRESHOLD = 0.7;

        public MyHashTable(int capacity = 10)
        {
            _capacity = capacity;
            _count = 0;
            _table = new List<List<TableData<TKey, TValue>>>(_capacity);
            InitializeTable(_table, _capacity);
        }

        private void InitializeTable(List<List<TableData<TKey, TValue>>> table, int capacity)
        {
            for (int i = 0; i < capacity; i++)
                table.Add(new List<TableData<TKey, TValue>>());
        }

        private int GetIndex(TKey key, int capacity)
        {
            int hash = key.GetHashCode();
            return Math.Abs(hash) % capacity;
        }

       
        public void Add(TKey key, TValue value)
        {
            if ((double)_count / _capacity >= LOAD_FACTOR_THRESHOLD)
            {
                Rehash();
            }

            int index = GetIndex(key, _capacity);
            var bucket = _table[index];

            foreach (var item in bucket)
            {
                if (item.Key.Equals(key))
                    throw new ArgumentException("Key already exists.");
            }

            bucket.Add(new TableData<TKey, TValue>(key, value));
            _count++;
        }

      
        public TValue Get(TKey key)
        {
            int index = GetIndex(key, _capacity);
            foreach (var item in _table[index])
            {
                if (item.Key.Equals(key)) return item.Value;
            }
            throw new KeyNotFoundException();
        }

        
        public bool Contains(TKey key)
        {
            int index = GetIndex(key, _capacity);
            foreach (var item in _table[index])
            {
                if (item.Key.Equals(key)) return true;
            }
            return false;
        }

        
        public bool Remove(TKey key)
        {
            int index = GetIndex(key, _capacity);
            var bucket = _table[index];
            for (int i = 0; i < bucket.Count; i++)
            {
                if (bucket[i].Key.Equals(key))
                {
                    bucket.RemoveAt(i);
                    _count--;
                    return true;
                }
            }
            return false;
        }

    
        private void Rehash()
        {
            int newCapacity = _capacity * 2;
            var newTable = new List<List<TableData<TKey, TValue>>>(newCapacity);
            InitializeTable(newTable, newCapacity);

          
            foreach (var bucket in _table)
            {
                foreach (var item in bucket)
                {
                    int newIndex = GetIndex(item.Key, newCapacity);
                    newTable[newIndex].Add(item);
                }
            }

            _capacity = newCapacity;
            _table = newTable;
            Console.WriteLine($"Rehashed! New Capacity: {_capacity}");
        }
    }
}
