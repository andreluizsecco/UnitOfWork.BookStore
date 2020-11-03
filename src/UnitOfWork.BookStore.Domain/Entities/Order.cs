using System;
using System.Collections.Generic;

namespace UnitOfWork.BookStore.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime Created { get; set; }

        public Customer Customer { get; set; }
        public ICollection<OrderItem> Items { get; set; }

        public Order()
        {
            Created = DateTime.Now;
            Items = new List<OrderItem>();
        }
        
        public Order(int id, int customerId) : this()
        {
            Id = id;
            CustomerId = customerId;
        }

        public void AddItem(OrderItem item) =>
            Items.Add(item);
    }
}