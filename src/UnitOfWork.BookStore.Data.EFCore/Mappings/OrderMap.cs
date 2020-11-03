using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnitOfWork.BookStore.Domain.Entities;

namespace UnitOfWork.BookStore.Data.EFCore.Mappings
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");

            builder.Property(p => p.Id)
                .ValueGeneratedNever();

            builder.Property(p => p.Created)
                .HasColumnType("datetime2");

            builder.HasOne(p => p.Customer)
                .WithMany()
                .HasForeignKey(p => p.CustomerId);
        }
    }
}