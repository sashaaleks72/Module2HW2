using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2HW2
{
    public class Starter
    {
        private MessageService _message;

        public Starter()
        {
            CatalogOfProducts = Catalog.Instance;
            CatalogService = new CatalogService(CatalogOfProducts);
            ShoppingCart = new ShoppingCart();
            CartService = new CartService(ShoppingCart, CatalogOfProducts);
            OrderService = new OrderService(CartService);
            _message = new MessageService();
        }

        public Catalog CatalogOfProducts { get; init; }
        public CatalogService CatalogService { get; init; }
        public OrderService OrderService { get; init; }
        public ShoppingCart ShoppingCart { get; init; }
        public CartService CartService { get; init; }
        public Order Order { get; set; }

        public void Run()
        {
            CatalogService.ShowCatalog();

            int quanOfOrders;
            _message.ShowMsg("Quantity of orders: ");
            quanOfOrders = Convert.ToInt32(Console.ReadLine());
            OrderService.Orders = new Order[quanOfOrders];

            for (int i = 0; i < quanOfOrders; i++)
            {
                CartService.AddToCart();
                Order = OrderService.MakeAnOrder();

                if (Order != null)
                {
                    OrderService.AddOrderToList(Order);
                }
            }

            OrderService.ShowOrders();
            Console.WriteLine();
        }
    }
}
