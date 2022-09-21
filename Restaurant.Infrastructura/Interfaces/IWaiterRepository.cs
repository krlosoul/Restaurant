namespace Restaurant.Infrastructure.Interfaces
{
    using Restaurant.Core.Dtos;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IWaiterRepository<T> : IRepository<T> where T : class
    {
        /// <summary>
        /// Get waiter sales async.
        /// </summary>
        /// <param name="dateRangeDto">The Dto DateRangeDto.</param>
        /// <returns>&lt;IEnumerable&lt;WaiterSalesDto&gt;&gt;.</returns>
        public Task<IEnumerable<WaiterSalesDto>> GetWaiterSalesAsync(DateRangeDto dateRangeDto);
    }
}
