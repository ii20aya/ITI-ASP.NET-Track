using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public class TableData<TKey, TValue>
    {
        public TKey Key { get; private set; }
        public TValue Value { get; set; }

        public TableData(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }
}
