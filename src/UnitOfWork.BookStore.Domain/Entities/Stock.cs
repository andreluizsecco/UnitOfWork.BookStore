namespace UnitOfWork.BookStore.Domain.Entities
{
    public class Stock
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public Product Product { get; set; }

        public Stock() { }

        public Stock(int productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }
    }
}