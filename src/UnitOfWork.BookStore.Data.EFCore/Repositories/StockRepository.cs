using System;
using System.Threading.Tasks;
using UnitOfWork.BookStore.Data.EFCore.Context;
using UnitOfWork.BookStore.Domain.Entities;
using UnitOfWork.BookStore.Domain.Interfaces.Repository;

namespace UnitOfWork.BookStore.Data.EFCore.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly DataContext _context;

        public StockRepository(DataContext context) =>
            _context = context;

        public async Task UpdateStockByOrder(Order order)
        {
            foreach (var item in order.Items)
            {
                var stockItem = await _context.Stock
                    .FindAsync(item.ProductId);

                stockItem.Quantity = stockItem.Quantity - item.Quantity;
            }
        }

        private bool _disposed = false;

        ~StockRepository() =>
           Dispose();

        public void Dispose()
        {
            if (!_disposed)
                _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}