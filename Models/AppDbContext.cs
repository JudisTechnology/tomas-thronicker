using System.Data.Entity;

namespace DemoEPS.Models
{
    
    public class AppDbContext : DbContext
    {
        public DbSet<Coupon> Coupons { get; set; }

        public AppDbContext() : base("DefaultConnection") { }
    }
}