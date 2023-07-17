namespace Core.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; } = null!;
        public List<Image> Images { get; set; } = new List<Image>();
        public List<ProductSale> ProductSales { get; set; } = new List<ProductSale>();

        public override string ToString()
        {
            return $"{this.Name} : {this.Price} - {this.Manufacturer.Name}"; 
        }
    }
}
