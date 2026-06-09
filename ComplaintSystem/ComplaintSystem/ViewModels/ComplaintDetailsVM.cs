using ComplaintSystem.Models.Enum;

namespace ComplaintSystem.ViewModels
{
    public class ComplaintDetailsVM
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ComplaintStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string? CategoryImageUrl { get; set; }
        public List<ReplyVM> Replies { get; set; } = new();

        // Sub-form for adding a new reply
        public AddReplyVM NewReply { get; set; } = new();
    }
}
