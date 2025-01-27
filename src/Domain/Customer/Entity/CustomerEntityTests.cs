using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ddd_csharp_application.src.Domain.Checkout.Entity;
using ddd_csharp_application.src.Domain.Customer.Entity;
using ddd_csharp_application.src.Domain.Customer.ValueObject;
using NUnit.Framework;

[TestFixture]
public class CustomerEntityTests
{

    [Test]
    public void ShouldThrowErrorWhenIdIsEmpty()
    {
        var ex = Assert.Throws<ArgumentException>(() => new CustomerEntity("", "John"));
        Assert.That(ex.Message, Is.EqualTo("Id is required"));
    }

    [Test]
    public void ShouldThrowErrorWhenNameIsEmpty()
    {
        var ex = Assert.Throws<ArgumentException>(() => new CustomerEntity("123", ""));
        Assert.That(ex.Message, Is.EqualTo("Name is required"));
    }

    [Test]
    public void ShouldChangeName()
    {
        var customer = new CustomerEntity("123", "John");

        customer.ChangeName("Jane");

        Assert.AreEqual("Jane", customer.Name);
    }

    [Test]
    public void ShouldActivateCustomer()
    {
        var customer = new CustomerEntity("1", "Customer1");
        var address = new Address("Street 1", 123, "01234-567", "São Paulo");

        customer.ChangeAddress(address);

        customer.Activate();

        Assert.IsTrue(customer.IsActive());
    }

    [Test]
    public void ShouldDeactivateCustomer()
    {
        var customer = new CustomerEntity("1", "Customer1");

        customer.Deactivate();

        Assert.IsFalse(customer.IsActive());
    }

    [Test]
    public void ShouldAddRewardPoints()
    {
        var customer = new CustomerEntity("1", "Customer1");

        Assert.AreEqual(0, customer.RewardPoints);

        customer.AddRewardPoints(10);
        Assert.AreEqual(10, customer.RewardPoints);

        customer.AddRewardPoints(10);
        Assert.AreEqual(20, customer.RewardPoints);
    }



}

