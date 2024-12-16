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
        private string _Id;
        private string _ProductId;
        private string _Name;
        private decimal _Price;
        private int _Quantity;


        public OrderItem(string id, string name, string productId, decimal price, int quantity)
        {
            this._Id = id;
            this._ProductId = productId;
            this._Name = name;
            this._Price = price;
            this._Quantity = quantity;
        }

        public string Id
        {
            get { return _Id; }
        }

        public string Name
        { 
            get { return _Name; } 
        }

        public decimal Price
        {
            get { return _Price; }
        }

        public int Quantity
        {
            get { return _Quantity; }
        }

        public string ProductId
        {
            get { return _ProductId; }
        }

        public decimal OrderItemTotal()
        {
            return this._Price * this._Quantity;
        }

    }
}
