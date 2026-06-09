using System.ComponentModel.DataAnnotations;

namespace QuickSortApp.Models
{
    public class SortViewModel
    {
        [Required(ErrorMessage = "Please enter numbers to sort.")]
        [Display(Name = "Numbers (comma-separated)")]
        public string InputNumbers { get; set; } = string.Empty;

        public bool   UseIterative  { get; set; } = false;
        public string SortedNumbers { get; set; } = string.Empty;
        public double ElapsedMs     { get; set; }
        public int    InputCount    { get; set; }
        public bool   Success       { get; set; }
        public string ErrorMessage  { get; set; } = string.Empty;
    }
}
