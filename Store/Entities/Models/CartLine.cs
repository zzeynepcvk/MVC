namespace Entities.Models
{
    public class CartLine
    {
        public int Cartline { get; set; }
        public Product Product { get; set; } = new();
        public int Quantity { get; set; }
    }
}