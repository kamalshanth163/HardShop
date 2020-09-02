using HardShop_API.Models;
using Microsoft.EntityFrameworkCore;

namespace HardShop_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<AdminAddress> AdminAddresses { get; set; }
        public DbSet<AdminCard> AdminCards { get; set; }
        public DbSet<AdminPhone> AdminPhones { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardNetwork> CardNetworks { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<CustomerCard> CustomerCards { get; set; }
        public DbSet<CustomerPhone> CustomerPhones { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSubCategory> ProductSubCategories { get; set; }
        public DbSet<ProductMainCategory> ProductMainCategories { get; set; }
        public DbSet<ProductOperation> ProductOperations { get; set; }
        public DbSet<ProductOption> ProductOptions { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderList> PurchaseOrderLists { get; set; }
        public DbSet<PurchaseOrderOperation> PurchaseOrderOperations { get; set; }
        public DbSet<PurchaseOrderPayment> PurchaseOrderPayments { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<SalesOrderList> SalesOrderLists { get; set; }
        public DbSet<SalesOrderOperation> SalesOrderOperations { get; set; }
        public DbSet<SalesOrderPayment> SalesOrderPayments { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierDetail> SupplierDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SalesOrderList>()
                .HasKey(e => new { e.SalesOrderId, e.ProductOptionId });

            modelBuilder.Entity<PurchaseOrderList>()
                .HasKey(e => new { e.PurchaseOrderId, e.ProductOptionId });

            modelBuilder.Entity<ProductReview>()
                .HasKey(e => new { e.CustomerId, e.ProductOptionId });

            modelBuilder.Entity<CustomerAddress>()
                .HasKey(e => new { e.CustomerId, e.AddressId });
            modelBuilder.Entity<CustomerCard>()
                .HasKey(e => new { e.CustomerId, e.CardId });
            modelBuilder.Entity<CustomerPhone>()
                .HasKey(e => new { e.CustomerId, e.PhoneId });

            modelBuilder.Entity<AdminAddress>()
                .HasKey(e => new { e.AdminId, e.AddressId });
            modelBuilder.Entity<AdminCard>()
                .HasKey(e => new { e.AdminId, e.CardId });
            modelBuilder.Entity<AdminPhone>()
                .HasKey(e => new { e.AdminId, e.PhoneId });

            // modelBuilder.Entity<ProductCategory> ()
            //     .HasMany<Product> (pc => pc.Products)
            //     .WithRequired (p => p.Category)
            //     .HasForeignKey<int> (p => p.CategoryId);

            // modelBuilder.Entity<Product> ()
            //     .HasRequired<ProductCategory> (p => p.Category)
            //     .WithMany (pc => pc.Products)
            //     .HasForeignKey<int> (p => p.CategoryId);

        }

    }
}