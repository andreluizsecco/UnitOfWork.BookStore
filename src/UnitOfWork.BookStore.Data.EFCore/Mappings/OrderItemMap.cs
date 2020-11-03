using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnitOfWork.BookStore.Domain.Entities;

namespace UnitOfWork.BookStore.Data.EFCore.Mappings
{
    public class OrderItemMap : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItem");

            builder.HasKey(p => new { p.OrderId, p.ProductId});

            builder.Property(p => p.Total)
                .HasColumnType("numeric(38,2)");

            builder.HasOne(p => p.Order)
                .WithMany(p => p.Items)
                .HasForeignKey(p => p.OrderId);

            builder.HasOne(p => p.Product)
                .WithMany()
                .HasForeignKey(p => p.ProductId);
        }
    }
}