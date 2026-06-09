using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace QuickSortApp.Algorithms
{
    /// <summary>
    /// QuickSort Algorithm Implementation
    /// Provides both Recursive and Iterative versions with benchmarking support.
    ///
    /// HOW QUICKSORT WORKS:
    /// 1. Pick a "pivot" element from the array.
    /// 2. Partition: move elements smaller than pivot to left, larger to right.
    /// 3. Recursively apply the same process to both sub-arrays.
    /// 4. Base case: arrays of size 0 or 1 are already sorted.
    ///
    /// TIME COMPLEXITY:
    ///   Best Case:    O(n log n) - pivot always divides array in half
    ///   Average Case: O(n log n) - random pivot
    ///   Worst Case:   O(n²)     - already sorted array with first element as pivot
    ///
    /// SPACE COMPLEXITY:
    ///   Recursive: O(log n) average (call stack)
    ///   Iterative: O(log n) explicit stack
    /// </summary>
    public static class QuickSort
    {
        // ─────────────────────────────────────────────────────────
        //  RECURSIVE VERSION
        // ─────────────────────────────────────────────────────────

        /// <summary>
        /// Public entry point for recursive QuickSort.
        /// </summary>
        public static void RecursiveSort(int[] arr)
        {
            if (arr == null || arr.Length <= 1) return;
            RecursiveSort(arr, 0, arr.Length - 1);
        }

        private static void RecursiveSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                // pi = partition index; arr[pi] is now in correct position
                int pi = Partition(arr, low, high);

                // Sort left sub-array (elements < pivot)
                RecursiveSort(arr, low, pi - 1);

                // Sort right sub-array (elements > pivot)
                RecursiveSort(arr, pi + 1, high);
            }
        }

        // ─────────────────────────────────────────────────────────
        //  ITERATIVE VERSION (avoids stack-overflow on large arrays)
        // ─────────────────────────────────────────────────────────

        /// <summary>
        /// Iterative QuickSort using an explicit stack.
        /// Eliminates recursion depth limitations.
        /// </summary>
        public static void IterativeSort(int[] arr)
        {
            if (arr == null || arr.Length <= 1) return;

            int n = arr.Length;
            Stack<int> stack = new Stack<int>();

            // Push initial low and high
            stack.Push(0);
            stack.Push(n - 1);

            while (stack.Count > 0)
            {
                int high = stack.Pop();
                int low  = stack.Pop();

                if (low < high)
                {
                    int pi = Partition(arr, low, high);

                    // Push left sub-array bounds
                    if (pi - 1 > low)
                    {
                        stack.Push(low);
                        stack.Push(pi - 1);
                    }

                    // Push right sub-array bounds
                    if (pi + 1 < high)
                    {
                        stack.Push(pi + 1);
                        stack.Push(high);
                    }
                }
            }
        }

        // ─────────────────────────────────────────────────────────
        //  PARTITION (shared by both versions)
        // ─────────────────────────────────────────────────────────

        /// <summary>
        /// Lomuto Partition Scheme.
        /// Chooses last element as pivot.
        /// Moves all smaller elements to the left of pivot.
        /// Returns the final index of the pivot.
        /// </summary>
        private static int Partition(int[] arr, int low, int high)
        {
            // Use median-of-three to pick a better pivot (optimization)
            int mid = low + (high - low) / 2;
            MedianOfThree(arr, low, mid, high);

            int pivot = arr[high];
            int i = low - 1; // index of smaller element

            for (int j = low; j < high; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;
                    Swap(ref arr[i], ref arr[j]);
                }
            }

            Swap(ref arr[i + 1], ref arr[high]);
            return i + 1;
        }

        /// <summary>
        /// Median-of-Three optimization: pick median of arr[low], arr[mid], arr[high]
        /// and place it at arr[high] so Partition uses it as pivot.
        /// Significantly reduces worst-case scenarios.
        /// </summary>
        private static void MedianOfThree(int[] arr, int low, int mid, int high)
        {
            if (arr[low] > arr[mid])  Swap(ref arr[low],  ref arr[mid]);
            if (arr[low] > arr[high]) Swap(ref arr[low],  ref arr[high]);
            if (arr[mid] > arr[high]) Swap(ref arr[mid],  ref arr[high]);
            // arr[mid] is now the median → move it to high-1 as pivot
            Swap(ref arr[mid], ref arr[high]);
        }

        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        // ─────────────────────────────────────────────────────────
        //  BENCHMARKING
        // ─────────────────────────────────────────────────────────

        /// <summary>
        /// Measures execution time of any sort action in milliseconds.
        /// </summary>
        public static double Benchmark(Action sortAction)
        {
            var sw = Stopwatch.StartNew();
            sortAction();
            sw.Stop();
            return sw.Elapsed.TotalMilliseconds;
        }
    }
}
