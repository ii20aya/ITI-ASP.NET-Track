using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplaintSystem.Models
{
    public class Reply
    {
        public int Id { get; set; }

      
        public string Content { get; set; } = string.Empty;

      
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

 
        [Required]
        public int ComplaintId { get; set; }

        [ForeignKey(nameof(ComplaintId))]
        public Complaint? Complaint { get; set; }
    }
}