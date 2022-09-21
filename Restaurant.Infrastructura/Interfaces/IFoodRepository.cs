namespace Restaurant.Infrastructure.Interfaces
{
    using Restaurant.Core.Dtos;
    using System.Threading.Tasks;

    public interface IFoodRepository<T> : IRepository<T> where T : class
    {
        /// <summary>
        /// Get sales food async.
        /// </summary>
        /// <param name="dateRangeDto">The Dto DateRangeDto.</param>
        /// <returns>&lt;SalesFoodDto&gt;.</returns>
        public Task<SalesFoodDto> GetSalesFoodAsync(DateRangeDto dateRangeDto);
    }
}
