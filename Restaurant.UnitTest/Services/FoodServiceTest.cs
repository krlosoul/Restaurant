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
    public class FoodServiceTest
    {
        private MockRepository _mockRepository;
        private Mock<IUnitOfWork> _unitOfWork;

        private FoodService Service()
        {
            return new FoodService(_unitOfWork.Object);
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
        public async Task GetFood_ReturnsResponseService_WhenExistsDataAsync()
        {
            _unitOfWork.Setup(x => x.Food.GetAllAsync()).ReturnsAsync(FoodStub.foods);

            FoodService service = Service();
            ResponseService result = await service.GetFoodAsync();

            Assert.IsTrue(result.Status);

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetFood_ReturnsResponseService_WhenDoesExistsDataAsync()
        {
            _unitOfWork.Setup(x => x.Food.GetAllAsync()).ReturnsAsync(new List<Food>());

            FoodService service = Service();
            ResponseService result = await service.GetFoodAsync();

            Assert.IsFalse(result.Status);

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetFood_ReturnsResponseService_ExceptionAsync()
        {
            _unitOfWork.Setup(x => x.Food.GetAllAsync()).Throws(new Exception());

            FoodService service = Service();
            await Assert.ThrowsExceptionAsync<UseCaseException>(async () => await service.GetFoodAsync());

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task CreateFood_ReturnsResponseService_WhenExistsDataAsync()
        {
            _unitOfWork.Setup(x => x.Food.InsertAsync(It.IsAny<Food>())).ReturnsAsync(true);

            FoodService service = Service();
            ResponseService result = await service.CreateFoodAsync(FoodStub.createFoodDto);

            Assert.IsTrue(result.Status);

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task CreateFood_ReturnsResponseService_WhenDoesExistsDataAsync()
        {
            _unitOfWork.Setup(x => x.Food.InsertAsync(It.IsAny<Food>())).ReturnsAsync(false);

            FoodService service = Service();
            ResponseService result = await service.CreateFoodAsync(FoodStub.createFoodDto);

            Assert.IsFalse(result.Status);

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task CreateFood_ReturnsResponseService_ExceptionAsync()
        {
            _unitOfWork.Setup(x => x.Food.InsertAsync(It.IsAny<Food>())).Throws(new Exception());

            FoodService service = Service();
            await Assert.ThrowsExceptionAsync<UseCaseException>(async () => await service.CreateFoodAsync(FoodStub.createFoodDto));

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task UpdateFood_ReturnsResponseService_WhenExistsDataAsync()
        {
            _unitOfWork.Setup(x => x.Food.UpdateAsync(It.IsAny<Food>())).ReturnsAsync(true);
            _unitOfWork.Setup(x => x.Food.AnyAsync(It.IsAny<Expression<Func<Food, bool>>>())).ReturnsAsync(true);

            FoodService service = Service();
            ResponseService result = await service.UpdateFoodAsync(FoodStub.foodDto);

            Assert.IsTrue(result.Status);

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task UpdateFood_ReturnsResponseService_WhenDoesExistsDataAsync()
        {
            _unitOfWork.Setup(x => x.Food.AnyAsync(It.IsAny<Expression<Func<Food, bool>>>())).ReturnsAsync(false);

            FoodService service = Service();
            ResponseService result = await service.UpdateFoodAsync(FoodStub.foodDto);

            Assert.IsFalse(result.Status);

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task UpdateFood_ReturnsResponseService_ExceptionAsync()
        {
            _unitOfWork.Setup(x => x.Food.AnyAsync(It.IsAny<Expression<Func<Food, bool>>>())).Throws(new Exception());

            FoodService service = Service();
            await Assert.ThrowsExceptionAsync<UseCaseException>(async () => await service.UpdateFoodAsync(FoodStub.foodDto));

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task DeleteFood_ReturnsResponseService_WhenExistsDataAsync()
        {
            _unitOfWork.Setup(x => x.Food.DeleteAsync(It.IsAny<Food>())).ReturnsAsync(true);
            _unitOfWork.Setup(x => x.Food.FirstOrDefaultAsync(It.IsAny<Expression<Func<Food, bool>>>()))
                .ReturnsAsync(FoodStub.food);

            FoodService service = Service();
            ResponseService result = await service.DeleteFoodAsync(1);

            Assert.IsTrue(result.Status);

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task DeleteFood_ReturnsResponseService_WhenDoesExistsDataAsync()
        {
            _unitOfWork.Setup(x => x.Food.FirstOrDefaultAsync(It.IsAny<Expression<Func<Food, bool>>>()))
                .ReturnsAsync(new Food());

            FoodService service = Service();
            ResponseService result = await service.DeleteFoodAsync(1);

            Assert.IsFalse(result.Status);

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task DeleteFood_ReturnsResponseService_ExceptionAsync()
        {
            _unitOfWork.Setup(x => x.Food.FirstOrDefaultAsync(It.IsAny<Expression<Func<Food, bool>>>()))
                .Throws(new Exception());

            FoodService service = Service();
            await Assert.ThrowsExceptionAsync<UseCaseException>(async () => await service.DeleteFoodAsync(1));

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetSalesFood_ReturnsResponseService_WhenExistsDataAsync()
        {
            _unitOfWork.Setup(x => x.Food.GetSalesFoodAsync(It.IsAny<DateRangeDto>()))
                .ReturnsAsync(FoodStub.salesFoodDto);

            FoodService service = Service();
            ResponseService result = await service.GetSalesFoodAsync(DateRangeStub.dateRangeDto);

            Assert.IsTrue(result.Status);

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetSalesFood_ReturnsResponseService_WhenDoesExistsDataAsync()
        {
            _unitOfWork.Setup(x => x.Food.GetSalesFoodAsync(It.IsAny<DateRangeDto>()))
                .ReturnsAsync((SalesFoodDto)null);

            FoodService service = Service();
            ResponseService result = await service.GetSalesFoodAsync(DateRangeStub.dateRangeDto);

            Assert.IsFalse(result.Status);

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetSalesFood_ReturnsResponseService_ExceptionAsync()
        {
            _unitOfWork.Setup(x => x.Food.GetSalesFoodAsync(It.IsAny<DateRangeDto>())).Throws(new Exception());

            FoodService service = Service();
            await Assert.ThrowsExceptionAsync<UseCaseException>(async () => await service.GetSalesFoodAsync(DateRangeStub.dateRangeDto));

            _unitOfWork.VerifyAll();
        }
    }
}
