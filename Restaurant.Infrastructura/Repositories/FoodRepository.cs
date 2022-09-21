namespace Restaurant.Infrastructure.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using Restaurant.Core.Dtos;
    using Restaurant.Core.Entities;
    using Restaurant.Infrastructure.DataAccess;
    using Restaurant.Infrastructure.Interfaces;
    using System.Linq;
    using System.Threading.Tasks;

    public class FoodRepository : Repository<Food>, IFoodRepository<Food>
    {
        private readonly RestaurantContext _context;

        public FoodRepository(RestaurantContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<SalesFoodDto> GetSalesFoodAsync(DateRangeDto dateRangeDto)
        {
            var salesFood = await _context.BillDetails
               .Where(x => x.Bill.CreationDate >= dateRangeDto.StartDate)
               .Where(x => x.Bill.CreationDate <= dateRangeDto.EndDate)
               .Select(x => new
               {
                   x.Food.IdFood,
                   x.Food.Name,
                   x.Quantity,
                   x.Price
               }).ToListAsync();

            return salesFood
                .GroupBy(x => x.IdFood)
                .Select(x => new SalesFoodDto
                {
                    Name = x.FirstOrDefault().Name,
                    Total = x.Sum(x => x.Price),
                    Quantity = x.Sum(x => x.Quantity)
                })
                .OrderByDescending(x => x.Quantity)
                .FirstOrDefault();
        }
    }
}
