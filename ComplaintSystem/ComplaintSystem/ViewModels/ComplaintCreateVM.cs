using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ComplaintSystem.ViewModels
{
    public class ComplaintCreateVM
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(200, MinimumLength = 5,
            ErrorMessage = "Title must be between 5 and 200 characters")]
        // Remote validation: hits ComplaintController.IsTitleUnique via AJAX
        [Remote(action: "IsTitleUnique", controller: "Complaint",
            ErrorMessage = "A complaint with this title already exists.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        [StringLength(2000, MinimumLength = 10,
            ErrorMessage = "Description must be between 10 and 2000 characters")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a category")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        // Populated by the controller – never posted back
        public IEnumerable<SelectListItem>? Categories { get; set; }
    }

}
