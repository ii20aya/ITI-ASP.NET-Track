using ComplaintSystem.Models.Enum;



namespace ComplaintSystem.ViewModels
{

    public class ComplaintListItemVM
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public ComplaintStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string? CategoryImageUrl { get; set; }
        public int RepliesCount { get; set; }
    }
}