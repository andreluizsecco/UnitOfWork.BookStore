namespace UnitOfWork.BookStore.Domain.Entities
{
    public class OrderItem
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }

        
        public OrderItem(int orderId, int productId, int quantity, decimal total)
        {
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
            Total = total;
        }
    }
}