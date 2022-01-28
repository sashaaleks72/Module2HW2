using System;

namespace Module2HW2
{
    public class CatalogService
    {
        public CatalogService(Catalog catalog)
        {
            Catalog = catalog;
        }

        public Catalog Catalog { get; set; }

        public void ShowCatalog()
        {
            Console.WriteLine("Product list\n");

            for (int i = 0; i < Catalog.Products.Length; i++)
            {
                Console.WriteLine($"Product {i + 1}:\nName: {Catalog.Products[i].Name}\nQuantity: {Catalog.Products[i].Quantity}\n");
            }
        }
    }
}
