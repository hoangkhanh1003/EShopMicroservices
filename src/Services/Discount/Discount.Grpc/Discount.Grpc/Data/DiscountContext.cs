using Discount.Grpc.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data
{
    public class DiscountContext : DbContext
    {
        public DiscountContext(DbContextOptions<DiscountContext> options) : base(options)
        {
        }

        public DbSet<Coupon> Coupons { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Coupon[] coupons = new Coupon[]
            {
                new Coupon
                {
                    Id = 1,
                    ProductName = "IPhone X",
                    Description = "IPhone Discount",
                    Amount = 500
                },
                new Coupon
                {
                    Id = 2,
                    ProductName = "SamSung Galaxy",
                    Description = "SamSung Discount",
                    Amount = 700
                }
            };

            modelBuilder.Entity<Coupon>().HasData(coupons);
        }
    }
}
