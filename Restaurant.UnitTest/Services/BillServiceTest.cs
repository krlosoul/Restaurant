namespace Restaurant.UnitTest.Services
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Restaurant.Business.Interfaces;
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
    public class BillServiceTest
    {
        private MockRepository _mockRepository;
        private Mock<IUnitOfWork> _unitOfWork;
        private Mock<IBillDetailService> _billDetailService;

        private BillService Service()
        {
            return new BillService(_unitOfWork.Object, _billDetailService.Object);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            AutoMapper.Mapper.Reset();
            AutoMapperConfig.CreateMaps();

            _mockRepository = new MockRepository(MockBehavior.Strict);
            _unitOfWork = new Mock<IUnitOfWork>();
            _billDetailService = new Mock<IBillDetailService>();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetBillsWithDetails_ReturnsResponseService_WhenExistsDataAsync()
        {
            _unitOfWork.Setup(x => x.Bill.GetBillsWithDetailsAsync(It.IsAny<GetBillsWithDetailsDto>()))
                .ReturnsAsync(BillStub.billsWithDetailsDtos);

            BillService service = Service();
            ResponseService result = await service.GetBillsWithDetailsAsync(BillStub.getBillsWithDetailsDto);

            Assert.IsTrue(result.Status);

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetBillsWithDetails_ReturnsResponseService_WhenDoesExistsDataAsync()
        {
            _unitOfWork.Setup(x => x.Bill.GetBillsWithDetailsAsync(It.IsAny<GetBillsWithDetailsDto>()))
                .ReturnsAsync(new List<BillsWithDetailsDto>());

            BillService service = Service();
            ResponseService result = await service.GetBillsWithDetailsAsync(BillStub.getBillsWithDetailsDto);

            Assert.IsFalse(result.Status);

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetBillsWithDetails_ReturnsResponseService_ExceptionAsync()
        {
            _unitOfWork.Setup(x => x.Bill.GetBillsWithDetailsAsync(It.IsAny<GetBillsWithDetailsDto>())).Throws(new Exception());

            BillService service = Service();
            await Assert.ThrowsExceptionAsync<UseCaseException>(async () => await service.GetBillsWithDetailsAsync(BillStub.getBillsWithDetailsDto));

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task CreateBill_ReturnsResponseService_WhenExistsDataAsync()
        {
            _unitOfWork.Setup(x => x.Bill.InsertAsync(It.IsAny<Bill>())).ReturnsAsync(true);
            _billDetailService.Setup(x => x.CreateBillDetailsAsync(It.IsAny<CreateBillDetailsDto>())).ReturnsAsync(ResponseServiceStub.responseServiceOk);

            BillService service = Service();
            ResponseService result = await service.CreateBillAsync(BillStub.createBillDto);

            Assert.IsTrue(result.Status);

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task CreateBill_ReturnsResponseService_WhenDoesExistsDataAsync()
        {
            _unitOfWork.Setup(x => x.Bill.InsertAsync(It.IsAny<Bill>())).ReturnsAsync(false);

            BillService service = Service();
            ResponseService result = await service.CreateBillAsync(BillStub.createBillDto);

            Assert.IsFalse(result.Status);

            _unitOfWork.VerifyAll();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task CreateBill_ReturnsResponseService_ExceptionAsync()
        {
            _unitOfWork.Setup(x => x.Bill.InsertAsync(It.IsAny<Bill>())).Throws(new Exception());

            BillService service = Service();
            await Assert.ThrowsExceptionAsync<UseCaseException>(async () => await service.CreateBillAsync(BillStub.createBillDto));

            _unitOfWork.VerifyAll();
        }
    }
}
