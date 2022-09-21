namespace Restaurant.Infrastructure.DataAccess
{
    using Microsoft.EntityFrameworkCore.Storage;
    using Restaurant.Core.Entities;
    using Restaurant.Infrastructure.Interfaces;
    using Restaurant.Infrastructure.Repositories;
    using System.Threading.Tasks;

    public class UnitOfWork : IUnitOfWork
    {
        #region Properties
        public RestaurantContext DbContext { get; set; }

        private IDbContextTransaction _transaction;

        private ICustomerRepository<Customer> _customer;
        private IWaiterRepository<Waiter> _waiter;
        private IFoodRepository<Food> _food;
        private IRepository<DiningTable> _dinningTable;
        private IBillRepository<Bill> _bill;
        private IRepository<BillDetail> _billDetail;
        #endregion

        public UnitOfWork(RestaurantContext dbContext)
        {
            DbContext = dbContext;
        }

        #region Transactions
        private async Task SaveAsync()
        {
            await DbContext.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync()
        {
            _transaction ??= await DbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                await SaveAsync();
            }
        }

        public async Task CloseTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
            }
        }
        #endregion

        #region Repositories
        public ICustomerRepository<Customer> Customer
        {
            get
            {
                return _customer ??= new CustomerRepository(DbContext);
            }
        }

        public IWaiterRepository<Waiter> Waiter
        {
            get
            {
                return _waiter ??= new WaiterRepository(DbContext);
            }
        }

        public IFoodRepository<Food> Food
        {
            get
            {
                return _food ??= new FoodRepository(DbContext);
            }
        }

        public IRepository<DiningTable> DiningTable
        {
            get
            {
                return _dinningTable ??= new Repository<DiningTable>(DbContext);
            }
        }

        public IBillRepository<Bill> Bill
        {
            get
            {
                return _bill ??= new BillRepository(DbContext);
            }
        }

        public IRepository<BillDetail> BillDetail
        {
            get
            {
                return _billDetail ??= new Repository<BillDetail>(DbContext);
            }
        }
        #endregion
    }
}
