using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddd_csharp_application.src.Domain.Customer.ValueObject
{
    public class Address
    {
        public string Street { get; set; }
        public decimal Number { get; set; } = 0;
        public string Zip { get; set; }
        public string City { get; set; }

        public Address(string street, decimal number, string zip, string city) { 
            this.Street = street;
            this.Number = number;
            this.Zip = zip; 
            this.City = city;
        }

        public bool Validate()
        {
            if (this.Street.Length == 0)
            {
                throw new ArgumentException("Street is required!");
            }

            if (this.Number == 0)
            {
                throw new ArgumentException("Number is required!");
            }

            if (this.Zip.Length == 0)
            {
                throw new ArgumentException("Zip is required!");
            }

            if (this.City.Length == 0)
            {
                throw new ArgumentException("City is required!");
            }

            return true;

        }

        public string ToString()
        {
            return $"{this.Street}, {this.Number}, {this.Zip}, {this.City}";
        }


    }
}
