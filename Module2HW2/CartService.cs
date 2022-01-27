using System;
using System.Text;

namespace Module2HW2
{
    public class CartService
    {
        private int _quantityOfSelectedProds;
        private MessageService _message;
        private ShoppingCart _shoppingCart;

        public CartService(ShoppingCart shoppingCart, Catalog catalog)
        {
            _message = new MessageService();
            _shoppingCart = shoppingCart;
            Catalog = catalog;
        }

        public Catalog Catalog { get; set; }

        public bool CheckTotalQuantity()
        {
            bool bigAmountOfSelectedProducts = false;

            if (_quantityOfSelectedProds > 10)
            {
                bigAmountOfSelectedProducts = true;
            }

            return bigAmountOfSelectedProducts;
        }

        public void AddToCart()
        {
            _quantityOfSelectedProds = 0;

            StringBuilder namesOfProducts = new StringBuilder();
            StringBuilder quantitiesOfProducts = new StringBuilder();
            string productName;

            string[] splitedNamesOfProducts;
            string[] splitedQuantities;
            string answer;

            int quantityOfPositions = 0;

            bool checkSelectedInCatalog;

            while (true)
            {
                checkSelectedInCatalog = false;

                Console.Write("Write name of product which you wanna buy: ");
                productName = Console.ReadLine();

                for (int i = 0; i < Catalog.Products.Length; i++)
                {
                    if (productName == Catalog.Products[i].Name)
                    {
                        checkSelectedInCatalog = true;
                    }
                }

                if (!checkSelectedInCatalog)
                {
                    _message.ShowErrorMsg("The product with this title doesn't exist!");
                    Console.WriteLine("Try again, please");
                    continue;
                }

                namesOfProducts.Append(productName);

                Console.Write("Write quantity of product: ");
                quantitiesOfProducts.Append(Console.ReadLine());
                Console.WriteLine("Do you wanna select another one?(Y/N)");
                answer = Console.ReadLine();

                quantityOfPositions++;

                if (answer.ToUpper() == "Y")
                {
                    namesOfProducts.Append(",");
                    quantitiesOfProducts.Append(",");
                    continue;
                }
                else
                {
                    break;
                }
            }

            splitedNamesOfProducts = namesOfProducts.ToString().Split(',');
            splitedQuantities = quantitiesOfProducts.ToString().Split(',');
            _shoppingCart.SelectedProducts = new Product[quantityOfPositions];

            for (int i = 0; i < quantityOfPositions; i++)
            {
                _shoppingCart.SelectedProducts[i] = new Product(splitedNamesOfProducts[i], Convert.ToInt32(splitedQuantities[i]));
                _quantityOfSelectedProds += _shoppingCart.SelectedProducts[i].Quantity;
            }

            if (CheckTotalQuantity())
            {
                _message.ShowErrorMsg("The number of selected products is more than 10!");
            }
        }

        public Order MakeAnOrder()
        {
            Order order;
            bool negativeQuantity = false;

            for (int i = 0; i < _shoppingCart.SelectedProducts.Length; i++)
            {
                for (int j = 0; j < Catalog.Products.Length; j++)
                {
                    if (_shoppingCart.SelectedProducts[i].Name == Catalog.Products[j].Name)
                    {
                        if (_shoppingCart.SelectedProducts[i].Quantity <= Catalog.Products[j].Quantity)
                        {
                            Catalog.Products[j].Quantity -= _shoppingCart.SelectedProducts[i].Quantity;
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
            else if (CheckTotalQuantity())
            {
                order = null;
                _message.ShowErrorMsg("Reduce the number of items!");
                _quantityOfSelectedProds = 0;
            }
            else
            {
                order = new Order(_shoppingCart.SelectedProducts);
                _message.ShowSuccessMsg($"Order successfully completed\nNumber of order: {order.Id}");
            }

            return order;
        }
    }
}
