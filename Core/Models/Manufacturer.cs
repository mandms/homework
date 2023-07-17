namespace Core.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public List<Product> Products { get; set; } = new List<Product>();

        public override string ToString()
        {
            return this.Name;
        }
    }
}
