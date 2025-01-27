using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ddd_csharp_application.src.Domain.Checkout.Entity;
using Newtonsoft.Json;
using NUnit.Framework.Interfaces;

namespace ddd_csharp_application.src.Domain.Checkout.Factory
{

    public class OrderFactory
    {

        public static OrderEntity Create(OrderEntity props) {

            var items = props.Items.Select(item => new OrderItemEntity(
                item.Id, item.Name, item.ProductId, item.Price, item.Quantity
            )).ToList();

            return new OrderEntity(props.Id, props.CustomerId, items);
        }

    }
}


