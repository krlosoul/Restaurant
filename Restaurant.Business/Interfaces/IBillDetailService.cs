namespace Restaurant.Business.Interfaces
{
    using Restaurant.Core.Dtos;
    using Restaurant.Core.Services;
    using System.Threading.Tasks;

    public interface IBillDetailService
    {
        /// <summary>
        /// Create bill details async.
        /// </summary>
        /// <param name="createBillDetailsDto">The Dto CreateBillDetailsDto.</param>
        /// <returns>&lt;ResponseService&gt;.</returns>
        Task<ResponseService> CreateBillDetailsAsync(CreateBillDetailsDto createBillDetailsDto);
    }
}
