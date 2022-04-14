namespace Cot.API.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
