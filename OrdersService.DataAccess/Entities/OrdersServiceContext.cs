using Microsoft.EntityFrameworkCore;

namespace OrdersService.DataAccess.Entities
{
    public sealed class OrdersServiceContext : DbContext
    {
        public OrdersServiceContext(DbContextOptions<OrdersServiceContext> options) : base(options) { }

        public DbSet<Orders> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasIndex(e => e.OrderId)
                      .HasName("IX_OrderId")
                      .IsUnique();

                entity.Property(e => e.City)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.Country)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.CreationTimestamp).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.CustomerName)
                      .IsRequired()
                      .HasMaxLength(260);

                entity.Property(e => e.OrderId)
                      .IsRequired()
                      .HasMaxLength(50)
                      .IsUnicode(false);

                entity.Property(e => e.Phone)
                      .HasMaxLength(15)
                      .IsUnicode(false);

                entity.Property(e => e.PostCode)
                      .IsRequired()
                      .HasMaxLength(32)
                      .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.Street)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.Version)
                      .IsRequired()
                      .IsRowVersion();
            });
        }
    }
}
