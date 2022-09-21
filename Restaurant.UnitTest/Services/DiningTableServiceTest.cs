namespace Restaurant.UnitTest.Services
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Restaurant.Business.UseCases;
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
    public class DiningTableServiceTest
    {
        private MockRepository _mockRepository;
        private Mock<IUnitOfWork> _unitOfWork;

        private DiningTableService Service()
        {
            return new DiningTableService(_unitOfWork.Object);
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
        public async Task GetDiningTable_ReturnsResponseService_WhenExistsDataAsync()
        {
            _unitOfWork.Setup(x => x.DiningTable.GetAllAsync()).ReturnsAsync(DiningTableStub.diningTables);

            DiningTableService service = Service();
            ResponseService result = await service.GetDiningTableAsync();

            Assert.IsTrue(result.Status);

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetDiningTable_ReturnsResponseService_WhenDoesExistsDataAsync()
        {
            _unitOfWork.Setup(x => x.DiningTable.GetAllAsync()).ReturnsAsync(new List<DiningTable>());

            DiningTableService service = Service();
            ResponseService result = await service.GetDiningTableAsync();

            Assert.IsFalse(result.Status);

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetDiningTable_ReturnsResponseService_ExceptionAsync()
        {
            _unitOfWork.Setup(x => x.DiningTable.GetAllAsync()).Throws(new Exception());

            DiningTableService service = Service();
            await Assert.ThrowsExceptionAsync<UseCaseException>(async () => await service.GetDiningTableAsync());

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task CreateDiningTable_ReturnsResponseService_WhenExistsDataAsync()
        {
            _unitOfWork.Setup(x => x.DiningTable.InsertAsync(It.IsAny<DiningTable>())).ReturnsAsync(true);

            DiningTableService service = Service();
            ResponseService result = await service.CreateDiningTableAsync(DiningTableStub.createDiningTableDto);

            Assert.IsTrue(result.Status);

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task CreateDiningTable_ReturnsResponseService_WhenDoesExistsDataAsync()
        {
            _unitOfWork.Setup(x => x.DiningTable.InsertAsync(It.IsAny<DiningTable>())).ReturnsAsync(false);

            DiningTableService service = Service();
            ResponseService result = await service.CreateDiningTableAsync(DiningTableStub.createDiningTableDto);

            Assert.IsFalse(result.Status);

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task CreateDiningTable_ReturnsResponseService_ExceptionAsync()
        {
            _unitOfWork.Setup(x => x.DiningTable.InsertAsync(It.IsAny<DiningTable>())).Throws(new Exception());

            DiningTableService service = Service();
            await Assert.ThrowsExceptionAsync<UseCaseException>(async () => await service.CreateDiningTableAsync(DiningTableStub.createDiningTableDto));

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task UpdateDiningTable_ReturnsResponseService_WhenExistsDataAsync()
        {
            _unitOfWork.Setup(x => x.DiningTable.UpdateAsync(It.IsAny<DiningTable>())).ReturnsAsync(true);
            _unitOfWork.Setup(x => x.DiningTable.AnyAsync(It.IsAny<Expression<Func<DiningTable, bool>>>())).ReturnsAsync(true);

            DiningTableService service = Service();
            ResponseService result = await service.UpdateDiningTableAsync(DiningTableStub.diningTableDto);

            Assert.IsTrue(result.Status);

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task UpdateDiningTable_ReturnsResponseService_WhenDoesExistsDataAsync()
        {
            _unitOfWork.Setup(x => x.DiningTable.AnyAsync(It.IsAny<Expression<Func<DiningTable, bool>>>())).ReturnsAsync(false);

            DiningTableService service = Service();
            ResponseService result = await service.UpdateDiningTableAsync(DiningTableStub.diningTableDto);

            Assert.IsFalse(result.Status);

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task UpdateDiningTable_ReturnsResponseService_ExceptionAsync()
        {
            _unitOfWork.Setup(x => x.DiningTable.AnyAsync(It.IsAny<Expression<Func<DiningTable, bool>>>())).Throws(new Exception());

            DiningTableService service = Service();
            await Assert.ThrowsExceptionAsync<UseCaseException>(async () => await service.UpdateDiningTableAsync(DiningTableStub.diningTableDto));

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task DeleteDiningTable_ReturnsResponseService_WhenExistsDataAsync()
        {
            _unitOfWork.Setup(x => x.DiningTable.DeleteAsync(It.IsAny<DiningTable>())).ReturnsAsync(true);
            _unitOfWork.Setup(x => x.DiningTable.FirstOrDefaultAsync(It.IsAny<Expression<Func<DiningTable, bool>>>()))
                .ReturnsAsync(DiningTableStub.diningTable);

            DiningTableService service = Service();
            ResponseService result = await service.DeleteDiningTableAsync(1);

            Assert.IsTrue(result.Status);

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task DeleteDiningTable_ReturnsResponseService_WhenDoesExistsDataAsync()
        {
            _unitOfWork.Setup(x => x.DiningTable.FirstOrDefaultAsync(It.IsAny<Expression<Func<DiningTable, bool>>>()))
                .ReturnsAsync(new DiningTable());

            DiningTableService service = Service();
            ResponseService result = await service.DeleteDiningTableAsync(1);

            Assert.IsFalse(result.Status);

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task DeleteDiningTable_ReturnsResponseService_ExceptionAsync()
        {
            _unitOfWork.Setup(x => x.DiningTable.FirstOrDefaultAsync(It.IsAny<Expression<Func<DiningTable, bool>>>()))
                .Throws(new Exception());

            DiningTableService service = Service();
            await Assert.ThrowsExceptionAsync<UseCaseException>(async () => await service.DeleteDiningTableAsync(1));

            _unitOfWork.VerifyAll();
        }
    }
}
