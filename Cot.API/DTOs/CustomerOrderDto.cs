namespace Cot.API.DTOs
{
    public class CustomerOrderDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
    }
}
