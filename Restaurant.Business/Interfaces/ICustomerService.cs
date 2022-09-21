namespace Restaurant.Business.Interfaces
{
    using Restaurant.Core.Dtos;
    using Restaurant.Core.Services;
    using System.Threading.Tasks;

    public interface ICustomerService
    {
        /// <summary>
        /// Get all customers async.
        /// </summary>
        /// <returns>&lt;ResponseService&gt;.</returns>
        Task<ResponseService> GetCustomerAsync();

        /// <summary>
        /// Create customer async.
        /// </summary>
        /// <param name="customerDto">The CustomerDto.</param>        
        /// <returns>&lt;ResponseService&gt;.</returns>
        Task<ResponseService> CreateCustomerAsync(CustomerDto customerDto);

        /// <summary>
        /// Update customer async.
        /// </summary>
        /// <param name="customerDto">The CustomerDto.</param>
        /// <returns>&lt;ResponseService&gt;.</returns>
        Task<ResponseService> UpdateCustomerAsync(CustomerDto customerDto);

        /// <summary>
        /// Delete customer async.
        /// </summary>
        /// <param name="idCustomer">The customer identification.</param>
        /// <returns>&lt;ResponseService&gt;.</returns>
        Task<ResponseService> DeleteCustomerAsync(string idCustomer);

        /// <summary>
        /// Get customer spend by date range and spend min async.
        /// </summary>
        /// <param name="getCustomerDto">The GetCustomerDto.</param>
        /// <returns>&lt;ResponseService&gt;.</returns>
        Task<ResponseService> GetCustomerSpendAsync(GetCustomerDto getCustomerDto);
    }
}
