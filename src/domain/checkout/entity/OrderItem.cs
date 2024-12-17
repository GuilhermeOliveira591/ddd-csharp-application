using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddd_csharp_application.src.domain.checkout.entity
{
    public class OrderItemEntity
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }


        public OrderItemEntity(string id, string name, string productId, decimal price, int quantity)
        {
            this.Id = id;
            this.ProductId = productId;
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
        }

        public decimal OrderItemTotal()
        {
            return this.Price * this.Quantity;
        }

    }
}
