using System;
using System.Threading.Tasks;
using UnitOfWork.BookStore.Data.EFCore.Context;
using UnitOfWork.BookStore.Domain.Entities;
using UnitOfWork.BookStore.Domain.Interfaces.Repository;

namespace UnitOfWork.BookStore.Data.EFCore.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context) =>
            _context = context;

        public async Task CreateOrder(Order order) =>
            await _context.Order.AddAsync(order);

        private bool _disposed = false;

        ~OrderRepository() =>
           Dispose();

        public void Dispose()
        {
            if (!_disposed)
                _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}