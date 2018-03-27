namespace OrdersService.BusinessLogic.Contracts.Persistance
{
    public class OrderEntity
    {
        public string DisplayId { get; set; }
        public double Price { get; set; }
        public string Address { get; set; }
        public string CustomerName { get; set; }
    }
}