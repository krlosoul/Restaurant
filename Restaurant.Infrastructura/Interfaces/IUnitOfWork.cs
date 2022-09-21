namespace Restaurant.Infrastructure.Interfaces
{
    using Restaurant.Core.Entities;
    using Restaurant.Infrastructure.DataAccess;
    using Restaurant.Infrastructure.Interfaces;
    using System.Threading.Tasks;

    public interface IUnitOfWork
    {
        #region Properties
        /// <summary>
        /// Represents a session with the database and can be used to query and save.
        /// </summary>
        /// <returns>&lt;RestaurantContext&gt;.</returns>
        RestaurantContext DbContext { get; }
        #endregion

        #region Transactions
        /// <summary>
        /// starts a new transaction asynchronous.
        /// </summary>
        public Task BeginTransactionAsync();

        /// <summary>
        /// Commits all changes made to the database in the current transaction asynchronously.
        /// </summary>
        public Task CommitTransactionAsync();

        /// <summary>
        /// releasing, or resetting unmanaged resources asynchronously.
        /// </summary>
        public Task CloseTransactionAsync();

        /// <summary>
        /// Discards all changes made to the database in the current transaction asynchronously.
        /// </summary>
        public Task RollbackTransactionAsync();
        #endregion

        #region Repositories
        ICustomerRepository<Customer> Customer { get; }
        IWaiterRepository<Waiter> Waiter { get; }
        IFoodRepository<Food> Food { get; }
        IRepository<DiningTable> DiningTable { get; }
        IBillRepository<Bill> Bill { get; }
        IRepository<BillDetail> BillDetail { get; }
        #endregion
    }
}

