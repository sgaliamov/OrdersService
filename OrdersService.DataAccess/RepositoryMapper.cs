using AutoMapper;
using OrdersService.BusinessLogic.Contracts.DomainModels;
using OrdersService.DataAccess.Entities;

namespace OrdersService.DataAccess
{
    public static class RepositoryMapper
    {
        public static void ConfigureMapper(IMapperConfigurationExpression config)
        {
            config.CreateMap<OrderEntity, Orders>()
                  .ForMember(m => m.Id, c => c.Ignore())
                  .ForMember(m => m.CreationTimestamp, c => c.Ignore())
                  .ForMember(m => m.Version, c => c.Ignore());
        }
    }
}
