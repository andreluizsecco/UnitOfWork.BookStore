using Dapper.FluentMap.Dommel.Mapping;
using UnitOfWork.BookStore.Domain.Entities;

namespace UnitOfWork.BookStore.Data.Dapper.Mappings
{
    public class CustomerMap : DommelEntityMap<Customer>
    {
        public CustomerMap()
        {
            Map(p => p.Id)
                .IsKey();
        }
    }
}