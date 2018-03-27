using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrdersService.BusinessLogic.Contracts.Persistance;
using OrdersService.DataAccess.Models;

namespace OrdersService.DataAccess
{
    public class OrdersRepository : IOrdersRepository
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
            var data = await _context.Orders.FirstOrDefaultAsync(x => x.DisplayId == id);

            return _mapper.Map<OrderEntity>(data);
        }

        public async Task<Paged<OrderEntity[]>> GetByPageAsync(int page)
        {
            var data = await _context.Orders
                .OrderBy(x => x.DisplayId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToArrayAsync();

            return new Paged<OrderEntity[]>
            {
                Total = await _context.Orders.CountAsync(),
                Data = _mapper.Map<OrderEntity[]>(data)
            };
        }

        public async Task AddOrUpdateAsync(OrderEntity entity)
        {
            var data = await _context.Orders.FirstOrDefaultAsync(x => x.DisplayId == entity.DisplayId);
            if (data != null)
            {
                _mapper.Map(entity, data);
            }
            else
            {
                data = _mapper.Map<Orders>(entity);
                await _context.Orders.AddAsync(data);
            }

            await _context.SaveChangesAsync();
        }
    }
}