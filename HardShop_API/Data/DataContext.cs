using HardShop_API.Models;
using Microsoft.EntityFrameworkCore;

namespace HardShop_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<OrderOperation> OrderOperations { get; set; }
        public DbSet<ProductOperation> ProductOperations { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<ProductRating> ProductRatings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Listing>()
                .HasKey(l => new { l.OrderId, l.ProductId });
            modelBuilder.Entity<ProductReview>()
                .HasKey(p => new { p.CustomerId, p.ProductId });
            modelBuilder.Entity<ProductRating>()
                .HasKey(p => new { p.CustomerId, p.ProductId });
        }
    }
}