using System;

namespace Module2HW2
{
    public class OrderService
    {
        public OrderService(int quantityOfOrders)
        {
            Orders = new Order[quantityOfOrders];
        }

        public Order[] Orders { get; set; }

        public void ShowOrders()
        {
            foreach (var order in Orders)
            {
                if (order != null)
                {
                    Console.WriteLine($"Order number: {order.Id}");
                    foreach (var product in order.Products)
                    {
                        Console.WriteLine($" - {product.Name} ({product.Quantity})");
                    }

                    Console.WriteLine($"Total quantity: {order.TotalQuantity}");
                    Console.WriteLine();
                }
            }
        }

        public void AddOrderToList(Order order)
        {
            Orders[order.Id - 1] = order;
        }
    }
}
