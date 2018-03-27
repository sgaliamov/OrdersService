namespace OrdersService.BusinessLogic
{
    public interface ICommandDispatcher
    {
        void Execute<T>(T command);
    }
}