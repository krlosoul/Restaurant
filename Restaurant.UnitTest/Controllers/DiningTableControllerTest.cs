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
    public class DiningTableControllerTest
    {
        private MockRepository _mockRepository;
        private Mock<IDiningTableService> _mockService;

        private DiningTableController Controller()
        {
            DiningTableController controllerCOntext = new DiningTableController(_mockService.Object)
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
            _mockService = _mockRepository.Create<IDiningTableService>();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetDiningTable_ExpectedSeup_ModelState()
        {
            _mockService.Setup(x => x.GetDiningTableAsync()).ReturnsAsync(ResponseServiceStub.responseServiceBadRequest);

            var controller = Controller();
            controller.ModelState.AddModelError("ModelState", "Error model data");
            var result = await controller.GetDiningTable();

            var okResult = result as BadRequestResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetDiningTable_ExpectedSeup_Ok()
        {
            _mockService.Setup(x => x.GetDiningTableAsync()).ReturnsAsync(ResponseServiceStub.responseServiceOk);

            var controller = Controller();
            var result = await controller.GetDiningTable();

            var okResult = result as OkObjectResult;
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetDiningTable_ExpectedSeup_BadRequest()
        {
            _mockService.Setup(x => x.GetDiningTableAsync()).ReturnsAsync(ResponseServiceStub.responseServiceBadRequest);

            var controller = Controller();
            var result = await controller.GetDiningTable();

            var okResult = result as BadRequestObjectResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetDiningTable_ExpectedSeup_NoContent()
        {
            _mockService.Setup(x => x.GetDiningTableAsync()).ReturnsAsync(ResponseServiceStub.responseServiceNoContent);

            var controller = Controller();
            var result = await controller.GetDiningTable();

            var okResult = result as NoContentResult;
            Assert.AreEqual(StatusCodes.Status204NoContent, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetDiningTable_ExpectedSeup_InternalServerError()
        {
            _mockService.Setup(x => x.GetDiningTableAsync()).ThrowsAsync(new UseCaseException());

            var controller = Controller();
            var result = await controller.GetDiningTable();

            var okResult = result as ObjectResult;
            Assert.AreEqual(StatusCodes.Status500InternalServerError, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task CreateDiningTable_ExpectedSeup_ModelState()
        {
            _mockService.Setup(x => x.CreateDiningTableAsync(It.IsAny<CreateDiningTableDto>())).ReturnsAsync(ResponseServiceStub.responseServiceBadRequest);

            var controller = Controller();
            controller.ModelState.AddModelError("ModelState", "Error model data");
            var result = await controller.CreateDiningTable(It.IsAny<CreateDiningTableDto>());

            var okResult = result as BadRequestResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task CreateDiningTable_ExpectedSeup_Ok()
        {
            _mockService.Setup(x => x.CreateDiningTableAsync(It.IsAny<CreateDiningTableDto>())).ReturnsAsync(ResponseServiceStub.responseServiceOk);

            var controller = Controller();
            var result = await controller.CreateDiningTable(It.IsAny<CreateDiningTableDto>());

            var okResult = result as OkObjectResult;
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task CreateDiningTable_ExpectedSeup_BadRequest()
        {
            _mockService.Setup(x => x.CreateDiningTableAsync(It.IsAny<CreateDiningTableDto>())).ReturnsAsync(ResponseServiceStub.responseServiceBadRequest);

            var controller = Controller();
            var result = await controller.CreateDiningTable(It.IsAny<CreateDiningTableDto>());

            var okResult = result as BadRequestObjectResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task CreateDiningTable_ExpectedSeup_NoContent()
        {
            _mockService.Setup(x => x.CreateDiningTableAsync(It.IsAny<CreateDiningTableDto>())).ReturnsAsync(ResponseServiceStub.responseServiceNoContent);

            var controller = Controller();
            var result = await controller.CreateDiningTable(It.IsAny<CreateDiningTableDto>());

            var okResult = result as NoContentResult;
            Assert.AreEqual(StatusCodes.Status204NoContent, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task CreateDiningTable_ExpectedSeup_InternalServerError()
        {
            _mockService.Setup(x => x.CreateDiningTableAsync(It.IsAny<CreateDiningTableDto>())).ThrowsAsync(new UseCaseException());

            var controller = Controller();
            var result = await controller.CreateDiningTable(It.IsAny<CreateDiningTableDto>());

            var okResult = result as ObjectResult;
            Assert.AreEqual(StatusCodes.Status500InternalServerError, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task UpdateDiningTable_ExpectedSeup_ModelState()
        {
            _mockService.Setup(x => x.UpdateDiningTableAsync(It.IsAny<DiningTableDto>())).ReturnsAsync(ResponseServiceStub.responseServiceBadRequest);

            var controller = Controller();
            controller.ModelState.AddModelError("ModelState", "Error model data");
            var result = await controller.UpdateDiningTable(It.IsAny<DiningTableDto>());

            var okResult = result as BadRequestResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task UpdateDiningTable_ExpectedSeup_Ok()
        {
            _mockService.Setup(x => x.UpdateDiningTableAsync(It.IsAny<DiningTableDto>())).ReturnsAsync(ResponseServiceStub.responseServiceOk);

            var controller = Controller();
            var result = await controller.UpdateDiningTable(It.IsAny<DiningTableDto>());

            var okResult = result as OkObjectResult;
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task UpdateDiningTable_ExpectedSeup_BadRequest()
        {
            _mockService.Setup(x => x.UpdateDiningTableAsync(It.IsAny<DiningTableDto>())).ReturnsAsync(ResponseServiceStub.responseServiceBadRequest);

            var controller = Controller();
            var result = await controller.UpdateDiningTable(It.IsAny<DiningTableDto>());

            var okResult = result as BadRequestObjectResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task UpdateDiningTable_ExpectedSeup_NoContent()
        {
            _mockService.Setup(x => x.UpdateDiningTableAsync(It.IsAny<DiningTableDto>())).ReturnsAsync(ResponseServiceStub.responseServiceNoContent);

            var controller = Controller();
            var result = await controller.UpdateDiningTable(It.IsAny<DiningTableDto>());

            var okResult = result as NoContentResult;
            Assert.AreEqual(StatusCodes.Status204NoContent, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task UpdateDiningTable_ExpectedSeup_InternalServerError()
        {
            _mockService.Setup(x => x.UpdateDiningTableAsync(It.IsAny<DiningTableDto>())).ThrowsAsync(new UseCaseException());

            var controller = Controller();
            var result = await controller.UpdateDiningTable(It.IsAny<DiningTableDto>());

            var okResult = result as ObjectResult;
            Assert.AreEqual(StatusCodes.Status500InternalServerError, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task DeleteDiningTable_ExpectedSeup_ModelState()
        {
            _mockService.Setup(x => x.DeleteDiningTableAsync(It.IsAny<int>())).ReturnsAsync(ResponseServiceStub.responseServiceBadRequest);

            var controller = Controller();
            controller.ModelState.AddModelError("ModelState", "Error model data");
            var result = await controller.DeleteDiningTable(It.IsAny<int>());

            var okResult = result as BadRequestResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task DeleteDiningTable_ExpectedSeup_Ok()
        {
            _mockService.Setup(x => x.DeleteDiningTableAsync(It.IsAny<int>())).ReturnsAsync(ResponseServiceStub.responseServiceOk);

            var controller = Controller();
            var result = await controller.DeleteDiningTable(It.IsAny<int>());

            var okResult = result as OkObjectResult;
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task DeleteDiningTable_ExpectedSeup_BadRequest()
        {
            _mockService.Setup(x => x.DeleteDiningTableAsync(It.IsAny<int>())).ReturnsAsync(ResponseServiceStub.responseServiceBadRequest);

            var controller = Controller();
            var result = await controller.DeleteDiningTable(It.IsAny<int>());

            var okResult = result as BadRequestObjectResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task DeleteDiningTable_ExpectedSeup_NoContent()
        {
            _mockService.Setup(x => x.DeleteDiningTableAsync(It.IsAny<int>())).ReturnsAsync(ResponseServiceStub.responseServiceNoContent);

            var controller = Controller();
            var result = await controller.DeleteDiningTable(It.IsAny<int>());

            var okResult = result as NoContentResult;
            Assert.AreEqual(StatusCodes.Status204NoContent, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task DeleteDiningTable_ExpectedSeup_InternalServerError()
        {
            _mockService.Setup(x => x.DeleteDiningTableAsync(It.IsAny<int>())).ThrowsAsync(new UseCaseException());

            var controller = Controller();
            var result = await controller.DeleteDiningTable(It.IsAny<int>());

            var okResult = result as ObjectResult;
            Assert.AreEqual(StatusCodes.Status500InternalServerError, okResult.StatusCode);

            _mockService.Verify();
        }    
    }
}
