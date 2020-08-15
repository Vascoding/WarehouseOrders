using AutoMapper;
using WerehouseOrders.Services.Contracts;
using WerehouseOrders.Utils.AutoMapper;

namespace WerehouseOrders.Services.Implementations
{
    public class MappingService : IMappingService
    {
        private Mapper mapper;
        
        public MappingService()
        {
            var configurations = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });

            this.mapper = new Mapper(configurations);
        }

        public TDestination Map<TDestination>(object source)
        {
            return this.mapper.Map<TDestination>(source);
        }
    }
}