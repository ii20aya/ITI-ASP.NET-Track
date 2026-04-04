using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day02
{
    class BinarySearch
    {
        // Iterative Binary Search
        public static int BinarySearchIterative(Employee[] arr, DateTime target)
        {
            int left = 0;
            int right = arr.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (arr[mid].HireDate == target)
                {
                    return mid;
                }

                else if (arr[mid].HireDate < target)
                {
                    left = mid + 1;
                }

                else
                {
                    right = mid - 1;
                }
            }

            return -1;
        }

        // Recursive Binary Search
        public static int BinarySearchRecursive(Employee[] arr, DateTime target, int left, int right)
        {
            if (left > right)
                return -1;

            int mid = (left + right) / 2;

            if (arr[mid].HireDate == target)
                return mid;

            if (arr[mid].HireDate < target)
                return BinarySearchRecursive(arr, target, mid + 1, right);

            else
                return BinarySearchRecursive(arr, target, left, mid - 1);
        }
    }
}
