namespace Restaurant.Business.Interfaces
{
    using Restaurant.Core.Dtos;
    using Restaurant.Core.Services;
    using System.Threading.Tasks;

    public interface IWaiterService
    {
        /// <summary>
        /// Get all waiter async.
        /// </summary>
        /// <returns>&lt;ResponseService&gt;.</returns>
        Task<ResponseService> GetWaiterAsync();

        /// <summary>
        /// Create waiter async.
        /// </summary>
        /// <param name="createWaiterDto">The CreateWaiterDto.</param>
        /// <returns>&lt;ResponseService&gt;.</returns>
        Task<ResponseService> CreateWaiterAsync(CreateWaiterDto createWaiterDto);

        /// <summary>
        /// Update waiter async.
        /// </summary>
        /// <param name="waiterDto">The WaiterDto.</param>
        /// <returns>&lt;ResponseService&gt;.</returns>
        Task<ResponseService> UpdateWaiterAsync(WaiterDto waiterDto);

        /// <summary>
        /// Delete waiter async.
        /// </summary>
        /// <param name="idWaiter">The waiter identification.</param>
        /// <returns>&lt;ResponseService&gt;.</returns>
        Task<ResponseService> DeleteWaiterAsync(int idWaiter);

        /// <summary>
        /// Get waiter sales async.
        /// </summary>
        /// <param name="dateRangeDto">The DateRangeDto.</param>
        /// <returns>&lt;ResponseService&gt;.</returns>
        Task<ResponseService> GetWaiterSalesAsync(DateRangeDto dateRangeDto);
    }
}
