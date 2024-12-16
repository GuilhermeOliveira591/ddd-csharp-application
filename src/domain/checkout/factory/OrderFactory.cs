using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ddd_csharp_application.src.domain.checkout.entity;
using Newtonsoft.Json;
using NUnit.Framework.Interfaces;

namespace ddd_csharp_application.src.domain.checkout.factory
{
    public interface IOrderFactoryProps
    {
        string Id { get; set; }
        string CustomerId { get; set; }
        List<OrderItem> Items { get; set; }
    }

    public class OrderFactory : IOrderFactoryProps
    {
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public List<OrderItem> Items { get; set; }

        public static Order Create(IOrderFactoryProps props) {

            var items = props.Items.Select(item => new OrderItem(item.Id, item.Name, item.ProductId, item.Price, item.Quantity)).ToList();

            return new Order(props.Id, props.CustomerId, items);
        }

        public static IOrderFactoryProps ConvertToOrderFactoryProps(object anonymousObject)
        {
            var id = anonymousObject.GetType().GetProperty("Id")?.GetValue(anonymousObject).ToString();
            var customerId = anonymousObject.GetType().GetProperty("CustomerId")?.GetValue(anonymousObject).ToString();
            var items = anonymousObject.GetType().GetProperty("Items")?.GetValue(anonymousObject) as List<OrderItem>;

            // Retornando a instância de IOrderFactoryProps
            return new OrderFactory
            {
                Id = id,
                CustomerId = customerId,
                Items = items
            };
        }


    }
}


