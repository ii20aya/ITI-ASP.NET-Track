namespace ComplaintSystem.ViewModels
{
    public class ChatVM
    {
        public int ComplaintId { get; set; }
        public string ComplaintTitle { get; set; } = string.Empty;
        public IEnumerable<ComplaintSystem.Models.ChatMessage> History { get; set; }
            = Enumerable.Empty<ComplaintSystem.Models.ChatMessage>();
    }
}
