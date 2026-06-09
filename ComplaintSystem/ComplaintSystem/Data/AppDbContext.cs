using ComplaintSystem.Models;
using ComplaintSystem.Models.Enum;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace ComplaintSystem.Data
{

  

    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

   
        public DbSet<ChatMessage> ChatMessages { get; set; }
 
        public DbSet<Category> Categories { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<Reply> Replies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.Property(c => c.Name)
                      .IsRequired()
                      .HasMaxLength(100);

               
                entity.HasIndex(c => c.Name)
                      .IsUnique()
                      .HasDatabaseName("IX_Category_Name_Unique"); //uniq index , fast seravhh

                entity.Property(c => c.Description)
                      .HasMaxLength(500);

                entity.Property(c => c.ImageUrl)
                      .HasMaxLength(500);
            });

            
            modelBuilder.Entity<Complaint>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.Property(c => c.Title)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(c => c.Description)
                      .IsRequired()
                      .HasMaxLength(2000);

                entity.Property(c => c.CreatedAt)
                      .IsRequired()
                      .HasDefaultValueSql("GETUTCDATE()");
                entity.Property(c => c.UpdatedAt)
                      .IsRequired(false);

                // Store enum as string  in DB
                entity.Property(c => c.Status)
                      .IsRequired()
                      .HasConversion<string>()
                      .HasMaxLength(20)
                      .HasDefaultValue(ComplaintStatus.Pending);


            
                entity.HasOne(c => c.Category)
                      .WithMany(cat => cat.Complaints)
                      .HasForeignKey(c => c.CategoryId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

 
            modelBuilder.Entity<Reply>(entity =>
            {
                entity.HasKey(r => r.Id);

                entity.Property(r => r.Content)
                      .IsRequired()
                      .HasMaxLength(1000);

                entity.Property(r => r.CreatedAt)
                      .IsRequired()
                      .HasDefaultValueSql("GETUTCDATE()");

                entity.HasOne(r => r.Complaint)
                      .WithMany(c => c.Replies)
                      .HasForeignKey(r => r.ComplaintId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}