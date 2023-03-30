namespace Orders.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int VendorCode { get; set; }
        public uint Price { get; set; }

        public Product(string name,uint price, int vendorCode)
        {
            Id = default;
            Name = name;
            VendorCode = vendorCode;
            Price = price;
        }
    }
}
