using Microsoft.AspNetCore.Mvc;
using QuickSortApp.Algorithms;
using QuickSortApp.Models;
using System;
using System.Linq;

namespace QuickSortApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly BenchmarkService _benchmark = new BenchmarkService();

        // GET: /
        public IActionResult Index()
        {
            return View(new SortViewModel());
        }

        // POST: /Sort
        [HttpPost]
        public IActionResult Sort(SortViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Index", model);

            try
            {
                // Parse input string "3,1,4,1,5,9" → int[]
                int[] arr = model.InputNumbers
                    .Split(new[] { ',', ' ', ';' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s =>
                    {
                        if (!int.TryParse(s.Trim(), out int v))
                            throw new FormatException($"'{s.Trim()}' is not a valid integer.");
                        return v;
                    })
                    .ToArray();

                if (arr.Length == 0)
                    throw new ArgumentException("Please enter at least one number.");

                if (arr.Length > 10_000)
                    throw new ArgumentException("Maximum 10,000 numbers allowed.");

                int[] working = (int[])arr.Clone();

                double ms = QuickSort.Benchmark(() =>
                {
                    if (model.UseIterative)
                        QuickSort.IterativeSort(working);
                    else
                        QuickSort.RecursiveSort(working);
                });

                model.SortedNumbers = string.Join(", ", working);
                model.ElapsedMs     = ms;
                model.InputCount    = arr.Length;
                model.Success       = true;
            }
            catch (Exception ex)
            {
                model.ErrorMessage = ex.Message;
            }

            return View("Index", model);
        }

        // GET: /Benchmark?size=10000
        public IActionResult Benchmark(int size = 10_000)
        {
            if (size < 10)    size = 10;
            if (size > 500_000) size = 500_000;

            var result = _benchmark.Run(size);
            return Json(result);
        }

        // GET: /BenchmarkView
        public IActionResult BenchmarkView()
        {
            return View();
        }
    }
}
