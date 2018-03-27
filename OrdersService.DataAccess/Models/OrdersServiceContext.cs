using Microsoft.EntityFrameworkCore;

namespace OrdersService.DataAccess.Models
{
    public class OrdersServiceContext : DbContext
    {
        public OrdersServiceContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<Orders> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasIndex(e => e.DisplayId)
                    .HasName("IX_DisplayId");

                entity.Property(e => e.CreationTimestamp).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.CustomerName).IsRequired();

                entity.Property(e => e.DisplayId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.Version)
                    .IsRequired()
                    .IsRowVersion();
            });
        }
    }
}