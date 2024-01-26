using Microsoft.EntityFrameworkCore;

namespace JopOffers.Models.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Jobs> Jobs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ApplyForJobs> ApplyForJobs { get; set; }
        public DbSet<Contact> Contacts { get; set; }

    }
}
