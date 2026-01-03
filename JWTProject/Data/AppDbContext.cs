using JWTProject.Model;
using Microsoft.EntityFrameworkCore;

namespace JWTProject.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasDefaultValue("User");

            base.OnModelCreating(modelBuilder);
        }
    }
}
