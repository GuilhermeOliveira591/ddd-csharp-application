using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ddd_csharp_application.src.Domain.Checkout.Entity;
using ddd_csharp_application.src.Domain.Checkout.Factory;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class OrderFactoryTests
{

    [Test]
    public void ShouldCreateAnOrder()
    {
        List<OrderItemEntity> items = new List<OrderItemEntity>();

        var orderItem = new OrderItemEntity(
            Guid.NewGuid().ToString(),
            "Teste",
            Guid.NewGuid().ToString(),
            100m,
            1
        );

        items.Add(orderItem);

        var orderObject = new OrderEntity(
            Guid.NewGuid().ToString(), 
            Guid.NewGuid().ToString(), 
            items
        );

        var order = OrderFactory.Create(orderObject);

        Assert.AreEqual(orderObject.Id, order.Id);
        Assert.AreEqual(orderObject.CustomerId, order.CustomerId);
        Assert.AreEqual(orderObject.Items.Count, order.Items.Count);

    }


}

