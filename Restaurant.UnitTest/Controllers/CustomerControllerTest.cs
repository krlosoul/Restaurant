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
    public class CustomerControllerTest
    {
        private MockRepository _mockRepository;
        private Mock<ICustomerService> _mockService;

        private CustomerController Controller()
        {
            CustomerController controllerCOntext = new CustomerController(_mockService.Object)
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
            _mockService = _mockRepository.Create<ICustomerService>();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetCustomer_ExpectedSeup_ModelState()
        {
            _mockService.Setup(x => x.GetCustomerAsync()).ReturnsAsync(ResponseServiceStub.responseServiceBadRequest);

            var controller = Controller();
            controller.ModelState.AddModelError("ModelState", "Error model data");
            var result = await controller.GetCustomer();

            var okResult = result as BadRequestResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetCustomer_ExpectedSeup_Ok()
        {
            _mockService.Setup(x => x.GetCustomerAsync()).ReturnsAsync(ResponseServiceStub.responseServiceOk);

            var controller = Controller();
            var result = await controller.GetCustomer();

            var okResult = result as OkObjectResult;
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetCustomer_ExpectedSeup_BadRequest()
        {
            _mockService.Setup(x => x.GetCustomerAsync()).ReturnsAsync(ResponseServiceStub.responseServiceBadRequest);

            var controller = Controller();
            var result = await controller.GetCustomer();

            var okResult = result as BadRequestObjectResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetCustomer_ExpectedSeup_NoContent()
        {
            _mockService.Setup(x => x.GetCustomerAsync()).ReturnsAsync(ResponseServiceStub.responseServiceNoContent);

            var controller = Controller();
            var result = await controller.GetCustomer();

            var okResult = result as NoContentResult;
            Assert.AreEqual(StatusCodes.Status204NoContent, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetCustomer_ExpectedSeup_InternalServerError()
        {
            _mockService.Setup(x => x.GetCustomerAsync()).ThrowsAsync(new UseCaseException());

            var controller = Controller();
            var result = await controller.GetCustomer();

            var okResult = result as ObjectResult;
            Assert.AreEqual(StatusCodes.Status500InternalServerError, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task CreateCustomer_ExpectedSeup_ModelState()
        {
            _mockService.Setup(x => x.CreateCustomerAsync(It.IsAny<CustomerDto>())).ReturnsAsync(ResponseServiceStub.responseServiceBadRequest);

            var controller = Controller();
            controller.ModelState.AddModelError("ModelState", "Error model data");
            var result = await controller.CreateCustomer(It.IsAny<CustomerDto>());

            var okResult = result as BadRequestResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task CreateCustomer_ExpectedSeup_Ok()
        {
            _mockService.Setup(x => x.CreateCustomerAsync(It.IsAny<CustomerDto>())).ReturnsAsync(ResponseServiceStub.responseServiceOk);

            var controller = Controller();
            var result = await controller.CreateCustomer(It.IsAny<CustomerDto>());

            var okResult = result as OkObjectResult;
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task CreateCustomer_ExpectedSeup_BadRequest()
        {
            _mockService.Setup(x => x.CreateCustomerAsync(It.IsAny<CustomerDto>())).ReturnsAsync(ResponseServiceStub.responseServiceBadRequest);

            var controller = Controller();
            var result = await controller.CreateCustomer(It.IsAny<CustomerDto>());

            var okResult = result as BadRequestObjectResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task CreateCustomer_ExpectedSeup_NoContent()
        {
            _mockService.Setup(x => x.CreateCustomerAsync(It.IsAny<CustomerDto>())).ReturnsAsync(ResponseServiceStub.responseServiceNoContent);

            var controller = Controller();
            var result = await controller.CreateCustomer(It.IsAny<CustomerDto>());

            var okResult = result as NoContentResult;
            Assert.AreEqual(StatusCodes.Status204NoContent, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task CreateCustomer_ExpectedSeup_InternalServerError()
        {
            _mockService.Setup(x => x.CreateCustomerAsync(It.IsAny<CustomerDto>())).ThrowsAsync(new UseCaseException());

            var controller = Controller();
            var result = await controller.CreateCustomer(It.IsAny<CustomerDto>());

            var okResult = result as ObjectResult;
            Assert.AreEqual(StatusCodes.Status500InternalServerError, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task UpdateCustomer_ExpectedSeup_ModelState()
        {
            _mockService.Setup(x => x.UpdateCustomerAsync(It.IsAny<CustomerDto>())).ReturnsAsync(ResponseServiceStub.responseServiceBadRequest);

            var controller = Controller();
            controller.ModelState.AddModelError("ModelState", "Error model data");
            var result = await controller.UpdateCustomer(It.IsAny<CustomerDto>());

            var okResult = result as BadRequestResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task UpdateCustomer_ExpectedSeup_Ok()
        {
            _mockService.Setup(x => x.UpdateCustomerAsync(It.IsAny<CustomerDto>())).ReturnsAsync(ResponseServiceStub.responseServiceOk);

            var controller = Controller();
            var result = await controller.UpdateCustomer(It.IsAny<CustomerDto>());

            var okResult = result as OkObjectResult;
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task UpdateCustomer_ExpectedSeup_BadRequest()
        {
            _mockService.Setup(x => x.UpdateCustomerAsync(It.IsAny<CustomerDto>())).ReturnsAsync(ResponseServiceStub.responseServiceBadRequest);

            var controller = Controller();
            var result = await controller.UpdateCustomer(It.IsAny<CustomerDto>());

            var okResult = result as BadRequestObjectResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task UpdateCustomer_ExpectedSeup_NoContent()
        {
            _mockService.Setup(x => x.UpdateCustomerAsync(It.IsAny<CustomerDto>())).ReturnsAsync(ResponseServiceStub.responseServiceNoContent);

            var controller = Controller();
            var result = await controller.UpdateCustomer(It.IsAny<CustomerDto>());

            var okResult = result as NoContentResult;
            Assert.AreEqual(StatusCodes.Status204NoContent, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task UpdateCustomer_ExpectedSeup_InternalServerError()
        {
            _mockService.Setup(x => x.UpdateCustomerAsync(It.IsAny<CustomerDto>())).ThrowsAsync(new UseCaseException());

            var controller = Controller();
            var result = await controller.UpdateCustomer(It.IsAny<CustomerDto>());

            var okResult = result as ObjectResult;
            Assert.AreEqual(StatusCodes.Status500InternalServerError, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task DeleteCustomer_ExpectedSeup_ModelState()
        {
            _mockService.Setup(x => x.DeleteCustomerAsync(It.IsAny<string>())).ReturnsAsync(ResponseServiceStub.responseServiceBadRequest);

            var controller = Controller();
            controller.ModelState.AddModelError("ModelState", "Error model data");
            var result = await controller.DeleteCustomer(It.IsAny<string>());

            var okResult = result as BadRequestResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task DeleteCustomer_ExpectedSeup_Ok()
        {
            _mockService.Setup(x => x.DeleteCustomerAsync(It.IsAny<string>())).ReturnsAsync(ResponseServiceStub.responseServiceOk);

            var controller = Controller();
            var result = await controller.DeleteCustomer(It.IsAny<string>());

            var okResult = result as OkObjectResult;
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task DeleteCustomer_ExpectedSeup_BadRequest()
        {
            _mockService.Setup(x => x.DeleteCustomerAsync(It.IsAny<string>())).ReturnsAsync(ResponseServiceStub.responseServiceBadRequest);

            var controller = Controller();
            var result = await controller.DeleteCustomer(It.IsAny<string>());

            var okResult = result as BadRequestObjectResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task DeleteCustomer_ExpectedSeup_NoContent()
        {
            _mockService.Setup(x => x.DeleteCustomerAsync(It.IsAny<string>())).ReturnsAsync(ResponseServiceStub.responseServiceNoContent);

            var controller = Controller();
            var result = await controller.DeleteCustomer(It.IsAny<string>());

            var okResult = result as NoContentResult;
            Assert.AreEqual(StatusCodes.Status204NoContent, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task DeleteCustomer_ExpectedSeup_InternalServerError()
        {
            _mockService.Setup(x => x.DeleteCustomerAsync(It.IsAny<string>())).ThrowsAsync(new UseCaseException());

            var controller = Controller();
            var result = await controller.DeleteCustomer(It.IsAny<string>());

            var okResult = result as ObjectResult;
            Assert.AreEqual(StatusCodes.Status500InternalServerError, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetCustomerSpend_ExpectedSeup_ModelState()
        {
            _mockService.Setup(x => x.GetCustomerSpendAsync(It.IsAny<GetCustomerDto>())).ReturnsAsync(ResponseServiceStub.responseServiceBadRequest);

            var controller = Controller();
            controller.ModelState.AddModelError("ModelState", "Error model data");
            var result = await controller.GetCustomerSpend(It.IsAny<GetCustomerDto>());

            var okResult = result as BadRequestResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetCustomerSpend_ExpectedSeup_Ok()
        {
            _mockService.Setup(x => x.GetCustomerSpendAsync(It.IsAny<GetCustomerDto>())).ReturnsAsync(ResponseServiceStub.responseServiceOk);

            var controller = Controller();
            var result = await controller.GetCustomerSpend(It.IsAny<GetCustomerDto>());

            var okResult = result as OkObjectResult;
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetCustomerSpend_ExpectedSeup_BadRequest()
        {
            _mockService.Setup(x => x.GetCustomerSpendAsync(It.IsAny<GetCustomerDto>())).ReturnsAsync(ResponseServiceStub.responseServiceBadRequest);

            var controller = Controller();
            var result = await controller.GetCustomerSpend(It.IsAny<GetCustomerDto>());

            var okResult = result as BadRequestObjectResult;
            Assert.AreEqual(StatusCodes.Status400BadRequest, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetCustomerSpend_ExpectedSeup_NoContent()
        {
            _mockService.Setup(x => x.GetCustomerSpendAsync(It.IsAny<GetCustomerDto>())).ReturnsAsync(ResponseServiceStub.responseServiceNoContent);

            var controller = Controller();
            var result = await controller.GetCustomerSpend(It.IsAny<GetCustomerDto>());

            var okResult = result as NoContentResult;
            Assert.AreEqual(StatusCodes.Status204NoContent, okResult.StatusCode);

            _mockService.Verify();
        }

        [TestMethod]
        [Owner("ccrodriguez")]
        public async Task GetCustomerSpend_ExpectedSeup_InternalServerError()
        {
            _mockService.Setup(x => x.GetCustomerSpendAsync(It.IsAny<GetCustomerDto>())).ThrowsAsync(new UseCaseException());

            var controller = Controller();
            var result = await controller.GetCustomerSpend(It.IsAny<GetCustomerDto>());

            var okResult = result as ObjectResult;
            Assert.AreEqual(StatusCodes.Status500InternalServerError, okResult.StatusCode);

            _mockService.Verify();
        }
    }
}
