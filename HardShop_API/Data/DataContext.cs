using HardShop_API.Models;
using Microsoft.EntityFrameworkCore;

namespace HardShop_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardNetwork> CardNetworks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<CustomerCard> CustomerCards { get; set; }
        public DbSet<CustomerPhone> CustomerPhones { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOperation> ProductOperations { get; set; }
        public DbSet<ProductRating> ProductRatings { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderList> PurchaseOrderLists { get; set; }
        public DbSet<PurchaseOrderOperation> PurchaseOrderOperations { get; set; }
        public DbSet<PurchaseOrderPayment> PurchaseOrderPayments { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<SalesOrderList> SalesOrderLists { get; set; }
        public DbSet<SalesOrderOperation> SalesOrderOperations { get; set; }
        public DbSet<SalesOrderPayment> SalesOrderPayments { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierAddress> SupplierAddresses { get; set; }
        public DbSet<SupplierCard> SupplierCards { get; set; }
        public DbSet<SupplierPhone> SupplierPhones { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SalesOrderList>()
                .HasKey(e => new { e.SalesOrderId, e.SizeId });

            modelBuilder.Entity<PurchaseOrderList>()
                .HasKey(e => new { e.PurchaseOrderId, e.SizeId });

            modelBuilder.Entity<ProductReview>()
                .HasKey(e => new { e.CustomerId, e.ProductId });
            modelBuilder.Entity<ProductRating>()
                .HasKey(e => new { e.CustomerId, e.ProductId });

            modelBuilder.Entity<CustomerAddress>()
                .HasKey(e => new { e.CustomerId, e.AddressId });
            modelBuilder.Entity<CustomerCard>()
                .HasKey(e => new { e.CustomerId, e.CardId });
            modelBuilder.Entity<CustomerPhone>()
                .HasKey(e => new { e.CustomerId, e.PhoneId });

            modelBuilder.Entity<SupplierAddress>()
                .HasKey(e => new { e.SupplierId, e.AddressId });
            modelBuilder.Entity<SupplierCard>()
                .HasKey(e => new { e.SupplierId, e.CardId });
            modelBuilder.Entity<SupplierPhone>()
                .HasKey(e => new { e.SupplierId, e.PhoneId });
        }
    }
}