using Dapper.FluentMap.Dommel.Mapping;
using UnitOfWork.BookStore.Domain.Entities;

namespace UnitOfWork.BookStore.Data.Dapper.Mappings
{
    public class StockMap : DommelEntityMap<Stock>
    {
        public StockMap()
        {
            Map(p => p.ProductId)
                .IsKey();

            Map(p => p.Product)
                .Ignore();
        }
    }
}