using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ddd_csharp_application.src.domain.checkout.entity;
using ddd_csharp_application.src.Domain.Checkout.Service;
using ddd_csharp_application.src.Domain.Customer.Entity;
using NUnit.Framework;

[TestFixture]
public class OrderServiceTests
{
    [Test]
    public void ShouldGetTotalOfAllOrders()
    {
        var item1 = new OrderItemEntity("i1", "Item 1", "p1", 100, 1);
        var item2 = new OrderItemEntity("i2", "Item 2", "p2", 200, 2);

        var order1 = new OrderEntity("o1", "c1", new List<OrderItemEntity> { item1 });
        var order2 = new OrderEntity("o2", "c2", new List<OrderItemEntity> { item2 });

        var total = OrderService.Total(new List<OrderEntity> { order1, order2 });

        Assert.AreEqual(500, total);
    }

    [Test]
    public void ShouldPlaceAnOrder()
    {
        var customer = new CustomerEntity("c1", "Customer 1");
        var item1 = new OrderItemEntity("i1", "Item 1", "p1", 10, 1);

        var order = OrderService.PlaceOrder(customer, new List<OrderItemEntity> { item1 });

        Assert.AreEqual(5, customer.RewardPoints);

        Assert.AreEqual(10, order.CalculateTotal());
    }

}
