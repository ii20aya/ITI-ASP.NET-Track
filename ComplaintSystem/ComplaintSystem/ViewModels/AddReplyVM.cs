using System.ComponentModel.DataAnnotations;

namespace ComplaintSystem.ViewModels
{
    public class AddReplyVM
    {
        [Required(ErrorMessage = "Reply content is required")]
        [StringLength(1000, MinimumLength = 2,
            ErrorMessage = "Reply must be between 2 and 1000 characters")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; } = string.Empty;
        public int ComplaintId { get; set; }
    }
}
