using System;
using System.Threading.Tasks;
using RepositoryHelpers.DataBaseRepository;
using UnitOfWork.BookStore.Data.Dapper.Context;
using UnitOfWork.BookStore.Domain.Entities;
using UnitOfWork.BookStore.Domain.Interfaces.Repository;

namespace UnitOfWork.BookStore.Data.Dapper.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CustomRepository<Order> _orderRepository;
        private readonly CustomRepository<OrderItem> _orderItemRepository;
        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;
            _orderRepository = new CustomRepository<Order>(context.Connection);
            _orderItemRepository = new CustomRepository<OrderItem>(context.Connection);
        }

        public async Task CreateOrder(Order order)
        {
            await _orderRepository.InsertAsync(order, false, _context.Transaction);
            foreach (var item in order.Items)
                await _orderItemRepository.InsertAsync(item, false, _context.Transaction);
        }

        private bool _disposed = false;

        ~OrderRepository() =>
           Dispose();

        public void Dispose()
        {
            if (!_disposed)
            {
                _orderRepository.DisposeDB(true);
                _orderItemRepository.DisposeDB(true);
            }
            GC.SuppressFinalize(this);
        }
    }
}