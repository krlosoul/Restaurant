namespace Restaurant.Business.Interfaces
{
    using Restaurant.Core.Dtos;
    using Restaurant.Core.Services;
    using System.Threading.Tasks;

    public interface IDiningTableService
    {
        /// <summary>
        /// Get all dining table async.
        /// </summary>
        /// <returns>&lt;ResponseService&gt;.</returns>
        Task<ResponseService> GetDiningTableAsync();

        /// <summary>
        /// Create dining table async.
        /// </summary>
        /// <param name="createDiningTableDto">The CreateDiningTableDto.</param>
        /// <returns>&lt;ResponseService&gt;.</returns>
        Task<ResponseService> CreateDiningTableAsync(CreateDiningTableDto createDiningTableDto);

        /// <summary>
        /// Update dining table async.
        /// </summary>
        /// <param name="diningTableDto">The DiningTableDto.</param>
        /// <returns>&lt;ResponseService&gt;.</returns>
        Task<ResponseService> UpdateDiningTableAsync(DiningTableDto diningTableDto);

        /// <summary>
        /// Delete dining table async.
        /// </summary>
        /// <param name="idDiningTable">The dining table identification.</param>
        /// <returns>&lt;ResponseService&gt;.</returns>
        Task<ResponseService> DeleteDiningTableAsync(int idDiningTable);
    }
}
