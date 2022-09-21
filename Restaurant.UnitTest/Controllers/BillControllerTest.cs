namespace Restaurant.UnitTest.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Restaurant.Api.Controllers.V1;
    using Restaurant.Business.Interfaces;
    using Restaurant.Core.Dtos;
    using Restaurant.Core.Exceptions;
    using Restaurant.Infrastructure.Mapper;
    using Restaurant.UnitTest.Stubs;
    using System.Threading.Tasks;

    [TestClass]
    public class BillControllerTest
    {
        private MockRepository _mockRepository;
        private Mock<IBillService> _mockService;

        private BillController Controller()
        {
            BillController controllerCOntext = new BillController(_mockService.Object)
            {
                ControllerContext = new ControllerContext()
            };
            controllerCOntext.ControllerContext.HttpContext = new DefaultHttpContext();

            return controllerCOntext;
        }

        [TestInitialize]
        public void TestInitialize()
        {
            AutoMapper.Mapper.Reset();
            AutoMapperConfig.CreateMaps();

            _mockRepository = new MockRepository(MockBehavior.Strict);
            _mockService = _mockRepository.Create<IBillService>();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetBillsWithDetails_ExpectedSeup_ModelState()
        {
            _mockService.Setup(x => x.GetBillsWithDetailsAsync(It.IsAny<GetBillsWithDetailsDto>())).ReturnsAsync(ResponseServiceStub.responseServiceBadRequest);

            var controller = Controller();
            controller.ModelState.AddModelError("ModelState", "Error model data");
            var result = await controller.GetBillsWithDetails(It.IsAny<GetBillsWithDetailsDto>());

            var okResult = result as BadRequestResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetBillsWithDetails_ExpectedSeup_Ok()
        {
            _mockService.Setup(x => x.GetBillsWithDetailsAsync(It.IsAny<GetBillsWithDetailsDto>())).ReturnsAsync(ResponseServiceStub.responseServiceOk);

            var controller = Controller();
            var result = await controller.GetBillsWithDetails(It.IsAny<GetBillsWithDetailsDto>());

            var okResult = result as OkObjectResult;
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetBillsWithDetails_ExpectedSeup_BadRequest()
        {
            _mockService.Setup(x => x.GetBillsWithDetailsAsync(It.IsAny<GetBillsWithDetailsDto>())).ReturnsAsync(ResponseServiceStub.responseServiceBadRequest);

            var controller = Controller();
            var result = await controller.GetBillsWithDetails(It.IsAny<GetBillsWithDetailsDto>());

            var okResult = result as BadRequestObjectResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetBillsWithDetails_ExpectedSeup_NoContent()
        {
            _mockService.Setup(x => x.GetBillsWithDetailsAsync(It.IsAny<GetBillsWithDetailsDto>())).ReturnsAsync(ResponseServiceStub.responseServiceNoContent);

            var controller = Controller();
            var result = await controller.GetBillsWithDetails(It.IsAny<GetBillsWithDetailsDto>());

            var okResult = result as NoContentResult;
            Assert.AreEqual(StatusCodes.Status204NoContent, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetBillsWithDetails_ExpectedSeup_InternalServerError()
        {
            _mockService.Setup(x => x.GetBillsWithDetailsAsync(It.IsAny<GetBillsWithDetailsDto>())).ThrowsAsync(new UseCaseException());

            var controller = Controller();
            var result = await controller.GetBillsWithDetails(It.IsAny<GetBillsWithDetailsDto>());

            var okResult = result as ObjectResult;
            Assert.AreEqual(StatusCodes.Status500InternalServerError, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task CreateBill_ExpectedSeup_ModelState()
        {
            _mockService.Setup(x => x.CreateBillAsync(It.IsAny<CreateBillDto>())).ReturnsAsync(ResponseServiceStub.responseServiceBadRequest);

            var controller = Controller();
            controller.ModelState.AddModelError("ModelState", "Error model data");
            var result = await controller.CreateBill(It.IsAny<CreateBillDto>());

            var okResult = result as BadRequestResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task CreateBill_ExpectedSeup_Ok()
        {
            _mockService.Setup(x => x.CreateBillAsync(It.IsAny<CreateBillDto>())).ReturnsAsync(ResponseServiceStub.responseServiceOk);

            var controller = Controller();
            var result = await controller.CreateBill(It.IsAny<CreateBillDto>());

            var okResult = result as OkObjectResult;
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task CreateBill_ExpectedSeup_BadRequest()
        {
            _mockService.Setup(x => x.CreateBillAsync(It.IsAny<CreateBillDto>())).ReturnsAsync(ResponseServiceStub.responseServiceBadRequest);

            var controller = Controller();
            var result = await controller.CreateBill(It.IsAny<CreateBillDto>());

            var okResult = result as BadRequestObjectResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task CreateBill_ExpectedSeup_NoContent()
        {
            _mockService.Setup(x => x.CreateBillAsync(It.IsAny<CreateBillDto>())).ReturnsAsync(ResponseServiceStub.responseServiceNoContent);

            var controller = Controller();
            var result = await controller.CreateBill(It.IsAny<CreateBillDto>());

            var okResult = result as NoContentResult;
            Assert.AreEqual(StatusCodes.Status204NoContent, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task CreateBill_ExpectedSeup_InternalServerError()
        {
            _mockService.Setup(x => x.CreateBillAsync(It.IsAny<CreateBillDto>())).ThrowsAsync(new UseCaseException());

            var controller = Controller();
            var result = await controller.CreateBill(It.IsAny<CreateBillDto>());

            var okResult = result as ObjectResult;
            Assert.AreEqual(StatusCodes.Status500InternalServerError, okResult.StatusCode);

            _mockService.Verify();
        }
    }
}
