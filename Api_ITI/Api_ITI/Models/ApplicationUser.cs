
using Microsoft.AspNetCore.Identity;
using System.Globalization;

namespace Api_ITI.Models
{
  
    public class ApplicationUser : IdentityUser
    {
      
        public string? FullName { get; set; }

      
    }
}
