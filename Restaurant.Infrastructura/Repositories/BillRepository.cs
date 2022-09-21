namespace Restaurant.Infrastructure.Repositories
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using Restaurant.Core.Dtos;
    using Restaurant.Core.Entities;
    using Restaurant.Infrastructure.DataAccess;
    using Restaurant.Infrastructure.Extensions;
    using Restaurant.Infrastructure.Interfaces;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class BillRepository : Repository<Bill>, IBillRepository<Bill>
    {
        private readonly RestaurantContext _context;

        public BillRepository(RestaurantContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<IEnumerable<BillsWithDetailsDto>> GetBillsWithDetailsAsync(GetBillsWithDetailsDto getBillsWithDetailsDto)
        {
            return await _context.Bills
                .WhereIf(getBillsWithDetailsDto.IdBill != null, x => x.IdBill == getBillsWithDetailsDto.IdBill)
                .WhereIf(!string.IsNullOrEmpty(getBillsWithDetailsDto.IdCustomer), x => x.IdCustomer == getBillsWithDetailsDto.IdCustomer)
                .WhereIf(getBillsWithDetailsDto.IdDiningTable != null, x => x.IdDiningTable == getBillsWithDetailsDto.IdDiningTable)
                .WhereIf(getBillsWithDetailsDto.IdWaiter != null, x => x.IdWaiter == getBillsWithDetailsDto.IdWaiter)
                .WhereIf(getBillsWithDetailsDto.IdWaiter != null, x => x.BillDetails.Any(s => s.IdFood == getBillsWithDetailsDto.IdFood))
                .Select(x => new BillsWithDetailsDto
                {
                    IdBill = x.IdBill,
                    CreationDate = x.CreationDate,
                    Customer = x.Customer.FirstName + " " + x.Customer.LastName,
                    Waiter = x.Waiter.FirstName + " " + x.Waiter.LastName,
                    DiningTable = x.DiningTable.Name,
                    Price = x.BillDetails.Sum(x => x.Price),
                    BillDetailsDto = Mapper.Map<List<BillDetailsDto>>(
                        x.BillDetails.Join(
                            _context.Foods,
                            detail => new { x1 = detail.IdFood },
                            food => new { x1 = food.IdFood },
                            (detail, food) => new { detail = detail, food = food }
                        )
                        .Select(y => new BillDetailsDto
                        {
                            Quantity = y.detail.Quantity,
                            Price = y.detail.Price,
                            Food = y.food.Name
                        })
                    )
                }).ToListAsync();
        }
    }
}
