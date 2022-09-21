namespace Restaurant.UnitTest.Services
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Restaurant.Business.UseCases;
    using Restaurant.Core.Dtos;
    using Restaurant.Core.Entities;
    using Restaurant.Core.Exceptions;
    using Restaurant.Core.Services;
    using Restaurant.Infrastructure.Interfaces;
    using Restaurant.Infrastructure.Mapper;
    using Restaurant.UnitTest.Stubs;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    [TestClass]
    public class CustomerServiceTest
    {
        private MockRepository _mockRepository;
        private Mock<IUnitOfWork> _unitOfWork;

        private CustomerService Service()
        {
            return new CustomerService(_unitOfWork.Object);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            AutoMapper.Mapper.Reset();
            AutoMapperConfig.CreateMaps();

            _mockRepository = new MockRepository(MockBehavior.Strict);
            _unitOfWork = new Mock<IUnitOfWork>();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetCustomer_ReturnsResponseService_WhenExistsDataAsync()
        {
            _unitOfWork.Setup(x => x.Customer.GetAllAsync()).ReturnsAsync(CustomerStub.customers);

            CustomerService service = Service();
            ResponseService result = await service.GetCustomerAsync();

            Assert.IsTrue(result.Status);

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetCustomer_ReturnsResponseService_WhenDoesExistsDataAsync()
        {
            _unitOfWork.Setup(x => x.Customer.GetAllAsync()).ReturnsAsync(new List<Customer>());

            CustomerService service = Service();
            ResponseService result = await service.GetCustomerAsync();

            Assert.IsFalse(result.Status);

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetCustomer_ReturnsResponseService_ExceptionAsync()
        {
            _unitOfWork.Setup(x => x.Customer.GetAllAsync()).Throws(new Exception());

            CustomerService service = Service();
            await Assert.ThrowsExceptionAsync<UseCaseException>(async () => await service.GetCustomerAsync());

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task CreateCustomer_ReturnsResponseService_WhenExistsDataAsync()
        {
            _unitOfWork.Setup(x => x.Customer.InsertAsync(It.IsAny<Customer>())).ReturnsAsync(true);

            CustomerService service = Service();
            ResponseService result = await service.CreateCustomerAsync(CustomerStub.customerDto);

            Assert.IsTrue(result.Status);

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task CreateCustomer_ReturnsResponseService_WhenDoesExistsDataAsync()
        {
            _unitOfWork.Setup(x => x.Customer.InsertAsync(It.IsAny<Customer>())).ReturnsAsync(false);

            CustomerService service = Service();
            ResponseService result = await service.CreateCustomerAsync(CustomerStub.customerDto);

            Assert.IsFalse(result.Status);

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task CreateCustomer_ReturnsResponseService_ExceptionAsync()
        {
            _unitOfWork.Setup(x => x.Customer.InsertAsync(It.IsAny<Customer>())).Throws(new Exception());

            CustomerService service = Service();
            await Assert.ThrowsExceptionAsync<UseCaseException>(async () => await service.CreateCustomerAsync(CustomerStub.customerDto));

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task UpdateCustomer_ReturnsResponseService_WhenExistsDataAsync()
        {
            _unitOfWork.Setup(x => x.Customer.UpdateAsync(It.IsAny<Customer>())).ReturnsAsync(true);
            _unitOfWork.Setup(x => x.Customer.AnyAsync(It.IsAny<Expression<Func<Customer, bool>>>())).ReturnsAsync(true);

            CustomerService service = Service();
            ResponseService result = await service.UpdateCustomerAsync(CustomerStub.customerDto);

            Assert.IsTrue(result.Status);

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task UpdateCustomer_ReturnsResponseService_WhenDoesExistsDataAsync()
        {
            _unitOfWork.Setup(x => x.Customer.AnyAsync(It.IsAny<Expression<Func<Customer, bool>>>())).ReturnsAsync(false);

            CustomerService service = Service();
            ResponseService result = await service.UpdateCustomerAsync(CustomerStub.customerDto);

            Assert.IsFalse(result.Status);

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task UpdateCustomer_ReturnsResponseService_ExceptionAsync()
        {
            _unitOfWork.Setup(x => x.Customer.AnyAsync(It.IsAny<Expression<Func<Customer, bool>>>())).Throws(new Exception());

            CustomerService service = Service();
            await Assert.ThrowsExceptionAsync<UseCaseException>(async () => await service.UpdateCustomerAsync(CustomerStub.customerDto));

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task DeleteCustomer_ReturnsResponseService_WhenExistsDataAsync()
        {
            _unitOfWork.Setup(x => x.Customer.DeleteAsync(It.IsAny<Customer>())).ReturnsAsync(true);
            _unitOfWork.Setup(x => x.Customer.FirstOrDefaultAsync(It.IsAny<Expression<Func<Customer, bool>>>()))
                .ReturnsAsync(CustomerStub.customer);

            CustomerService service = Service();
            ResponseService result = await service.DeleteCustomerAsync("1111111111");

            Assert.IsTrue(result.Status);

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task DeleteCustomer_ReturnsResponseService_WhenDoesExistsDataAsync()
        {
            _unitOfWork.Setup(x => x.Customer.FirstOrDefaultAsync(It.IsAny<Expression<Func<Customer, bool>>>()))
                .ReturnsAsync(new Customer());

            CustomerService service = Service();
            ResponseService result = await service.DeleteCustomerAsync("1111111111");

            Assert.IsFalse(result.Status);

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task DeleteCustomer_ReturnsResponseService_ExceptionAsync()
        {
            _unitOfWork.Setup(x => x.Customer.FirstOrDefaultAsync(It.IsAny<Expression<Func<Customer, bool>>>()))
                .Throws(new Exception());

            CustomerService service = Service();
            await Assert.ThrowsExceptionAsync<UseCaseException>(async () => await service.DeleteCustomerAsync("1111111111"));

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetCustomerSpend_ReturnsResponseService_WhenExistsDataAsync()
        {
            _unitOfWork.Setup(x => x.Customer.GetCustomerSpendAsync(It.IsAny<GetCustomerDto>()))
                .ReturnsAsync(CustomerStub.customerSpendsDto);

            CustomerService service = Service();
            ResponseService result = await service.GetCustomerSpendAsync(CustomerStub.getCustomerDto);

            Assert.IsTrue(result.Status);

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetCustomerSpend_ReturnsResponseService_WhenDoesExistsDataAsync()
        {
            _unitOfWork.Setup(x => x.Customer.GetCustomerSpendAsync(It.IsAny<GetCustomerDto>()))
                .ReturnsAsync(new List<CustomerSpendDto>());

            CustomerService service = Service();
            ResponseService result = await service.GetCustomerSpendAsync(CustomerStub.getCustomerDto);

            Assert.IsFalse(result.Status);

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetCustomerSpend_ReturnsResponseService_ExceptionAsync()
        {
            _unitOfWork.Setup(x => x.Customer.GetCustomerSpendAsync(It.IsAny<GetCustomerDto>())).Throws(new Exception());

            CustomerService service = Service();
            await Assert.ThrowsExceptionAsync<UseCaseException>(async () => await service.GetCustomerSpendAsync(CustomerStub.getCustomerDto));

            _unitOfWork.VerifyAll();
        }
    }
}
