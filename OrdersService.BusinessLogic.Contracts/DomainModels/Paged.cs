namespace OrdersService.BusinessLogic.Contracts.DomainModels
{
    public class Paged<T>
    {
        public T Data { get; set; }
        public int Total { get; set; }
    }
}