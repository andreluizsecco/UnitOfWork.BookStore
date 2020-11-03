using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnitOfWork.BookStore.Domain.Entities;

namespace UnitOfWork.BookStore.Data.EFCore.Mappings
{
    public class StockMap : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.ToTable("Stock");

            builder.HasKey(p => p.ProductId);

            builder.HasOne(p => p.Product)
                .WithMany()
                .HasForeignKey(p => p.ProductId);

            builder.HasData(
                new Stock(1, 25),
                new Stock(2, 12),
                new Stock(3, 55),
                new Stock(4, 8),
                new Stock(5, 14),
                new Stock(6, 16)
            );
        }
    }
}