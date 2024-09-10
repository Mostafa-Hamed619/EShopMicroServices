using Discount.Grpc.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data
{
    public class DiscountContext : DbContext
    {
        public DiscountContext(DbContextOptions<DiscountContext> options) : base(options)
        {
        }

        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Coupon>().HasData(
                new Coupon { Id = 1, ProductName = "IPhone-x", Description = "IPhone-x discount", Amount = 150 },
                new Coupon { Id = 2, ProductName = "Samsung", Description = "Samsung discount", Amount = 30 }
                );
        }
    }
}
