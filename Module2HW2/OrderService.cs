using System;

namespace Module2HW2
{
    public class OrderService
    {
        private MessageService _message;
        private CartService _cartService;

        public OrderService(CartService cartService)
        {
            Orders = new Order[0];
            _cartService = cartService;
            _message = new MessageService();
        }

        public OrderService(CartService cartService, int quantityOfOrders)
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

        public Order MakeAnOrder()
        {
            Order order;
            bool negativeQuantity = false;

            if (_cartService.CheckTotalQuantity())
            {
                order = null;
                _message.ShowErrorMsg("Reduce the number of items!");
                return order;
            }

            for (int i = 0; i < _cartService.ShoppingCart.SelectedProducts.Length; i++)
            {
                for (int j = 0; j < _cartService.Catalog.Products.Length; j++)
                {
                    if (_cartService.ShoppingCart.SelectedProducts[i].Name == _cartService.Catalog.Products[j].Name)
                    {
                        if (_cartService.ShoppingCart.SelectedProducts[i].Quantity <= _cartService.Catalog.Products[j].Quantity)
                        {
                            _cartService.Catalog.Products[j].Quantity -= _cartService.ShoppingCart.SelectedProducts[i].Quantity;
                        }
                        else
                        {
                            negativeQuantity = true;
                        }
                    }
                }
            }

            if (negativeQuantity)
            {
                order = null;
                _message.ShowErrorMsg("The number of selected products is more than exists in stock!");
            }
            else
            {
                order = new Order(_cartService.ShoppingCart.SelectedProducts);
                _message.ShowSuccessMsg($"Order successfully completed\nNumber of order: {order.Id}");
            }

            return order;
        }

        public void AddOrderToList(Order order)
        {
            Orders[order.Id - 1] = order;
        }
    }
}
