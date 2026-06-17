using System.ComponentModel.DataAnnotations;

namespace Api_ITI.DTOs
{
    public class EmployeeCreateDTO
    {
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [MaxLength(100)]
        public string Position { get; set; }

        [MaxLength(100)]
        public string Department { get; set; }

        [Required]
        public int ProjectId { get; set; }  
}
    }