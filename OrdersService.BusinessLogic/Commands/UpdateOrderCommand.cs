namespace OrdersService.BusinessLogic.Commands
{
    public sealed class UpdateOrderCommand : OrderCommand
    {
        public string OrderId { get; set; }
    }
}
