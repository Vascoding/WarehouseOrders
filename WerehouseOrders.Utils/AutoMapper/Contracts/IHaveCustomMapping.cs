using AutoMapper;

namespace WerehouseOrders.Utils.AutoMapper.Contracts
{
    public interface IHaveCustomMapping
    {
        void ConfigureMapping(Profile profile);
    }
}
