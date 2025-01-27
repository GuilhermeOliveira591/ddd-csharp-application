using ddd_csharp_application.src.Domain.Checkout.Entity;
using ddd_csharp_application.src.Domain.Customer.Entity;

namespace ddd_csharp_application.src.Domain.Checkout.Service
{
    public class OrderService
    {
        
        public static decimal Total(List<OrderEntity> orders)
        {
            return orders.Aggregate(0m, (acc, order) => acc + order.CalculateTotal());
        }

        public static OrderEntity PlaceOrder(CustomerEntity customer, List<OrderItemEntity> items)
        {
            if (items.Count == 0)
            {
                throw new Exception("Order must have at least one item");
            }

            var order = new OrderEntity(Guid.NewGuid().ToString(), customer.Id, items);

            customer.AddRewardPoints(order.CalculateTotal() / 2);

            return order;
        }




    }
}
