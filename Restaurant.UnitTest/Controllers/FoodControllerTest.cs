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
    public class FoodControllerTest
    {
        private MockRepository _mockRepository;
        private Mock<IFoodService> _mockService;

        private FoodController Controller()
        {
            FoodController controllerCOntext = new FoodController(_mockService.Object)
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
            _mockService = _mockRepository.Create<IFoodService>();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetFood_ExpectedSeup_ModelState()
        {
            _mockService.Setup(x => x.GetFoodAsync()).ReturnsAsync(ResponseServiceStub.responseServiceBadRequest);

            var controller = Controller();
            controller.ModelState.AddModelError("ModelState", "Error model data");
            var result = await controller.GetFood();

            var okResult = result as BadRequestResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetFood_ExpectedSeup_Ok()
        {
            _mockService.Setup(x => x.GetFoodAsync()).ReturnsAsync(ResponseServiceStub.responseServiceOk);

            var controller = Controller();
            var result = await controller.GetFood();

            var okResult = result as OkObjectResult;
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetFood_ExpectedSeup_BadRequest()
        {
            _mockService.Setup(x => x.GetFoodAsync()).ReturnsAsync(ResponseServiceStub.responseServiceBadRequest);

            var controller = Controller();
            var result = await controller.GetFood();

            var okResult = result as BadRequestObjectResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetFood_ExpectedSeup_NoContent()
        {
            _mockService.Setup(x => x.GetFoodAsync()).ReturnsAsync(ResponseServiceStub.responseServiceNoContent);

            var controller = Controller();
            var result = await controller.GetFood();

            var okResult = result as NoContentResult;
            Assert.AreEqual(StatusCodes.Status204NoContent, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetFood_ExpectedSeup_InternalServerError()
        {
            _mockService.Setup(x => x.GetFoodAsync()).ThrowsAsync(new UseCaseException());

            var controller = Controller();
            var result = await controller.GetFood();

            var okResult = result as ObjectResult;
            Assert.AreEqual(StatusCodes.Status500InternalServerError, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task CreateFood_ExpectedSeup_ModelState()
        {
            _mockService.Setup(x => x.CreateFoodAsync(It.IsAny<CreateFoodDto>())).ReturnsAsync(ResponseServiceStub.responseServiceBadRequest);

            var controller = Controller();
            controller.ModelState.AddModelError("ModelState", "Error model data");
            var result = await controller.CreateFood(It.IsAny<CreateFoodDto>());

            var okResult = result as BadRequestResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task CreateFood_ExpectedSeup_Ok()
        {
            _mockService.Setup(x => x.CreateFoodAsync(It.IsAny<CreateFoodDto>())).ReturnsAsync(ResponseServiceStub.responseServiceOk);

            var controller = Controller();
            var result = await controller.CreateFood(It.IsAny<CreateFoodDto>());

            var okResult = result as OkObjectResult;
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task CreateFood_ExpectedSeup_BadRequest()
        {
            _mockService.Setup(x => x.CreateFoodAsync(It.IsAny<CreateFoodDto>())).ReturnsAsync(ResponseServiceStub.responseServiceBadRequest);

            var controller = Controller();
            var result = await controller.CreateFood(It.IsAny<CreateFoodDto>());

            var okResult = result as BadRequestObjectResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task CreateFood_ExpectedSeup_NoContent()
        {
            _mockService.Setup(x => x.CreateFoodAsync(It.IsAny<CreateFoodDto>())).ReturnsAsync(ResponseServiceStub.responseServiceNoContent);

            var controller = Controller();
            var result = await controller.CreateFood(It.IsAny<CreateFoodDto>());

            var okResult = result as NoContentResult;
            Assert.AreEqual(StatusCodes.Status204NoContent, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task CreateFood_ExpectedSeup_InternalServerError()
        {
            _mockService.Setup(x => x.CreateFoodAsync(It.IsAny<CreateFoodDto>())).ThrowsAsync(new UseCaseException());

            var controller = Controller();
            var result = await controller.CreateFood(It.IsAny<CreateFoodDto>());

            var okResult = result as ObjectResult;
            Assert.AreEqual(StatusCodes.Status500InternalServerError, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task UpdateFood_ExpectedSeup_ModelState()
        {
            _mockService.Setup(x => x.UpdateFoodAsync(It.IsAny<FoodDto>())).ReturnsAsync(ResponseServiceStub.responseServiceBadRequest);

            var controller = Controller();
            controller.ModelState.AddModelError("ModelState", "Error model data");
            var result = await controller.UpdateFood(It.IsAny<FoodDto>());

            var okResult = result as BadRequestResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task UpdateFood_ExpectedSeup_Ok()
        {
            _mockService.Setup(x => x.UpdateFoodAsync(It.IsAny<FoodDto>())).ReturnsAsync(ResponseServiceStub.responseServiceOk);

            var controller = Controller();
            var result = await controller.UpdateFood(It.IsAny<FoodDto>());

            var okResult = result as OkObjectResult;
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task UpdateFood_ExpectedSeup_BadRequest()
        {
            _mockService.Setup(x => x.UpdateFoodAsync(It.IsAny<FoodDto>())).ReturnsAsync(ResponseServiceStub.responseServiceBadRequest);

            var controller = Controller();
            var result = await controller.UpdateFood(It.IsAny<FoodDto>());

            var okResult = result as BadRequestObjectResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task UpdateFood_ExpectedSeup_NoContent()
        {
            _mockService.Setup(x => x.UpdateFoodAsync(It.IsAny<FoodDto>())).ReturnsAsync(ResponseServiceStub.responseServiceNoContent);

            var controller = Controller();
            var result = await controller.UpdateFood(It.IsAny<FoodDto>());

            var okResult = result as NoContentResult;
            Assert.AreEqual(StatusCodes.Status204NoContent, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task UpdateFood_ExpectedSeup_InternalServerError()
        {
            _mockService.Setup(x => x.UpdateFoodAsync(It.IsAny<FoodDto>())).ThrowsAsync(new UseCaseException());

            var controller = Controller();
            var result = await controller.UpdateFood(It.IsAny<FoodDto>());

            var okResult = result as ObjectResult;
            Assert.AreEqual(StatusCodes.Status500InternalServerError, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task DeleteFood_ExpectedSeup_ModelState()
        {
            _mockService.Setup(x => x.DeleteFoodAsync(It.IsAny<int>())).ReturnsAsync(ResponseServiceStub.responseServiceBadRequest);

            var controller = Controller();
            controller.ModelState.AddModelError("ModelState", "Error model data");
            var result = await controller.DeleteFood(It.IsAny<int>());

            var okResult = result as BadRequestResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task DeleteFood_ExpectedSeup_Ok()
        {
            _mockService.Setup(x => x.DeleteFoodAsync(It.IsAny<int>())).ReturnsAsync(ResponseServiceStub.responseServiceOk);

            var controller = Controller();
            var result = await controller.DeleteFood(It.IsAny<int>());

            var okResult = result as OkObjectResult;
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task DeleteFood_ExpectedSeup_BadRequest()
        {
            _mockService.Setup(x => x.DeleteFoodAsync(It.IsAny<int>())).ReturnsAsync(ResponseServiceStub.responseServiceBadRequest);

            var controller = Controller();
            var result = await controller.DeleteFood(It.IsAny<int>());

            var okResult = result as BadRequestObjectResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task DeleteFood_ExpectedSeup_NoContent()
        {
            _mockService.Setup(x => x.DeleteFoodAsync(It.IsAny<int>())).ReturnsAsync(ResponseServiceStub.responseServiceNoContent);

            var controller = Controller();
            var result = await controller.DeleteFood(It.IsAny<int>());

            var okResult = result as NoContentResult;
            Assert.AreEqual(StatusCodes.Status204NoContent, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task DeleteFood_ExpectedSeup_InternalServerError()
        {
            _mockService.Setup(x => x.DeleteFoodAsync(It.IsAny<int>())).ThrowsAsync(new UseCaseException());

            var controller = Controller();
            var result = await controller.DeleteFood(It.IsAny<int>());

            var okResult = result as ObjectResult;
            Assert.AreEqual(StatusCodes.Status500InternalServerError, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetSalesFood_ExpectedSeup_ModelState()
        {
            _mockService.Setup(x => x.GetSalesFoodAsync(It.IsAny<DateRangeDto>())).ReturnsAsync(ResponseServiceStub.responseServiceBadRequest);

            var controller = Controller();
            controller.ModelState.AddModelError("ModelState", "Error model data");
            var result = await controller.GetSalesFood(It.IsAny<DateRangeDto>());

            var okResult = result as BadRequestResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetSalesFood_ExpectedSeup_Ok()
        {
            _mockService.Setup(x => x.GetSalesFoodAsync(It.IsAny<DateRangeDto>())).ReturnsAsync(ResponseServiceStub.responseServiceOk);

            var controller = Controller();
            var result = await controller.GetSalesFood(It.IsAny<DateRangeDto>());

            var okResult = result as OkObjectResult;
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetSalesFood_ExpectedSeup_BadRequest()
        {
            _mockService.Setup(x => x.GetSalesFoodAsync(It.IsAny<DateRangeDto>())).ReturnsAsync(ResponseServiceStub.responseServiceBadRequest);

            var controller = Controller();
            var result = await controller.GetSalesFood(It.IsAny<DateRangeDto>());

            var okResult = result as BadRequestObjectResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetSalesFood_ExpectedSeup_NoContent()
        {
            _mockService.Setup(x => x.GetSalesFoodAsync(It.IsAny<DateRangeDto>())).ReturnsAsync(ResponseServiceStub.responseServiceNoContent);

            var controller = Controller();
            var result = await controller.GetSalesFood(It.IsAny<DateRangeDto>());

            var okResult = result as NoContentResult;
            Assert.AreEqual(StatusCodes.Status204NoContent, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetSalesFood_ExpectedSeup_InternalServerError()
        {
            _mockService.Setup(x => x.GetSalesFoodAsync(It.IsAny<DateRangeDto>())).ThrowsAsync(new UseCaseException());

            var controller = Controller();
            var result = await controller.GetSalesFood(It.IsAny<DateRangeDto>());

            var okResult = result as ObjectResult;
            Assert.AreEqual(StatusCodes.Status500InternalServerError, okResult.StatusCode);

            _mockService.Verify();
        }
    }
}
