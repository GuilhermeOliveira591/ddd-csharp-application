using ddd_csharp_application.src.domain.checkout.entity;
using NUnit.Framework;

[TestFixture]
public class OrderEntityTests
{
    [Test]
    public void ShouldThrowErrorWhenIdIsEmpty()
    {
        var ex = Assert.Throws<ArgumentException>(() => new OrderEntity("", "123", new List<OrderItemEntity>()));
        Assert.That(ex.Message, Is.EqualTo("Id is required"));
    }

    [Test]
    public void ShouldThrowErrorWhenCustomerIdIsEmpty()
    {
        var ex = Assert.Throws<ArgumentException>(() => new OrderEntity("123", "", new List<OrderItemEntity>()));
        Assert.That(ex.Message, Is.EqualTo("CustomerId is required"));
    }

    [Test]
    public void ShouldThrowErrorWhenOrderItemIsEmpty()
    {
        var ex = Assert.Throws<ArgumentException>(() => new OrderEntity("123", "15", new List<OrderItemEntity>()));
        Assert.That(ex.Message, Is.EqualTo("Items are required"));
    }

    [Test]
    public void ShouldCalculateTotal()
    {
        var item1 = new OrderItemEntity("1", "Item 1", "p1", 100, 2);
        var item2 = new OrderItemEntity("2", "Item 2", "p2", 200, 2);

        var order1 = new OrderEntity("14", "20", new List<OrderItemEntity> { item1 });
        var total1 = order1.CalculateTotal();
        Assert.AreEqual(200, total1);

        var order2 = new OrderEntity("15", "25", new List<OrderItemEntity> { item1, item2 });
        var total2 = order2.CalculateTotal();
        Assert.AreEqual(600, total2); 
    }

    [Test]
    public void ShouldThrowErrorItemQuantityIsLessOrGreaterThanZero()
    {
        var ex = Assert.Throws<ArgumentException>(() =>
        {
            var item = new OrderItemEntity("1", "Item 1", "p1", 100, 0);
            var order = new OrderEntity("14", "20", new List<OrderItemEntity> { item });
        });

        Assert.That(ex.Message, Is.EqualTo("Quantity must be greater than zero"));
    }
}
