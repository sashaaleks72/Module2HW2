namespace Module2HW2
{
    public class Product
    {
        public Product(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
