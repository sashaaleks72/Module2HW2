using System;

namespace Module2HW2
{
    internal class Program
    {
        public static void ShowOrderInfo(Order[] orders)
        {
            foreach (var order in orders)
            {
                if (order != null)
                {
                    Console.WriteLine($"Номер заказа: {order.Id}");
                    foreach (var product in order.Products)
                    {
                        Console.WriteLine($" - {product.Name} ({product.Quantity})");
                    }

                    Console.WriteLine($"Общее кол-во: {order.TotalQuantity}");
                    Console.WriteLine();
                }
            }
        }

        public static void Main(string[] args)
        {
            Product[] products = new Product[]
            {
                new Product("iPhone X", 10),
                new Product("Samsung Galaxy S21", 12),
                new Product("Xiaomi Redmi Note 8 Pro", 11),
                new Product("Xiaomi Redmi Note 10 Pro", 4),
                new Product("iPhone 13", 18)
            };
            Order[] orders;

            Catalog catalogOfProducts = Catalog.Instance;
            catalogOfProducts.Products = products;

            ShoppingCart shoppingCart = new ShoppingCart(catalogOfProducts);
            shoppingCart.AddToCart(new Product("iPhone X", 10), new Product("Samsung Galaxy S21", 1));
            Order order1 = shoppingCart.MakeAnOrder();
            Console.WriteLine();

            shoppingCart.AddToCart(new Product("iPhone 13", 1));
            Order order2 = shoppingCart.MakeAnOrder();
            Console.WriteLine();

            orders = new Order[] { order1, order2 };

            ShowOrderInfo(orders);
        }
    }
}
