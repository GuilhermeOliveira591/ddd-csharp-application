

using ddd_csharp_application.src.Domain.Customer.Entity;
using ddd_csharp_application.src.Domain.Customer.ValueObject;

namespace ddd_csharp_application.src.Domain.Customer.Factory
{
    public class CustomerFactory
    {

        public static CustomerEntity Create(string name)
        {
            return new CustomerEntity(Guid.NewGuid().ToString(), name);
        }

        public static CustomerEntity CreateWithAddress(string name, Address address)
        {
            var customer = new CustomerEntity(Guid.NewGuid().ToString(), name);
            customer.ChangeAddress(address);

            return customer;
        }



    }
}
