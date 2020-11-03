using Dapper.FluentMap.Dommel.Mapping;
using UnitOfWork.BookStore.Domain.Entities;

namespace UnitOfWork.BookStore.Data.Dapper.Mappings
{
    public class OrderMap : DommelEntityMap<Order>
    {
        public OrderMap()
        {
            Map(p => p.Id)
                .IsKey();

            Map(p => p.Customer)
                .Ignore();

            Map(p => p.Items)
                .Ignore();
        }
    }
}