using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddd_csharp_application.src.Domain.Product.Entity
{
    public interface IProduct
    {
        public string GetId();
        public string GetName();
        public decimal GetPrice();
    }
}
