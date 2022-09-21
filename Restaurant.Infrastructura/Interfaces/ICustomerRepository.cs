namespace Restaurant.Infrastructure.Interfaces
{
    using Restaurant.Core.Dtos;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICustomerRepository<T> : IRepository<T> where T : class
    {
        /// <summary>
        /// Get customer spend by date range and spend min async.
        /// </summary>
        /// <param name="getCustomerDto">The Dto GetCustomerDto.</param>
        /// <returns>&lt;IEnumerable&lt;CustomerSpendDto&gt;&gt;.</returns>
        public Task<IEnumerable<CustomerSpendDto>> GetCustomerSpendAsync(GetCustomerDto getCustomerDto);
    }
}
