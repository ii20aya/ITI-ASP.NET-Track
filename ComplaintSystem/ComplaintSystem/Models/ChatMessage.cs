namespace ComplaintSystem.Models
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public int ComplaintId { get; set; }
        public string SenderName { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime SentAt { get; set; }

        public Complaint? Complaint { get; set; }
    }
}
