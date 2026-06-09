using ComplaintSystem.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplaintSystem.Models
{
    public class Complaint
    {
        public int Id { get; set; }

        public string? UserId { get; set; }
        public string Title { get; set; } = string.Empty;

        
        public string Description { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

   
        public ComplaintStatus Status { get; set; } = ComplaintStatus.Pending;

      
        public int CategoryId { get; set; }


        [ForeignKey(nameof(CategoryId))]
        public Category? Category { get; set; }

        public ICollection<Reply> Replies { get; set; } = new List<Reply>();
    }
}