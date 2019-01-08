using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrdersService.BusinessLogic.Contracts.DomainModels;
using OrdersService.BusinessLogic.Contracts.Persistence;
using OrdersService.DataAccess.Entities;

namespace OrdersService.DataAccess
{
    public sealed class OrdersRepository : IOrdersRepository
    {
        private const int PageSize = 5;
        private readonly OrdersServiceContext _context;
        private readonly IMapper _mapper;

        public OrdersRepository(
            OrdersServiceContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrderEntity> GetByIdAsync(string id)
        {
            var data = await _context.Orders.FirstOrDefaultAsync(x => x.OrderId == id).ConfigureAwait(false);

            return _mapper.Map<OrderEntity>(data);
        }

        public async Task<Paged<OrderEntity[]>> GetByPageAsync(int page)
        {
            var data = await _context.Orders
                                     .OrderBy(x => x.OrderId)
                                     .Skip((page - 1) * PageSize)
                                     .Take(PageSize)
                                     .ToArrayAsync()
                                     .ConfigureAwait(false);

            return new Paged<OrderEntity[]>
            {
                Total = await _context.Orders.CountAsync().ConfigureAwait(false),
                Data = _mapper.Map<OrderEntity[]>(data)
            };
        }

        public async Task<string> AddOrUpdateAsync(OrderEntity entity)
        {
            var data = await _context.Orders.FirstOrDefaultAsync(x => x.OrderId == entity.OrderId).ConfigureAwait(false);
            if (data != null)
            {
                _mapper.Map(entity, data);
            }
            else
            {
                data = _mapper.Map<Orders>(entity);
                await _context.Orders.AddAsync(data).ConfigureAwait(false);
            }

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return data.OrderId;
        }
    }
}
