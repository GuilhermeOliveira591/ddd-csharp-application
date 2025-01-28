using ddd_csharp_application.src.Domain.Product.Entity;
using NUnit.Framework;

[TestFixture]
public class ProductEntityTests
{

    [Test]
    public void ShouldThrowErrorWhenIdIsEmpty()
    {
        var ex = Assert.Throws<ArgumentException>(() => new ProductEntity("", "Product 1", 100));
        Assert.That(ex.Message, Is.EqualTo("Id is required"));
    }

    [Test]
    public void ShouldThrowErrorWhenNameIsEmpty()
    {
        var ex = Assert.Throws<ArgumentException>(() => new ProductEntity("123", "", 100));
        Assert.That(ex.Message, Is.EqualTo("Name is required"));
    }

    [Test]
    public void ShouldThrowErrorWhenPriceIsLessThanZero()
    {
        var ex = Assert.Throws<ArgumentException>(() => new ProductEntity("123", "Name", -1));
        Assert.That(ex.Message, Is.EqualTo("Price must be greater than zero"));
    }

    [Test]
    public void ShouldChangeName()
    {
        var product = new ProductEntity("123", "Product 1", 100);

        product.ChangeName("Product 2");

        Assert.AreEqual("Product 2", product.Name);
    }

    [Test]
    public void ShouldChangePrice()
    {
        var product = new ProductEntity("123", "Product 1", 100);

        product.ChangePrice(150);

        Assert.AreEqual(150, product.Price);
    }
}

