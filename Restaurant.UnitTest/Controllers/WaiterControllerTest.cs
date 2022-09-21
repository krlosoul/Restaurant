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
    public class WaiterControllerTest
    {
        private MockRepository _mockRepository;
        private Mock<IWaiterService> _mockService;

        private WaiterController Controller()
        {
            WaiterController controllerCOntext = new WaiterController(_mockService.Object)
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
            _mockService = _mockRepository.Create<IWaiterService>();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetWaiter_ExpectedSeup_ModelState()
        {
            _mockService.Setup(x => x.GetWaiterAsync()).ReturnsAsync(ResponseServiceStub.responseServiceBadRequest);

            var controller = Controller();
            controller.ModelState.AddModelError("ModelState", "Error model data");
            var result = await controller.GetWaiter();

            var okResult = result as BadRequestResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetWaiter_ExpectedSeup_Ok()
        {
            _mockService.Setup(x => x.GetWaiterAsync()).ReturnsAsync(ResponseServiceStub.responseServiceOk);

            var controller = Controller();
            var result = await controller.GetWaiter();

            var okResult = result as OkObjectResult;
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetWaiter_ExpectedSeup_BadRequest()
        {
            _mockService.Setup(x => x.GetWaiterAsync()).ReturnsAsync(ResponseServiceStub.responseServiceBadRequest);

            var controller = Controller();
            var result = await controller.GetWaiter();

            var okResult = result as BadRequestObjectResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetWaiter_ExpectedSeup_NoContent()
        {
            _mockService.Setup(x => x.GetWaiterAsync()).ReturnsAsync(ResponseServiceStub.responseServiceNoContent);

            var controller = Controller();
            var result = await controller.GetWaiter();

            var okResult = result as NoContentResult;
            Assert.AreEqual(StatusCodes.Status204NoContent, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetWaiter_ExpectedSeup_InternalServerError()
        {
            _mockService.Setup(x => x.GetWaiterAsync()).ThrowsAsync(new UseCaseException());

            var controller = Controller();
            var result = await controller.GetWaiter();

            var okResult = result as ObjectResult;
            Assert.AreEqual(StatusCodes.Status500InternalServerError, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task CreateWaiter_ExpectedSeup_ModelState()
        {
            _mockService.Setup(x => x.CreateWaiterAsync(It.IsAny<CreateWaiterDto>())).ReturnsAsync(ResponseServiceStub.responseServiceBadRequest);

            var controller = Controller();
            controller.ModelState.AddModelError("ModelState", "Error model data");
            var result = await controller.CreateWaiter(It.IsAny<CreateWaiterDto>());

            var okResult = result as BadRequestResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task CreateWaiter_ExpectedSeup_Ok()
        {
            _mockService.Setup(x => x.CreateWaiterAsync(It.IsAny<CreateWaiterDto>())).ReturnsAsync(ResponseServiceStub.responseServiceOk);

            var controller = Controller();
            var result = await controller.CreateWaiter(It.IsAny<CreateWaiterDto>());

            var okResult = result as OkObjectResult;
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task CreateWaiter_ExpectedSeup_BadRequest()
        {
            _mockService.Setup(x => x.CreateWaiterAsync(It.IsAny<CreateWaiterDto>())).ReturnsAsync(ResponseServiceStub.responseServiceBadRequest);

            var controller = Controller();
            var result = await controller.CreateWaiter(It.IsAny<CreateWaiterDto>());

            var okResult = result as BadRequestObjectResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task CreateWaiter_ExpectedSeup_NoContent()
        {
            _mockService.Setup(x => x.CreateWaiterAsync(It.IsAny<CreateWaiterDto>())).ReturnsAsync(ResponseServiceStub.responseServiceNoContent);

            var controller = Controller();
            var result = await controller.CreateWaiter(It.IsAny<CreateWaiterDto>());

            var okResult = result as NoContentResult;
            Assert.AreEqual(StatusCodes.Status204NoContent, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task CreateWaiter_ExpectedSeup_InternalServerError()
        {
            _mockService.Setup(x => x.CreateWaiterAsync(It.IsAny<CreateWaiterDto>())).ThrowsAsync(new UseCaseException());

            var controller = Controller();
            var result = await controller.CreateWaiter(It.IsAny<CreateWaiterDto>());

            var okResult = result as ObjectResult;
            Assert.AreEqual(StatusCodes.Status500InternalServerError, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task UpdateWaiter_ExpectedSeup_ModelState()
        {
            _mockService.Setup(x => x.UpdateWaiterAsync(It.IsAny<WaiterDto>())).ReturnsAsync(ResponseServiceStub.responseServiceBadRequest);

            var controller = Controller();
            controller.ModelState.AddModelError("ModelState", "Error model data");
            var result = await controller.UpdateWaiter(It.IsAny<WaiterDto>());

            var okResult = result as BadRequestResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task UpdateWaiter_ExpectedSeup_Ok()
        {
            _mockService.Setup(x => x.UpdateWaiterAsync(It.IsAny<WaiterDto>())).ReturnsAsync(ResponseServiceStub.responseServiceOk);

            var controller = Controller();
            var result = await controller.UpdateWaiter(It.IsAny<WaiterDto>());

            var okResult = result as OkObjectResult;
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task UpdateWaiter_ExpectedSeup_BadRequest()
        {
            _mockService.Setup(x => x.UpdateWaiterAsync(It.IsAny<WaiterDto>())).ReturnsAsync(ResponseServiceStub.responseServiceBadRequest);

            var controller = Controller();
            var result = await controller.UpdateWaiter(It.IsAny<WaiterDto>());

            var okResult = result as BadRequestObjectResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task UpdateWaiter_ExpectedSeup_NoContent()
        {
            _mockService.Setup(x => x.UpdateWaiterAsync(It.IsAny<WaiterDto>())).ReturnsAsync(ResponseServiceStub.responseServiceNoContent);

            var controller = Controller();
            var result = await controller.UpdateWaiter(It.IsAny<WaiterDto>());

            var okResult = result as NoContentResult;
            Assert.AreEqual(StatusCodes.Status204NoContent, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task UpdateWaiter_ExpectedSeup_InternalServerError()
        {
            _mockService.Setup(x => x.UpdateWaiterAsync(It.IsAny<WaiterDto>())).ThrowsAsync(new UseCaseException());

            var controller = Controller();
            var result = await controller.UpdateWaiter(It.IsAny<WaiterDto>());

            var okResult = result as ObjectResult;
            Assert.AreEqual(StatusCodes.Status500InternalServerError, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task DeleteWaiter_ExpectedSeup_ModelState()
        {
            _mockService.Setup(x => x.DeleteWaiterAsync(It.IsAny<int>())).ReturnsAsync(ResponseServiceStub.responseServiceBadRequest);

            var controller = Controller();
            controller.ModelState.AddModelError("ModelState", "Error model data");
            var result = await controller.DeleteWaiter(It.IsAny<int>());

            var okResult = result as BadRequestResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task DeleteWaiter_ExpectedSeup_Ok()
        {
            _mockService.Setup(x => x.DeleteWaiterAsync(It.IsAny<int>())).ReturnsAsync(ResponseServiceStub.responseServiceOk);

            var controller = Controller();
            var result = await controller.DeleteWaiter(It.IsAny<int>());

            var okResult = result as OkObjectResult;
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task DeleteWaiter_ExpectedSeup_BadRequest()
        {
            _mockService.Setup(x => x.DeleteWaiterAsync(It.IsAny<int>())).ReturnsAsync(ResponseServiceStub.responseServiceBadRequest);

            var controller = Controller();
            var result = await controller.DeleteWaiter(It.IsAny<int>());

            var okResult = result as BadRequestObjectResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task DeleteWaiter_ExpectedSeup_NoContent()
        {
            _mockService.Setup(x => x.DeleteWaiterAsync(It.IsAny<int>())).ReturnsAsync(ResponseServiceStub.responseServiceNoContent);

            var controller = Controller();
            var result = await controller.DeleteWaiter(It.IsAny<int>());

            var okResult = result as NoContentResult;
            Assert.AreEqual(StatusCodes.Status204NoContent, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task DeleteWaiter_ExpectedSeup_InternalServerError()
        {
            _mockService.Setup(x => x.DeleteWaiterAsync(It.IsAny<int>())).ThrowsAsync(new UseCaseException());

            var controller = Controller();
            var result = await controller.DeleteWaiter(It.IsAny<int>());

            var okResult = result as ObjectResult;
            Assert.AreEqual(StatusCodes.Status500InternalServerError, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetWaiterSales_ExpectedSeup_ModelState()
        {
            _mockService.Setup(x => x.GetWaiterSalesAsync(It.IsAny<DateRangeDto>())).ReturnsAsync(ResponseServiceStub.responseServiceBadRequest);

            var controller = Controller();
            controller.ModelState.AddModelError("ModelState", "Error model data");
            var result = await controller.GetWaiterSales(It.IsAny<DateRangeDto>());

            var okResult = result as BadRequestResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetWaiterSales_ExpectedSeup_Ok()
        {
            _mockService.Setup(x => x.GetWaiterSalesAsync(It.IsAny<DateRangeDto>())).ReturnsAsync(ResponseServiceStub.responseServiceOk);

            var controller = Controller();
            var result = await controller.GetWaiterSales(It.IsAny<DateRangeDto>());

            var okResult = result as OkObjectResult;
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetWaiterSales_ExpectedSeup_BadRequest()
        {
            _mockService.Setup(x => x.GetWaiterSalesAsync(It.IsAny<DateRangeDto>())).ReturnsAsync(ResponseServiceStub.responseServiceBadRequest);

            var controller = Controller();
            var result = await controller.GetWaiterSales(It.IsAny<DateRangeDto>());

            var okResult = result as BadRequestObjectResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetWaiterSales_ExpectedSeup_NoContent()
        {
            _mockService.Setup(x => x.GetWaiterSalesAsync(It.IsAny<DateRangeDto>())).ReturnsAsync(ResponseServiceStub.responseServiceNoContent);

            var controller = Controller();
            var result = await controller.GetWaiterSales(It.IsAny<DateRangeDto>());

            var okResult = result as NoContentResult;
            Assert.AreEqual(StatusCodes.Status204NoContent, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetWaiterSales_ExpectedSeup_InternalServerError()
        {
            _mockService.Setup(x => x.GetWaiterSalesAsync(It.IsAny<DateRangeDto>())).ThrowsAsync(new UseCaseException());

            var controller = Controller();
            var result = await controller.GetWaiterSales(It.IsAny<DateRangeDto>());

            var okResult = result as ObjectResult;
            Assert.AreEqual(StatusCodes.Status500InternalServerError, okResult.StatusCode);

            _mockService.Verify();
        }
    }
}
