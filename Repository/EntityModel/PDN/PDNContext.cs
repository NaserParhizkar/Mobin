using Microsoft.EntityFrameworkCore;
using PDN.Repository;

namespace PDN
{
    public class PDNContext : DbContext
    {
        public PDNContext()
        {
        }

        public PDNContext(DbContextOptions<PDNContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PDNCustomer> PDNCustomers { get; set; }
        public virtual DbSet<PDNOrder> PDNOrders { get; set; }
        public virtual DbSet<PDNOrderItem> PDNOrderItems { get; set; }
        public virtual DbSet<PDNProduct> PDNProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\;Database=PDN;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PDNCustomer>(entity =>
            {
                entity.Property(e => e.PDNCustomerId).ValueGeneratedOnAdd();

                entity.HasIndex(e => e.PDNCity)
                    .HasName("City");

                entity.HasIndex(e => e.PDNPostalCode)
                    .HasName("PostalCode");

                entity.Property(e => e.PDNCustomerId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<PDNOrder>(entity =>
            {
                entity.Property(e => e.PDNOrderId).ValueGeneratedOnAdd();

                entity.HasIndex(e => e.PDNCustomerId)
                    .HasName("CustomersOrders");

                entity.HasIndex(e => e.PDNOrderDate)
                    .HasName("OrderDate");

                entity.HasOne(d => d.PDNCustomer)
                    .WithMany(p => p.PDNOrders)
                    .HasForeignKey(d => d.PDNCustomerId)
                    .HasConstraintName("FK_Orders_Customers");
            });

            modelBuilder.Entity<PDNOrderItem>(entity =>
            {
                entity.Property(e => e.PDNOrderItemId).ValueGeneratedOnAdd();

                entity.Property(e => e.PDNQuantity).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.PDNOrder)
                    .WithMany(p => p.PDNOrderItems)
                    .HasForeignKey(d => d.PDNOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Items_Orders");

                entity.HasOne(d => d.PDNProduct)
                    .WithMany(p => p.PDNOrderItems)
                    .HasForeignKey(d => d.PDNProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Items_Products");
            });

            modelBuilder.Entity<PDNProduct>(entity =>
            {
                entity.Property(e => e.PDNProductId).ValueGeneratedOnAdd();

                entity.HasIndex(e => e.PDNProductName)
                    .HasName("PDNProductName");
            });
        }
    }
}
