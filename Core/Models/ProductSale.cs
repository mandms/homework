namespace Core.Models
{
    public class ProductSale
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public int Count { get; set; }  
        public DateTime DateTime { get; set; }
    }
}
