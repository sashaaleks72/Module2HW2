namespace Module2HW2
{
    public class Catalog
    {
        private static readonly Catalog _instance = new Catalog();

        private Catalog()
        {
            Products = new Product[]
            {
                new Product("iPhone X", 10),
                new Product("Samsung Galaxy S21", 12),
                new Product("Xiaomi Redmi Note 8 Pro", 11),
                new Product("Xiaomi Redmi Note 10 Pro", 4),
                new Product("iPhone 13", 18)
            };
        }

        public static Catalog Instance
        {
            get
            {
                return _instance;
            }
        }

        public Product[] Products { get; set; }
    }
}
