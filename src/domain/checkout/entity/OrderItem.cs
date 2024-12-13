using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddd_csharp_application.src.domain.checkout.entity
{
    public class OrderItem
    {
        private string _id;
        private string _productId;
        private string _name;
        private decimal _price;
        private int _quantity;


        public OrderItem(string id, string name, string productId, decimal price, int quantity)
        {
            this._id = id;
            this._productId = productId;
            this._name = name;
            this._price = price;
            this._quantity = quantity;
        }

        public string Id
        {
            get { return _id; }
        }

        public string Name
        { 
            get { return _name; } 
        }

        public decimal Price
        {
            get { return _price; }
        }

        public int Quantity
        {
            get { return _quantity; }
        }

        public string ProductId
        {
            get { return _productId; }
        }

        public decimal OrderItemTotal()
        {
            return this._price * this._quantity;
        }

    }
}
