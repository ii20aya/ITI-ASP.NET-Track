using System;
using System.Linq;
using Xunit;
using QuickSortApp.Algorithms;

namespace QuickSortApp.Tests
{
    /// <summary>
    /// xUnit test suite for QuickSort (Recursive & Iterative).
    /// Generated with GitHub Copilot assistance.
    ///
    /// SCENARIOS COVERED:
    ///  1. Null array          — should not throw
    ///  2. Empty array         — unchanged
    ///  3. Single element      — unchanged
    ///  4. Already sorted      — correct
    ///  5. Reverse sorted      — correct (worst-case for naive pivot)
    ///  6. Duplicates          — correct
    ///  7. All identical       — correct
    ///  8. Negative numbers    — correct
    ///  9. Mixed neg/pos       — correct
    /// 10. Large random array  — matches Array.Sort reference
    /// 11. Two-element arrays  — both orders
    /// 12. OtherSorters tests  — MergeSort, HeapSort, BuiltIn
    /// </summary>
    public class QuickSortTests
    {
        // ── Helpers ──────────────────────────────────────────────

        /// <summary>Runs both recursive and iterative and asserts both match expected.</summary>
        private static void AssertBothSort(int[] input, int[] expected)
        {
            int[] rec = (int[])input.Clone();
            int[] itr = (int[])input.Clone();

            QuickSort.RecursiveSort(rec);
            QuickSort.IterativeSort(itr);

            Assert.Equal(expected, rec);
            Assert.Equal(expected, itr);
        }

        private static int[] Sorted(int[] arr)
        {
            int[] copy = (int[])arr.Clone();
            Array.Sort(copy);
            return copy;
        }

        // ── NULL / EMPTY / SINGLE ─────────────────────────────────

        [Fact]
        public void RecursiveSort_NullArray_DoesNotThrow()
        {
            var ex = Record.Exception(() => QuickSort.RecursiveSort(null!));
            Assert.Null(ex);
        }

        [Fact]
        public void IterativeSort_NullArray_DoesNotThrow()
        {
            var ex = Record.Exception(() => QuickSort.IterativeSort(null!));
            Assert.Null(ex);
        }

        [Fact]
        public void Sort_EmptyArray_RemainsEmpty()
        {
            AssertBothSort([], []);
        }

        [Fact]
        public void Sort_SingleElement_Unchanged()
        {
            AssertBothSort([42], [42]);
        }

        // ── BASIC SCENARIOS ───────────────────────────────────────

        [Fact]
        public void Sort_TwoElements_Ascending()
        {
            AssertBothSort([2, 1], [1, 2]);
        }

        [Fact]
        public void Sort_TwoElements_AlreadySorted()
        {
            AssertBothSort([1, 2], [1, 2]);
        }

        [Fact]
        public void Sort_AlreadySortedArray_Correct()
        {
            int[] arr = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
            AssertBothSort(arr, arr);
        }

        [Fact]
        public void Sort_ReverseSortedArray_Correct()
        {
            AssertBothSort([10, 9, 8, 7, 6, 5, 4, 3, 2, 1],
                           [1,  2, 3, 4, 5, 6, 7, 8, 9, 10]);
        }

        [Fact]
        public void Sort_RandomSmallArray_Correct()
        {
            int[] arr = [64, 34, 25, 12, 22, 11, 90];
            AssertBothSort(arr, Sorted(arr));
        }

        // ── EDGE CASES ────────────────────────────────────────────

        [Fact]
        public void Sort_AllDuplicates_Correct()
        {
            AssertBothSort([5, 5, 5, 5, 5], [5, 5, 5, 5, 5]);
        }

        [Fact]
        public void Sort_ArrayWithDuplicates_Correct()
        {
            int[] arr = [3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5];
            AssertBothSort(arr, Sorted(arr));
        }

        [Fact]
        public void Sort_NegativeNumbers_Correct()
        {
            int[] arr = [-5, -1, -3, -2, -4];
            AssertBothSort(arr, Sorted(arr));
        }

        [Fact]
        public void Sort_MixedNegativeAndPositive_Correct()
        {
            int[] arr = [-10, 5, -3, 0, 8, -1, 7];
            AssertBothSort(arr, Sorted(arr));
        }

        [Fact]
        public void Sort_AllZeros_Correct()
        {
            AssertBothSort([0, 0, 0], [0, 0, 0]);
        }

        [Fact]
        public void Sort_MinMaxInt_Correct()
        {
            int[] arr = [int.MaxValue, 0, int.MinValue, 1, -1];
            AssertBothSort(arr, Sorted(arr));
        }

        // ── LARGE ARRAY ───────────────────────────────────────────

        [Fact]
        public void Sort_LargeRandomArray_MatchesArraySort()
        {
            var rng = new Random(123);
            int[] arr = Enumerable.Range(0, 10_000)
                                  .Select(_ => rng.Next(-50_000, 50_000))
                                  .ToArray();

            int[] reference = Sorted(arr);
            AssertBothSort(arr, reference);
        }

        // ── BENCHMARK BASIC CHECK ──────────────────────────────────

        [Fact]
        public void Benchmark_ReturnsPositiveElapsedTime()
        {
            int[] arr = [3, 1, 4, 1, 5, 9];
            double ms = QuickSort.Benchmark(() => QuickSort.RecursiveSort(arr));
            Assert.True(ms >= 0);
        }
    }

    // ── OTHER SORTERS ─────────────────────────────────────────────

    public class OtherSortersTests
    {
        private static int[] Sorted(int[] arr)
        {
            int[] copy = (int[])arr.Clone();
            Array.Sort(copy);
            return copy;
        }

        [Theory]
        [InlineData(new int[] { })]
        [InlineData(new int[] { 1 })]
        [InlineData(new int[] { 3, 1, 2 })]
        [InlineData(new int[] { 5, 4, 3, 2, 1 })]
        [InlineData(new int[] { 1, 1, 1, 1 })]
        public void MergeSort_VariousInputs_Correct(int[] arr)
        {
            int[] expected = Sorted(arr);
            OtherSorters.MergeSort(arr);
            Assert.Equal(expected, arr);
        }

        [Theory]
        [InlineData(new int[] { })]
        [InlineData(new int[] { 42 })]
        [InlineData(new int[] { 9, 5, 3, 7, 1 })]
        [InlineData(new int[] { -5, 0, 5 })]
        public void HeapSort_VariousInputs_Correct(int[] arr)
        {
            int[] expected = Sorted(arr);
            OtherSorters.HeapSort(arr);
            Assert.Equal(expected, arr);
        }

        [Fact]
        public void BuiltInSort_LargeArray_Correct()
        {
            var rng = new Random(999);
            int[] arr = Enumerable.Range(0, 5_000).Select(_ => rng.Next()).ToArray();
            int[] expected = Sorted(arr);
            OtherSorters.BuiltInSort(arr);
            Assert.Equal(expected, arr);
        }
    }
}
