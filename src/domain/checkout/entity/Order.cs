using System;
using System.Collections.Generic;
using System.Linq;

public class Order
{
    private string _id;
    private string _customerId;
    private List<OrderItem> _items = new List<OrderItem>();
    private decimal _total;

    // Construtor
    public Order(string id, string customerId, List<OrderItem> items)
    {
        this._id = id;
        this._customerId = customerId;
        this._items = items;
        this._total = Total();
        Validate();
    }

    // Propriedades
    public string Id
    {
        get { return _id; }
    }

    public string CustomerId
    {
        get { return _customerId; }
    }

    public List<OrderItem> Items
    {
        get { return _items; }
    }

    // Método para calcular o total
    public decimal Total()
    {
        return _items.Sum(item => item.OrderItemTotal());
    }

    // Método para validar os dados
    public bool Validate()
    {
        if (string.IsNullOrEmpty(_id))
        {
            throw new ArgumentException("Id is required");
        }

        if (string.IsNullOrEmpty(_customerId))
        {
            throw new ArgumentException("CustomerId is required");
        }

        if (_items.Count == 0)
        {
            throw new ArgumentException("Items are required");
        }

        if (_items.Any(item => item.Quantity <= 0))
        {
            throw new ArgumentException("Quantity must be greater than zero");
        }

        return true;
    }
}
