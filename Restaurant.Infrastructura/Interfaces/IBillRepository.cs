namespace Restaurant.Infrastructure.Interfaces
{
    using Restaurant.Core.Dtos;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBillRepository<T> : IRepository<T> where T : class
    {
        /// <summary>
        /// Get bills with details async.
        /// </summary>
        /// <param name="getBillsWithDetailsDto">The Dto GetBillsWithDetailsDto.</param>
        /// <returns>&lt;IEnumerable&lt;BillsWithDetailsDto&gt;&gt;.</returns>
        public Task<IEnumerable<BillsWithDetailsDto>> GetBillsWithDetailsAsync(GetBillsWithDetailsDto getBillsWithDetailsDto);
    }
}
