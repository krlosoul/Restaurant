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

    public class CustomerRepository : Repository<Customer>, ICustomerRepository<Customer>
    {
        private readonly RestaurantContext _context;

        public CustomerRepository(RestaurantContext comidasContext) : base(comidasContext)
        {
            _context = comidasContext;
        }

        public async Task<IEnumerable<CustomerSpendDto>> GetCustomerSpendAsync(GetCustomerDto getCustomerDto)
        {
            var customerSpend = await _context.BillDetails
                .Where(x => x.Bill.CreationDate >= getCustomerDto.StartDate)
                .Where(x => x.Bill.CreationDate <= getCustomerDto.EndDate)
                .Select(x => new
                {
                    x.Price,
                    x.Bill.Customer.IdCustomer,
                    x.Bill.Customer.FirstName,
                    x.Bill.Customer.LastName
                }).ToListAsync();

            return customerSpend
                .GroupBy(x => x.IdCustomer)
                .Select(x => new CustomerSpendDto
                {
                    FirstName = x.FirstOrDefault().FirstName,
                    LastName = x.FirstOrDefault().LastName,
                    Spent = x.Sum(x => x.Price)
                })
                .Where(x => x.Spent >= getCustomerDto.Spent)
                .ToList();
        }
    }
}
