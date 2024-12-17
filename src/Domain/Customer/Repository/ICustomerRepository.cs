using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ddd_csharp_application.src.Domain._Shared.Repository;
using ddd_csharp_application.src.Domain.Customer.Entity;

namespace ddd_csharp_application.src.Domain.Customer.Repository
{
    public interface ICustomerRepository : IRepository<CustomerEntity>
    {
    }
}
