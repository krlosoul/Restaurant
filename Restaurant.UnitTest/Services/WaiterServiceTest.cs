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
    public class WaiterServiceTest
    {
        private MockRepository _mockRepository;
        private Mock<IUnitOfWork> _unitOfWork;

        private WaiterService Service()
        {
            return new WaiterService(_unitOfWork.Object);
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
        public async Task GetWaiter_ReturnsResponseService_WhenExistsDataAsync()
        {
            _unitOfWork.Setup(x => x.Waiter.GetAllAsync()).ReturnsAsync(WaiterStub.waiters);

            WaiterService service = Service();
            ResponseService result = await service.GetWaiterAsync();

            Assert.IsTrue(result.Status);

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetWaiter_ReturnsResponseService_WhenDoesExistsDataAsync()
        {
            _unitOfWork.Setup(x => x.Waiter.GetAllAsync()).ReturnsAsync(new List<Waiter>());

            WaiterService service = Service();
            ResponseService result = await service.GetWaiterAsync();

            Assert.IsFalse(result.Status);

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetWaiter_ReturnsResponseService_ExceptionAsync()
        {
            _unitOfWork.Setup(x => x.Waiter.GetAllAsync()).Throws(new Exception());

            WaiterService service = Service();
            await Assert.ThrowsExceptionAsync<UseCaseException>(async () => await service.GetWaiterAsync());

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task CreateWaiter_ReturnsResponseService_WhenExistsDataAsync()
        {
            _unitOfWork.Setup(x => x.Waiter.InsertAsync(It.IsAny<Waiter>())).ReturnsAsync(true);

            WaiterService service = Service();
            ResponseService result = await service.CreateWaiterAsync(WaiterStub.createWaiterDto);

            Assert.IsTrue(result.Status);

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task CreateWaiter_ReturnsResponseService_WhenDoesExistsDataAsync()
        {
            _unitOfWork.Setup(x => x.Waiter.InsertAsync(It.IsAny<Waiter>())).ReturnsAsync(false);

            WaiterService service = Service();
            ResponseService result = await service.CreateWaiterAsync(WaiterStub.createWaiterDto);

            Assert.IsFalse(result.Status);

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task CreateWaiter_ReturnsResponseService_ExceptionAsync()
        {
            _unitOfWork.Setup(x => x.Waiter.InsertAsync(It.IsAny<Waiter>())).Throws(new Exception());

            WaiterService service = Service();
            await Assert.ThrowsExceptionAsync<UseCaseException>(async () => await service.CreateWaiterAsync(WaiterStub.createWaiterDto));

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task UpdateWaiter_ReturnsResponseService_WhenExistsDataAsync()
        {
            _unitOfWork.Setup(x => x.Waiter.UpdateAsync(It.IsAny<Waiter>())).ReturnsAsync(true);
            _unitOfWork.Setup(x => x.Waiter.AnyAsync(It.IsAny<Expression<Func<Waiter, bool>>>())).ReturnsAsync(true);

            WaiterService service = Service();
            ResponseService result = await service.UpdateWaiterAsync(WaiterStub.waiterDto);

            Assert.IsTrue(result.Status);

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task UpdateWaiter_ReturnsResponseService_WhenDoesExistsDataAsync()
        {
            _unitOfWork.Setup(x => x.Waiter.AnyAsync(It.IsAny<Expression<Func<Waiter, bool>>>())).ReturnsAsync(false);

            WaiterService service = Service();
            ResponseService result = await service.UpdateWaiterAsync(WaiterStub.waiterDto);

            Assert.IsFalse(result.Status);

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task UpdateWaiter_ReturnsResponseService_ExceptionAsync()
        {
            _unitOfWork.Setup(x => x.Waiter.AnyAsync(It.IsAny<Expression<Func<Waiter, bool>>>())).Throws(new Exception());

            WaiterService service = Service();
            await Assert.ThrowsExceptionAsync<UseCaseException>(async () => await service.UpdateWaiterAsync(WaiterStub.waiterDto));

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task DeleteWaiter_ReturnsResponseService_WhenExistsDataAsync()
        {
            _unitOfWork.Setup(x => x.Waiter.DeleteAsync(It.IsAny<Waiter>())).ReturnsAsync(true);
            _unitOfWork.Setup(x => x.Waiter.FirstOrDefaultAsync(It.IsAny<Expression<Func<Waiter, bool>>>()))
                .ReturnsAsync(WaiterStub.waiter);

            WaiterService service = Service();
            ResponseService result = await service.DeleteWaiterAsync(1);

            Assert.IsTrue(result.Status);

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task DeleteWaiter_ReturnsResponseService_WhenDoesExistsDataAsync()
        {
            _unitOfWork.Setup(x => x.Waiter.FirstOrDefaultAsync(It.IsAny<Expression<Func<Waiter, bool>>>()))
                .ReturnsAsync(new Waiter());

            WaiterService service = Service();
            ResponseService result = await service.DeleteWaiterAsync(1);

            Assert.IsFalse(result.Status);

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task DeleteWaiter_ReturnsResponseService_ExceptionAsync()
        {
            _unitOfWork.Setup(x => x.Waiter.FirstOrDefaultAsync(It.IsAny<Expression<Func<Waiter, bool>>>()))
                .Throws(new Exception());

            WaiterService service = Service();
            await Assert.ThrowsExceptionAsync<UseCaseException>(async () => await service.DeleteWaiterAsync(1));

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetWaiterSalesAsync_ReturnsResponseService_WhenExistsDataAsync()
        {
            _unitOfWork.Setup(x => x.Waiter.GetWaiterSalesAsync(It.IsAny<DateRangeDto>()))
                .ReturnsAsync(WaiterStub.WaiterSalesDto);

            WaiterService service = Service();
            ResponseService result = await service.GetWaiterSalesAsync(DateRangeStub.dateRangeDto);

            Assert.IsTrue(result.Status);

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetWaiterSalesAsync_ReturnsResponseService_WhenDoesExistsDataAsync()
        {
            _unitOfWork.Setup(x => x.Waiter.GetWaiterSalesAsync(It.IsAny<DateRangeDto>()))
                .ReturnsAsync(new List<WaiterSalesDto>());

            WaiterService service = Service();
            ResponseService result = await service.GetWaiterSalesAsync(DateRangeStub.dateRangeDto);

            Assert.IsFalse(result.Status);

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetWaiterSalesAsync_ReturnsResponseService_ExceptionAsync()
        {
            _unitOfWork.Setup(x => x.Waiter.GetWaiterSalesAsync(It.IsAny<DateRangeDto>())).Throws(new Exception());

            WaiterService service = Service();
            await Assert.ThrowsExceptionAsync<UseCaseException>(async () => await service.GetWaiterSalesAsync(DateRangeStub.dateRangeDto));

            _unitOfWork.VerifyAll();
        }
    }
}
