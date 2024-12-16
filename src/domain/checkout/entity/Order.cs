using System;
using System.Collections.Generic;
using System.Linq;
using ddd_csharp_application.src.domain.checkout.entity;

namespace ddd_csharp_application.src.domain.checkout.entity
{
    public class Order
    {
        private string _Id;
        private string _CustomerId;
        private List<OrderItem> _Items = new List<OrderItem>();
        private decimal _Total;

        public Order(string id, string customerId, List<OrderItem> items)
        {
            this._Id = id;
            this._CustomerId = customerId;
            this._Items = items;
            this._Total = Total();
            Validate();
        }

        public string Id
        {
            get { return _Id; }
        }

        public string CustomerId
        {
            get { return _CustomerId; }
        }

        public List<OrderItem> Items
        {
            get { return _Items; }
        }

        public decimal Total()
        {
            return _Items.Sum(item => item.OrderItemTotal());
        }

        public bool Validate()
        {
            if (string.IsNullOrEmpty(_Id))
            {
                throw new ArgumentException("Id is required");
            }

            if (string.IsNullOrEmpty(_CustomerId))
            {
                throw new ArgumentException("CustomerId is required");
            }

            if (_Items.Count == 0)
            {
                throw new ArgumentException("Items are required");
            }

            if (_Items.Any(item => item.Quantity <= 0))
            {
                throw new ArgumentException("Quantity must be greater than zero");
            }

            return true;
        }
    }

}