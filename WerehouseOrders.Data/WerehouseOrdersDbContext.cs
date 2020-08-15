using Microsoft.EntityFrameworkCore;
using WerehouseOrders.Models.Data.Orders;
using WerehouseOrders.Models.Data.Users;

namespace WerehouseOrders.Data
{
    public class WerehouseOrdersDbContext : DbContext
    {
        public WerehouseOrdersDbContext(DbContextOptions<WerehouseOrdersDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasKey(u => new { u.Id });

            builder.Entity<Order>()
                .HasKey(o => o.Id);

            builder.Entity<Order>()
                .HasOne<User>()
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);

            base.OnModelCreating(builder);
        }
    }
}
