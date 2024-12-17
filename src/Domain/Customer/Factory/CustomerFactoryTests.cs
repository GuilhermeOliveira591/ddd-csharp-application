using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ddd_csharp_application.src.Domain.Customer.Factory;
using ddd_csharp_application.src.Domain.Customer.ValueObject;
using NUnit.Framework;

[TestFixture]
public class CustomerFactoryTests
{

    [Test]
    public void ShouldCreateACustomer()
    {
        var customer = CustomerFactory.Create("John");

        Assert.IsNotNull(customer.Id);
        Assert.AreEqual("John", customer.Name);
        Assert.IsNull(customer.Address);
    }

    [Test]
    public void ShouldCreateACustomerWithAnAddress()
    {
        var address = new Address("RUA", 1, "12334098", "SP");
        var customer = CustomerFactory.CreateWithAddress("John", address);

        Assert.IsNotNull(customer.Id);
        Assert.AreEqual("John", customer.Name);
        Assert.AreEqual(address, customer.Address);
    }

}

