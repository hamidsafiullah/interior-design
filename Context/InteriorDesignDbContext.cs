using InteriorDesign.Entities;
using Microsoft.EntityFrameworkCore;

namespace InteriorDesign.Context
{
    public class InteriorDesignDbContext : DbContext
    {
        public InteriorDesignDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<object>().HasNoKey();

            modelBuilder.Entity<CartItem>().HasKey(c => new { c.CartId, c.ProductId });
           
            // Add other entity configurations as needed
        }
    }
}
