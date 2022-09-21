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
    using System.Threading.Tasks;

    [TestClass]
    public class BillDetailServiceTest
    {
        private MockRepository _mockRepository;
        private Mock<IUnitOfWork> _unitOfWork;

        private BillDetailService Service()
        {
            return new BillDetailService(_unitOfWork.Object);
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
        public async Task CreateBillDetail_ReturnsResponseService_WhenExistsDataAsync()
        {
            _unitOfWork.Setup(x => x.BillDetail.InsertAsync(It.IsAny<IList<BillDetail>>())).ReturnsAsync(true);

            BillDetailService service = Service();
            ResponseService result = await service.CreateBillDetailsAsync(BillDetailStub.createBillsDetailsDto);

            Assert.IsTrue(result.Status);

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task CreateBillDetail_ReturnsResponseService_WhenDoesExistsDataAsync()
        {
            _unitOfWork.Setup(x => x.BillDetail.InsertAsync(It.IsAny<IList<BillDetail>>())).ReturnsAsync(false);

            BillDetailService service = Service();
            ResponseService result = await service.CreateBillDetailsAsync(BillDetailStub.createBillsDetailsDto);

            Assert.IsFalse(result.Status);

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task CreateBillDetail_ReturnsResponseService_ExceptionAsync()
        {
            _unitOfWork.Setup(x => x.BillDetail.InsertAsync(It.IsAny<IList<BillDetail>>())).Throws(new Exception());

            BillDetailService service = Service();
            await Assert.ThrowsExceptionAsync<UseCaseException>(async () => await service.CreateBillDetailsAsync(BillDetailStub.createBillsDetailsDto));

            _unitOfWork.VerifyAll();
        }
    }
}
