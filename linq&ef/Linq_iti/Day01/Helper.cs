using System;
using System.Collections.Generic;
using System.Text;

namespace Linq
{
    public static class Helper
    {
        // where 
        // genric method
        // extension method
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> list, Predicate<T> pFilter)
        {
            List<T> result = new List<T>();
            // loop on list 
            // item return true from pFilter => add to result
            foreach(var item in list)
            {
                if (pFilter(item))
                    result.Add(item);
            }
            // child to parent
            return result;

        }
    }
}
