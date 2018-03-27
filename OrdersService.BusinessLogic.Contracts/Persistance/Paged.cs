namespace OrdersService.BusinessLogic.Contracts.Persistance
{
    public class Paged<T>
    {
        public T Data { get; set; }
        public int Total { get; set; }
    }
}