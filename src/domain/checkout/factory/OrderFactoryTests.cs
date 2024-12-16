using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ddd_csharp_application.src.domain.checkout.entity;
using ddd_csharp_application.src.domain.checkout.factory;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class OrderFactoryTests
{

    [Test]
    public void ShouldCreateAnOrder()
    {
        var orderProps = new
        {
            Id = Guid.NewGuid().ToString(),
            CustomerId = Guid.NewGuid().ToString(),
            Items = new List<OrderItem>
            {
                new OrderItem(
                    Guid.NewGuid().ToString(),
                    "Teste",
                    Guid.NewGuid().ToString(),
                    100m,
                    1
                )
            }
        };

        var convert = OrderFactory.ConvertToOrderFactoryProps(orderProps);
        var order = OrderFactory.Create(convert);

        Assert.AreEqual(convert.Id, order.Id);
        Assert.AreEqual(convert.CustomerId, order.CustomerId);
        Assert.AreEqual(convert.Items.Count, order.Items.Count);

    }




}

