namespace Module2HW2
{
    public class Catalog
    {
        private static readonly Catalog _instance = new Catalog();

        static Catalog()
        {
        }

        private Catalog()
        {
        }

        public static Catalog Instance
        {
            get
            {
                return _instance;
            }
        }

        public Product[] Products { get; set; }

        public void AddProducts(params Product[] products)
        {
            Products = products;
        }
    }
}
