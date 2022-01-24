using System;

namespace Module2HW2
{
    public class ShoppingCart
    {
        private int _quantityOfSelectedProds;

        public ShoppingCart(Catalog catalog)
        {
            Catalog = catalog;
        }

        public Catalog Catalog { get; set; }
        public Product[] SelectedProducts { get; set; }

        public bool CheckTotalQuantity()
        {
            bool bigAmountOfSelectedProducts = false;

            if (_quantityOfSelectedProds > 10)
            {
                bigAmountOfSelectedProducts = true;
            }

            return bigAmountOfSelectedProducts;
        }

        public void ShowErrorMsg(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void ShowSuccessMsg(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void AddToCart(params Product[] selectedProducts)
        {
            _quantityOfSelectedProds = 0;
            bool checkSelectedInCatalog = false;

            for (int i = 0; i < selectedProducts.Length; i++)
            {
                for (int j = 0; j < Catalog.Products.Length; j++)
                {
                    if (selectedProducts[i].Name == Catalog.Products[j].Name)
                    {
                        checkSelectedInCatalog = true;
                        _quantityOfSelectedProds += selectedProducts[i].Quantity;
                    }
                }
            }

            if (checkSelectedInCatalog)
            {
                SelectedProducts = selectedProducts;
            }

            if (CheckTotalQuantity())
            {
                ShowErrorMsg("Кол-во выбранных товаров в сумме превышает 10!");
            }
        }

        public Order MakeAnOrder()
        {
            Order order;
            bool negativeQuantity = false;

            for (int i = 0; i < SelectedProducts.Length; i++)
            {
                for (int j = 0; j < Catalog.Products.Length; j++)
                {
                    if (SelectedProducts[i].Name == Catalog.Products[j].Name)
                    {
                        if (SelectedProducts[i].Quantity <= Catalog.Products[j].Quantity)
                        {
                            Catalog.Products[j].Quantity -= SelectedProducts[i].Quantity;
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
                ShowErrorMsg("Кол-во выбранных товаров превышает кол-во товаров на складе!");
            }
            else if (CheckTotalQuantity())
            {
                order = null;
                ShowErrorMsg("Уменьшите кол-во выбранных товаров!");
                _quantityOfSelectedProds = 0;
            }
            else
            {
                order = new Order(SelectedProducts);
                ShowSuccessMsg($"Заказ успешно оформлен\nНомер вашего заказа: {order.Id}");
            }

            return order;
        }
    }
}
