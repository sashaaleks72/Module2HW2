namespace Module2HW2
{
    public class Order
    {
        private static int _id;

        public Order(Product[] products)
        {
            Products = products;
            _id++;
            Id = _id;
        }

        public int Id { get; set; }
        public Product[] Products { get; set; }
        public int TotalQuantity
        {
            get
            {
                int totalQuantity = 0;

                for (int i = 0; i < Products.Length; i++)
                {
                    totalQuantity += Products[i].Quantity;
                }

                return totalQuantity;
            }
        }
    }
}
