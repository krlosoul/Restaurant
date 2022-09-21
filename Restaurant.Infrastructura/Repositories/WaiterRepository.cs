namespace Restaurant.Infrastructure.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using Restaurant.Core.Dtos;
    using Restaurant.Core.Entities;
    using Restaurant.Infrastructure.DataAccess;
    using Restaurant.Infrastructure.Interfaces;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class WaiterRepository : Repository<Waiter>, IWaiterRepository<Waiter>
    {
        private readonly RestaurantContext _context;

        public WaiterRepository(RestaurantContext comidasContext) : base(comidasContext)
        {
            _context = comidasContext;
        }

        public async Task<IEnumerable<WaiterSalesDto>> GetWaiterSalesAsync(DateRangeDto dateRangeDto)
        {
            var waiterSales = await _context.Waiters
                .GroupJoin(
                    _context.Bills
                    .Where(x => x.CreationDate >= dateRangeDto.StartDate)
                    .Where(x => x.CreationDate <= dateRangeDto.EndDate),
                    waiter => new { x1 = waiter.IdWaiter },
                    bill => new { x1 = bill.IdWaiter },
                    (waiter, bill) => new { waiter, bill }
                )
                .SelectMany(
                    waiterBills => waiterBills.bill.DefaultIfEmpty(),
                    (waiterBills, bill) => new { waiterBills.waiter, bill }
                )
                .GroupJoin(
                    _context.BillDetails,
                    waiterBill => new { x1 = waiterBill.bill.IdBill },
                    billDetail => new { x1 = billDetail.IdBill },
                    (waiterBill, billDetails) => new { waiterBill, billDetails }
                )
                .SelectMany(
                    x => x.billDetails.DefaultIfEmpty(),
                    (waiterBillDetails, billDetail) => new { waiterBillDetails = waiterBillDetails.waiterBill, billDetail }
                )
                .Select(x => new
                {
                    Price = x.billDetail == null ? 0 : x.billDetail.Price,
                    x.waiterBillDetails.waiter.IdWaiter,
                    x.waiterBillDetails.waiter.FirstName,
                    x.waiterBillDetails.waiter.LastName
                })
                .ToListAsync();

            return waiterSales
                .GroupBy(x => x.IdWaiter)
                .Select(x => new WaiterSalesDto
                {
                    FirstName = x.FirstOrDefault().FirstName,
                    LastName = x.FirstOrDefault().LastName,
                    Sales = x.Sum(x => x.Price)
                }).ToList();
        }
    }
}
