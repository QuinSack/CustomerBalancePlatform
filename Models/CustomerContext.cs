using Microsoft.EntityFrameworkCore;

namespace CustomerBalancePlatform.Models
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {
            
        }

        public DbSet<Customer>? Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure ContactInfo as an owned entity within Customer
            modelBuilder.Entity<Customer>().OwnsOne(c => c.ContactInformation);

            base.OnModelCreating(modelBuilder);
        }
    }
}
