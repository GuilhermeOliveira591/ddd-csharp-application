using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddd_csharp_application.src.Domain.Product.Entity
{
    public class ProductEntity
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public ProductEntity(string id, string name, decimal price) { 
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Validate();
        }

        public void ChangeName(string name)
        {
            this.Name = name;
            this.Validate();
        }

        public void ChangePrice(decimal price)
        {
            this.Price = price;
            this.Validate();
        }

        public bool Validate()
        {
            if (this.Id.Length == 0)
            {
                throw new ArgumentException("Id is required");
            }

            if (this.Name.Length == 0)
            {
                throw new ArgumentException("Name is required");
            }

            if (this.Price <= 0)
            {
                throw new ArgumentException("Price must be greater than zero");
            }

            return true;

        }




    }
}
