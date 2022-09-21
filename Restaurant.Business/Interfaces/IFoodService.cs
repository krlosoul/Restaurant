namespace Restaurant.Business.Interfaces
{
    using Restaurant.Core.Dtos;
    using Restaurant.Core.Services;
    using System.Threading.Tasks;

    public interface IFoodService
    {
        /// <summary>
        /// Get all food async.
        /// </summary>
        /// <returns>&lt;ResponseService&gt;.</returns>
        Task<ResponseService> GetFoodAsync();

        /// <summary>
        /// Create food async.
        /// </summary>
        /// <param name="createFoodDto">The CreateFoodDto.</param>
        /// <returns>&lt;ResponseService&gt;.</returns>
        Task<ResponseService> CreateFoodAsync(CreateFoodDto createFoodDto);

        /// <summary>
        /// Update food async.
        /// </summary>
        /// <param name="foodDto">The FoodDto.</param>
        /// <returns>&lt;ResponseService&gt;.</returns>
        Task<ResponseService> UpdateFoodAsync(FoodDto foodDto);

        /// <summary>
        /// Delete food async.
        /// </summary>
        /// <param name="idFood">The food identification.</param>
        /// <returns>&lt;ResponseService&gt;.</returns>
        Task<ResponseService> DeleteFoodAsync(int idFood);

        /// <summary>
        /// Get sales food async.
        /// </summary>
        /// <param name="dateRangeDto">The Dto DateRangeDto.</param>
        /// <returns>&lt;ResponseService&gt;.</returns>
        public Task<ResponseService> GetSalesFoodAsync(DateRangeDto dateRangeDto);
    }
}
