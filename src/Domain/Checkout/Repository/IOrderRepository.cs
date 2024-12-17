using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ddd_csharp_application.src.domain.checkout.entity;
using ddd_csharp_application.src.Domain._Shared.Repository;

namespace ddd_csharp_application.src.Domain.Checkout.Repository
{
    public interface IOrderRepository : IRepository<OrderEntity>  
    {
    }
}
