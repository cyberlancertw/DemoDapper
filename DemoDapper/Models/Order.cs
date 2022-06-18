namespace DemoDapper.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
