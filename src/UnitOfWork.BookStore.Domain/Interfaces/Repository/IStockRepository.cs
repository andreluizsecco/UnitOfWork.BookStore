using System;
using System.Threading.Tasks;
using UnitOfWork.BookStore.Domain.Entities;

namespace UnitOfWork.BookStore.Domain.Interfaces.Repository
{
    public interface IStockRepository : IDisposable
    {
        Task UpdateStockByOrder(Order order);
    }
}