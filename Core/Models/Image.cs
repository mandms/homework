namespace Core.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Path { get; set; }
        public bool IsMain { get; set; }
        public int productId { get; set; }
        public Product? Product { get; set; }
    }
}
