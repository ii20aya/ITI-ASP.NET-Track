using ComplaintSystem.Models;
using ComplaintSystem.Models.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace ComplaintSystem.Data
    
{
    //1
    //onmodel builder -> fluent api
    //.hasdata() -> seed data



    //2
 

    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
          
            if (context.Categories.Any()) return;

       //catg
            var categories = new List<Category>
            {
                new() { Name = "Technical Issue",    Description = "Problems with software, hardware, or IT systems",    ImageUrl = "/images/categories/technical.png"  },
                new() { Name = "Billing",            Description = "Issues with payments, invoices, or charges",          ImageUrl = "/images/categories/billing.png"    },
                new() { Name = "Customer Service",   Description = "Complaints about staff behavior or service quality",  ImageUrl = "/images/categories/service.png"    },
                new() { Name = "Product Quality",    Description = "Defects or poor quality in delivered products",       ImageUrl = "/images/categories/product.png"    },
                new() { Name = "Delivery",           Description = "Shipment delays, wrong items, or lost packages",      ImageUrl = "/images/categories/delivery.png"   },
            };

            context.Categories.AddRange(categories);
            context.SaveChanges();

            //  Complaints 
            var complaints = new List<Complaint>
            {
                new()
                {
                    Title       = "System crashes every morning at 8 AM",
                    Description = "The application crashes every morning between 8–9 AM, causing major delays. Restarting the server temporarily fixes it, but the issue recurs next day.",
                    Status      = ComplaintStatus.InProgress,
                    CategoryId  = categories[0].Id,
                    CreatedAt   = DateTime.UtcNow.AddDays(-5)
                },
                new()
                {
                    Title       = "Double charged for monthly subscription",
                    Description = "I was charged twice for my October subscription. Bank statement clearly shows two separate transactions on the same date.",
                    Status      = ComplaintStatus.Pending,
                    CategoryId  = categories[1].Id,
                    CreatedAt   = DateTime.UtcNow.AddDays(-3)
                },
                new()
                {
                    Title       = "Rude support representative",
                    Description = "The support agent I spoke with on Tuesday was dismissive and refused to escalate the issue when asked. Very unprofessional.",
                    Status      = ComplaintStatus.Resolved,
                    CategoryId  = categories[2].Id,
                    CreatedAt   = DateTime.UtcNow.AddDays(-10)
                },
                new()
                {
                    Title       = "Product arrived with cracked screen",
                    Description = "The tablet I ordered arrived in a crushed box with a completely cracked screen. Clearly inadequate packaging.",
                    Status      = ComplaintStatus.Pending,
                    CategoryId  = categories[3].Id,
                    CreatedAt   = DateTime.UtcNow.AddDays(-1)
                },
                new()
                {
                    Title       = "Package not delivered after 2 weeks",
                    Description = "My order was placed 14 days ago. Tracking shows it has been stuck at the same facility for 10 days with no update.",
                    Status      = ComplaintStatus.Rejected,
                    CategoryId  = categories[4].Id,
                    CreatedAt   = DateTime.UtcNow.AddDays(-14)
                },
            };

            context.Complaints.AddRange(complaints);
            context.SaveChanges();

            //  Replies 
            var replies = new List<Reply>
            {
                new() { Content = "We have notified the technical team. Investigation is underway.",              ComplaintId = complaints[0].Id, CreatedAt = DateTime.UtcNow.AddDays(-4) },
                new() { Content = "Root cause identified — a scheduled job was consuming all memory. Fix deployed.", ComplaintId = complaints[0].Id, CreatedAt = DateTime.UtcNow.AddDays(-2) },
                new() { Content = "Confirmed. A refund for the duplicate charge will appear within 3–5 business days.", ComplaintId = complaints[1].Id, CreatedAt = DateTime.UtcNow.AddDays(-2) },
                new() { Content = "We sincerely apologize. The agent has been addressed and this case is now closed.",  ComplaintId = complaints[2].Id, CreatedAt = DateTime.UtcNow.AddDays(-8) },
            };

            context.Replies.AddRange(replies);
            context.SaveChanges();
        }

        public static async Task SeedAdminAsync(/*AppDbContext context*/ IServiceProvider services)
        {
            //    var roleManager = new RoleManager<IdentityRole>(
            //        new RoleStore<IdentityRole>(context),
            //        null, null, null, null);
            //var userManager = new UserManager<ApplicationUser>(
            //        new UserStore<ApplicationUser>(context),
            //        null, null, null, null, null, null, null, null);
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

            string[] roles = { "Admin", "User" };
            foreach (var role in roles)
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));

            const string adminEmail = "admin@complaintsystem.com";
            const string adminPass = "Admin@123456";

            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var admin = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FullName = "System Admin",
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(admin, adminPass);
                await userManager.AddToRoleAsync(admin, "Admin");
            }
        }

    }
}