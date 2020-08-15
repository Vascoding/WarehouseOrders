namespace WerehouseOrders.Services.Contracts
{
    public interface IMappingService
    {
        TDestination Map<TDestination>(object source);
    }
}