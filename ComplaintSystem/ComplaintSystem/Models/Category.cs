using System.ComponentModel.DataAnnotations;

namespace ComplaintSystem.Models
{
    public class Category
    {
        public int Id { get; set; }

       
        public string Name { get; set; } = string.Empty;

       
        public string? Description { get; set; }

       
        public string? ImageUrl { get; set; }

     
        public ICollection<Complaint> Complaints { get; set; } = new List<Complaint>();
    }
}