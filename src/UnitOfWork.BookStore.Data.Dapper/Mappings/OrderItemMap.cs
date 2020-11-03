using Dapper.FluentMap.Dommel.Mapping;
using UnitOfWork.BookStore.Domain.Entities;

namespace UnitOfWork.BookStore.Data.Dapper.Mappings
{
    public class OrderItemMap : DommelEntityMap<OrderItem>
    {
        public OrderItemMap()
        {
            Map(p => p.OrderId)
                .IsKey();

            Map(p => p.ProductId)
                .IsKey();

            Map(p => p.Order)
                .Ignore();

            Map(p => p.Product)
                .Ignore();
        }
    }
}