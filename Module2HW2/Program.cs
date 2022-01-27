using System;

namespace Module2HW2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Catalog catalogOfProducts = Catalog.Instance;
            CatalogService catalogService = new CatalogService(catalogOfProducts);
            catalogService.ShowCatalog();

            int quanOfOrders;
            Console.Write("Quantity of orders: ");
            quanOfOrders = Convert.ToInt32(Console.ReadLine());
            OrderService orderService = new OrderService(quanOfOrders);

            ShoppingCart shoppingCart = new ShoppingCart();
            CartService cartService = new CartService(shoppingCart, catalogOfProducts);
            Order order;

            for (int i = 0; i < quanOfOrders; i++)
            {
                cartService.AddToCart();
                order = cartService.MakeAnOrder();

                if (order != null)
                {
                    orderService.AddOrderToList(order);
                }
            }

            orderService.ShowOrders();
            Console.WriteLine();
        }
    }
}
