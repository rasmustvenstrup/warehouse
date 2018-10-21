namespace Warehouse.Entities
{
    public class OrderProduct : Entity
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}