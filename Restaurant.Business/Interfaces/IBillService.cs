namespace Restaurant.Business.Interfaces
{
    using Restaurant.Core.Dtos;
    using Restaurant.Core.Services;
    using System.Threading.Tasks;

    public interface IBillService
    {
        /// <summary>
        /// Create bill async.
        /// </summary>
        /// <param name="createBillDto">The CreateBillDto.</param>
        /// <returns>&lt;ResponseService&gt;.</returns>
        Task<ResponseService> CreateBillAsync(CreateBillDto createBillDto);

        /// <summary>
        /// Get bill detail async.
        /// </summary>
        /// <param name="getBillsWithDetailsDto">The GetBillDetailDto.</param>
        /// <returns>&lt;ResponseService&gt;.</returns>
        Task<ResponseService> GetBillsWithDetailsAsync(GetBillsWithDetailsDto getBillsWithDetailsDto);
    }
}
