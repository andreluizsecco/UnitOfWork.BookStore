using Dapper.FluentMap.Dommel.Mapping;
using UnitOfWork.BookStore.Domain.Entities;

namespace UnitOfWork.BookStore.Data.Dapper.Mappings
{
    public class ProductMap : DommelEntityMap<Product>
    {
        public ProductMap()
        {
            Map(p => p.Id)
                .IsKey();
        }
    }
}