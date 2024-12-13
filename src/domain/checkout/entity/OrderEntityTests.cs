using ddd_csharp_application.src.domain.checkout.entity;
using NUnit.Framework;

[TestFixture]
public class OrderEntityTests
{
    [Test]
    public void ShouldThrowErrorWhenIdIsEmpty()
    {
        var ex = Assert.Throws<ArgumentException>(() => new Order("", "123", new List<OrderItem>()));
        Assert.That(ex.Message, Is.EqualTo("Id is required"));
    }

    [Test]
    public void ShouldThrowErrorWhenCustomerIdIsEmpty()
    {
        var ex = Assert.Throws<ArgumentException>(() => new Order("123", "", new List<OrderItem>()));
        Assert.That(ex.Message, Is.EqualTo("CustomerId is required"));
    }

    [Test]
    public void ShouldThrowErrorWhenOrderItemIsEmpty()
    {
        var ex = Assert.Throws<ArgumentException>(() => new Order("123", "15", new List<OrderItem>()));
        Assert.That(ex.Message, Is.EqualTo("Items are required"));
    }

    [Test]
    public void ShouldCalculateTotal()
    {
        var item1 = new OrderItem("1", "Item 1", "p1", 100, 2);
        var item2 = new OrderItem("2", "Item 2", "p2", 200, 2);

        var order1 = new Order("14", "20", new List<OrderItem> { item1 });
        var total1 = order1.Total();
        Assert.AreEqual(200, total1);

        var order2 = new Order("15", "25", new List<OrderItem> { item1, item2 });
        var total2 = order2.Total();
        Assert.AreEqual(600, total2); 
    }

    [Test]
    public void ShouldThrowErrorItemQuantityIsLessOrGreaterThanZero()
    {
        var ex = Assert.Throws<ArgumentException>(() =>
        {
            var item = new OrderItem("1", "Item 1", "p1", 100, 0);
            var order = new Order("14", "20", new List<OrderItem> { item });
        });

        Assert.That(ex.Message, Is.EqualTo("Quantity must be greater than zero"));
    }
}
