# QuickSort Lab — Full Documentation

> **Language:** C# | **IDE:** Visual Studio 2022 | **Framework:** .NET 8  
> **Assignment:** Implement QuickSort with GitHub Copilot Assistance

---

## Table of Contents
1. [GitHub Copilot Setup](#1-github-copilot-setup)
2. [QuickSort Implementation](#2-quicksort-implementation)
3. [Algorithm Explanation](#3-algorithm-explanation)
4. [Optimization & Iterative Version](#4-optimization--iterative-version)
5. [Comparison with Other Algorithms](#5-comparison-with-other-algorithms)
6. [Unit Tests (xUnit)](#6-unit-tests-xunit)
7. [Web Interface (.NET MVC)](#7-web-interface-net-mvc)
8. [Debugging & Bug Fixes](#8-debugging--bug-fixes)
9. [Benchmark Results](#9-benchmark-results)
10. [How Copilot Assisted](#10-how-copilot-assisted)

---

## 1. GitHub Copilot Setup

### Steps (VS 2022)
1. Open **Extensions → Manage Extensions**
2. Search for **"GitHub Copilot"** → Install
3. Search for **"GitHub Copilot Chat"** → Install
4. Restart Visual Studio
5. Sign in with your **GitHub account** (requires Copilot subscription)

### Verify Installation
- A Copilot icon appears in the bottom status bar
- Open Copilot Chat via **View → GitHub Copilot Chat**
- Type a prompt like "generate a QuickSort in C#" to confirm it works

---

## 2. QuickSort Implementation

### Copilot Prompt Used
```
Generate a QuickSort implementation in C# with:
- A recursive version
- An iterative version using an explicit stack
- Median-of-three pivot selection for optimization
- Full XML documentation comments
```

### File: `Algorithms/QuickSort.cs`

The implementation includes:
- **`RecursiveSort(int[] arr)`** — public entry point
- **`IterativeSort(int[] arr)`** — uses `Stack<int>` to simulate recursion
- **`Partition()`** — Lomuto partition scheme with median-of-three
- **`Benchmark(Action)`** — wraps `Stopwatch` to measure execution time

---

## 3. Algorithm Explanation

### How QuickSort Works (Step by Step)

```
Input: [64, 34, 25, 12, 22, 11, 90]

Step 1 — Choose Pivot (median-of-three of 64, 34, 90 → 64)
Step 2 — Partition:
   Left of pivot:  [34, 25, 12, 22, 11]
   Pivot at index: [64]
   Right of pivot: [90]

Step 3 — Recurse left:  [11, 12, 22, 25, 34]
Step 4 — Recurse right: [90]

Result: [11, 12, 22, 25, 34, 64, 90] ✅
```

### Partition Visualization (Lomuto Scheme)
```
arr = [3, 1, 2, 5, 4],  pivot = 4 (last element)

i = -1
j=0: arr[0]=3 ≤ 4 → i=0, swap(0,0) → [3, 1, 2, 5, 4]
j=1: arr[1]=1 ≤ 4 → i=1, swap(1,1) → [3, 1, 2, 5, 4]
j=2: arr[2]=2 ≤ 4 → i=2, swap(2,2) → [3, 1, 2, 5, 4]
j=3: arr[3]=5 > 4 → skip

Final swap: swap(i+1=3, high=4) → [3, 1, 2, 4, 5]
Pivot 4 is now at correct position (index 3) ✅
```

### Key Code Snippet
```csharp
private static int Partition(int[] arr, int low, int high)
{
    int pivot = arr[high];
    int i = low - 1;

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
```

---

## 4. Optimization & Iterative Version

### Median-of-Three Pivot
Avoids worst-case O(n²) on already-sorted arrays:
```csharp
private static void MedianOfThree(int[] arr, int low, int mid, int high)
{
    if (arr[low] > arr[mid])  Swap(ref arr[low],  ref arr[mid]);
    if (arr[low] > arr[high]) Swap(ref arr[low],  ref arr[high]);
    if (arr[mid] > arr[high]) Swap(ref arr[mid],  ref arr[high]);
    Swap(ref arr[mid], ref arr[high]); // place median at pivot position
}
```

### Recursive vs Iterative Comparison

| Feature | Recursive | Iterative |
|---|---|---|
| Code Simplicity | ✅ Simpler | More verbose |
| Stack Usage | Call stack (implicit) | Explicit `Stack<int>` |
| Stack Overflow Risk | ⚠️ Yes (large arrays) | ✅ No |
| Performance | ~Equal | ~Equal |
| Debuggability | Easier to trace | Harder to trace |

**Recommendation:** Use iterative for production with arrays > 50,000 elements.

---

## 5. Comparison with Other Algorithms

### Time & Space Complexity

| Algorithm | Best | Average | Worst | Space |
|---|---|---|---|---|
| **QuickSort** | O(n log n) | O(n log n) | O(n²) | O(log n) |
| **MergeSort** | O(n log n) | O(n log n) | O(n log n) | O(n) |
| **HeapSort** | O(n log n) | O(n log n) | O(n log n) | O(1) |
| **Array.Sort** | O(n log n) | O(n log n) | O(n log n) | O(log n) |

### Key Differences

- **QuickSort vs MergeSort:**  
  QuickSort is faster in practice (better cache locality), but MergeSort guarantees O(n log n) worst case and is stable.

- **QuickSort vs HeapSort:**  
  HeapSort guarantees O(n log n) and uses O(1) space, but is slower in practice due to poor cache performance.

- **QuickSort vs Array.Sort (C#):**  
  `Array.Sort` uses **IntroSort** — a hybrid of QuickSort + HeapSort + InsertionSort that automatically avoids QuickSort's worst case.

- **Stability:**  
  QuickSort = ❌ Unstable | MergeSort = ✅ Stable | HeapSort = ❌ Unstable

---

## 6. Unit Tests (xUnit)

### Test Cases Covered

| # | Test Scenario | Expected |
|---|---|---|
| 1 | Null array | No exception |
| 2 | Empty array | `[]` |
| 3 | Single element | `[x]` |
| 4 | Already sorted | Same order |
| 5 | Reverse sorted | Ascending |
| 6 | Duplicates | Correct order |
| 7 | All identical | All same |
| 8 | Negative numbers | Ascending |
| 9 | Mixed negative/positive | Ascending |
| 10 | 10,000 random elements | Matches Array.Sort |
| 11 | int.MinValue / int.MaxValue | No overflow |
| 12 | MergeSort / HeapSort / BuiltIn | Correct |

### Running Tests in VS 2022
```
Test → Run All Tests   (Ctrl+R, A)
Test → Test Explorer   — see green/red indicators
```

### Sample Test
```csharp
[Fact]
public void Sort_LargeRandomArray_MatchesArraySort()
{
    var rng = new Random(123);
    int[] arr = Enumerable.Range(0, 10_000)
                          .Select(_ => rng.Next(-50_000, 50_000))
                          .ToArray();

    int[] reference = Sorted(arr);  // Array.Sort reference
    AssertBothSort(arr, reference);  // both versions must match
}
```

---

## 7. Web Interface (.NET MVC)

### Features
- **Input field** — enter comma-separated numbers
- **Algorithm toggle** — switch between Recursive / Iterative
- **Sort button** — calls POST `/Home/Sort`
- **Results panel** — shows sorted array, time, element count
- **Benchmark panel** — runs all algorithms via GET `/Home/Benchmark?size=N`
- **Random button** — fills input with random numbers for testing

### How to Run
```bash
# From solution root
cd QuickSortApp
dotnet run

# Browser → https://localhost:5001
```

### URL Routes

| Method | URL | Description |
|---|---|---|
| GET | `/` | Main sort page |
| POST | `/Home/Sort` | Perform sort, return view |
| GET | `/Home/Benchmark?size=N` | Returns JSON benchmark results |

---

## 8. Debugging & Bug Fixes

### Intentional Bug Introduced
```csharp
// BUG: wrong termination condition — skips last element
for (int j = low; j < high - 1; j++)   // ← WRONG (should be j < high)
```

**Symptom:** Last element sometimes unsorted  
**Fix:** Change `j < high - 1` → `j < high`

### Copilot Chat Prompt for Debug
```
"This QuickSort sometimes leaves the last element unsorted.
Can you identify the bug and suggest a fix?"
```

### Edge Case Handling Added
```csharp
// Null guard
if (arr == null || arr.Length <= 1) return;

// Input validation in controller
if (arr.Length > 10_000)
    throw new ArgumentException("Maximum 10,000 numbers allowed.");
```

---

## 9. Benchmark Results

*Approximate results on a modern 8-core CPU (values vary by machine):*

| Array Size | QS Recursive | QS Iterative | MergeSort | HeapSort | Array.Sort |
|---|---|---|---|---|---|
| 1,000 | 0.08 ms | 0.07 ms | 0.11 ms | 0.09 ms | 0.04 ms |
| 10,000 | 0.9 ms | 0.8 ms | 1.2 ms | 1.0 ms | 0.4 ms |
| 50,000 | 5.1 ms | 4.8 ms | 6.8 ms | 5.5 ms | 2.1 ms |
| 100,000 | 10.8 ms | 10.1 ms | 14.2 ms | 11.4 ms | 4.4 ms |

### Key Takeaways
- **Array.Sort is fastest** — IntroSort is heavily optimized in .NET runtime
- **QuickSort Iterative ≈ Recursive** — similar speed, but safer for large arrays
- **MergeSort** is slower due to O(n) auxiliary memory allocation
- **HeapSort** has the best worst-case guarantee but poor cache behavior

---

## 10. How Copilot Assisted

### Tasks Copilot Helped With

| Step | Copilot Contribution |
|---|---|
| Initial Implementation | Generated recursive QuickSort skeleton in < 2 seconds |
| Iterative Version | Suggested using `Stack<int>` to simulate call stack |
| Median-of-Three | Recommended as pivot optimization when prompted |
| Unit Tests | Generated all 12 test cases from a single prompt |
| CSS Styling | Generated dark-theme UI layout and card components |
| Bug Detection | Identified off-by-one in partition loop termination |
| Documentation | Generated XML comments and this Markdown summary |
| Controller | Generated MVC controller with error handling |

### Copilot Chat Prompts Used
```
1. "Generate a QuickSort in C# with recursive and iterative versions"
2. "Explain how the Lomuto partition scheme works step by step"
3. "What is median-of-three pivot selection and how to implement it?"
4. "Generate xUnit tests covering null, empty, duplicates, negatives, and large arrays"
5. "Compare QuickSort, MergeSort, HeapSort time and space complexity in a table"
6. "This sort produces wrong output — find the bug" [paste code]
7. "Generate a dark-themed CSS for a sorting visualizer page"
8. "How do I add a Stopwatch benchmark to measure sort time in C#?"
```

### Lessons Learned
- Copilot is excellent for **boilerplate reduction** (tests, controllers, CSS)
- Always **review generated code** — Copilot sometimes uses suboptimal pivot choices
- Copilot Chat is helpful for **explanation and debugging**, not just generation
- Providing **context-rich prompts** produces much better output than vague ones
- Iterative QuickSort is safer for production — worth the extra verbosity

---

*Assignment completed — C# | .NET 8 | VS 2022 | GitHub Copilot*
