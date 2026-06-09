using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day03
{
   
    internal static class Utilities
    {
        /// <summary>
        /// Finds the maximum value among a set of provided values.
        /// </summary>
        /// <typeparam name="T">The type of elements, must implement IComparable.</typeparam>
        /// <param name="values">A variable number of arguments to compare.</param>
        /// <returns>The maximum value found.</returns>
        public static T Max<T>(params T[] values) where T : IComparable<T>
        {
            if (values == null || values.Length == 0)
                throw new ArgumentException("At least one value must be provided.");

            T max = values[0];
            foreach (var item in values)
            {
                if (item.CompareTo(max) > 0)
                    max = item;
            }
            return max;
        }

        /// <summary>
        /// Attempts to parse a string into the specified type T.
        /// </summary>
        /// <typeparam name="T">The target type for conversion.</typeparam>
        /// <param name="input">The string to parse.</param>
        /// <param name="result">The parsed value if successful; otherwise, the default value of T.</param>
        /// <returns>True if parsing succeeded; otherwise, false.</returns>
        public static bool TryParse<T>(string input, out T? result)
        {
            try
            {
                result = (T?)Convert.ChangeType(input, typeof(T));
                return true;
            }
            catch
            {
                result = default;
                return false;
            }
        }
    }
}