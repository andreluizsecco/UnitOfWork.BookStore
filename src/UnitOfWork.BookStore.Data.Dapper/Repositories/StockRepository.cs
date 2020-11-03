using System;
using System.Threading.Tasks;
using RepositoryHelpers.DataBaseRepository;
using UnitOfWork.BookStore.Data.Dapper.Context;
using UnitOfWork.BookStore.Domain.Entities;
using UnitOfWork.BookStore.Domain.Interfaces.Repository;

namespace UnitOfWork.BookStore.Data.Dapper.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly CustomRepository<Stock> _stockRepository;
        private readonly DataContext _context;

        public StockRepository(DataContext context)
        {
            _context = context;
            _stockRepository = new CustomRepository<Stock>(context.Connection);
        }

        public async Task UpdateStockByOrder(Order order)
        {
            foreach (var item in order.Items)
            {
                var stockItem = await _stockRepository.GetByIdAsync(item.ProductId, _context.Transaction);
                stockItem.Quantity = stockItem.Quantity - item.Quantity;
                await _stockRepository.UpdateAsync(stockItem, _context.Transaction);
            }
        }

        private bool _disposed = false;

        ~StockRepository() =>
           Dispose();

        public void Dispose()
        {
            if (!_disposed)
                _stockRepository.DisposeDB(true);
            GC.SuppressFinalize(this);
        }
    }
}