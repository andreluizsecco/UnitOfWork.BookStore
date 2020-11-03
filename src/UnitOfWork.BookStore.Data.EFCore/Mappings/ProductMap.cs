using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnitOfWork.BookStore.Domain.Entities;

namespace UnitOfWork.BookStore.Data.EFCore.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.Property(p => p.Id)
                .ValueGeneratedNever();

            builder.Property(p => p.Name)
                .HasColumnType("varchar(255)");

            builder.Property(p => p.Price)
                .HasColumnType("numeric(38,2)");

            builder.HasData(
                new Product(1, "Domain-Driven Design: Tackling Complexity in the Heart of Software", 74.99m),
                new Product(2, "Agile Principles, Patterns, and Practices in C#", 215.41m),
                new Product(3, "Clean Code: A Handbook of Agile Software Craftsmanship", 95.17m),
                new Product(4, "Implementing Domain-Driven Design", 126.30m),
                new Product(5, "Patterns, Principles, and Practices of Domain-Driven Design", 311.58m),
                new Product(6, "Refactoring: Improving the Design of Existing Code", 112.88m)
            );
        }
    }
}