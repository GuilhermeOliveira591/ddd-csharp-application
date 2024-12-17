using System;
using System.Collections.Generic;
using System.Linq;
using ddd_csharp_application.src.domain.checkout.entity;

namespace ddd_csharp_application.src.domain.checkout.entity
{
    public class OrderEntity
    {
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public List<OrderItemEntity> Items { get; set; } = new List<OrderItemEntity>();
        public decimal Total { get; set; }

        public OrderEntity(string id, string customerId, List<OrderItemEntity> items)
        {
            this.Id = id;
            this.CustomerId = customerId;
            this.Items = items;
            this.Total = CalculateTotal();
            Validate();
        }

        public decimal CalculateTotal()
        {
            return Items.Sum(item => item.OrderItemTotal());
        }

        public bool Validate()
        {
            if (string.IsNullOrEmpty(Id))
            {
                throw new ArgumentException("Id is required");
            }

            if (string.IsNullOrEmpty(CustomerId))
            {
                throw new ArgumentException("CustomerId is required");
            }

            if (Items.Count == 0)
            {
                throw new ArgumentException("Items are required");
            }

            if (Items.Any(item => item.Quantity <= 0))
            {
                throw new ArgumentException("Quantity must be greater than zero");
            }

            return true;
        }
    }

}