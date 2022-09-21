namespace Restaurant.Api.Controllers.V1
{
    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Restaurant.Business.Interfaces;
    using Restaurant.Core.Constants;
    using Restaurant.Core.Dtos;
    using Restaurant.Core.Exceptions;
    using Restaurant.Core.Services;
    using System;
    using System.Net;
    using System.Net.Mime;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/V1/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        /// <summary>
        /// Get all customers async.
        /// </summary>
        /// <returns>&lt;DataGridService&gt;.</returns>
        [HttpGet("CustomerGet")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ResponseService), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCustomer()
        {
            Response response = new Response();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                ResponseService responseService = await _service.GetCustomerAsync();
                return responseService.ResponseCode switch
                {
                    (int)Enumerator.ResponseCode.Ok => Ok(Mapper.Map<Response>(responseService)),
                    (int)Enumerator.ResponseCode.BadRequest => BadRequest(Mapper.Map<Response>(responseService)),
                    _ => NoContent(),
                };

            }
            catch (UseCaseException ex)
            {
                response.Message = $"{nameof(GetCustomer)}: {ex.Message}";

                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        /// <summary>
        /// Create customer async.
        /// </summary>
        /// <param name="customerDto">The customerDto.</param>
        /// <returns>&lt;DataGridService&gt;.</returns>
        [HttpPost("CreateCustomer")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ResponseService), (int)HttpStatusCode.OK)]
        [Produces(MediaTypeNames.Application.Json, Type = typeof(CustomerDto))]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerDto customerDto)
        {
            Response response = new Response();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                ResponseService responseService = await _service.CreateCustomerAsync(customerDto);
                return responseService.ResponseCode switch
                {
                    (int)Enumerator.ResponseCode.Ok => Ok(Mapper.Map<Response>(responseService)),
                    (int)Enumerator.ResponseCode.BadRequest => BadRequest(Mapper.Map<Response>(responseService)),
                    _ => NoContent(),
                };
            }
            catch (UseCaseException ex)
            {
                response.Message = $"{nameof(CreateCustomer)}: {ex.Message}";

                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        /// <summary>
        /// Update customer async.
        /// </summary>
        /// <param name="customerDto">The CustomerDto.</param>
        /// <returns>&lt;DataGridService&gt;.</returns>
        [HttpPut("UpdateCustomer")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ResponseService), (int)HttpStatusCode.OK)]
        [Produces(MediaTypeNames.Application.Json, Type = typeof(CustomerDto))]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomerDto customerDto)
        {
            Response response = new Response();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                ResponseService responseService = await _service.UpdateCustomerAsync(customerDto);
                return responseService.ResponseCode switch
                {
                    (int)Enumerator.ResponseCode.Ok => Ok(Mapper.Map<Response>(responseService)),
                    (int)Enumerator.ResponseCode.BadRequest => BadRequest(Mapper.Map<Response>(responseService)),
                    _ => NoContent(),
                };
            }
            catch (UseCaseException ex)
            {
                response.Message = $"{nameof(UpdateCustomer)}: {ex.Message}";

                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        /// <summary>
        /// Delete customer async.
        /// </summary>
        /// <param name="customerByIdDto">The CustomerByIdDto.</param>
        /// <returns>&lt;DataGridService&gt;.</returns>
        [HttpDelete("DeleteCustomer")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ResponseService), (int)HttpStatusCode.OK)]
        [Produces(MediaTypeNames.Application.Json, Type = typeof(string))]
        public async Task<IActionResult> DeleteCustomer([FromQuery] string idCustomer)
        {
            Response response = new Response();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                ResponseService responseService = await _service.DeleteCustomerAsync(idCustomer);
                return responseService.ResponseCode switch
                {
                    (int)Enumerator.ResponseCode.Ok => Ok(Mapper.Map<Response>(responseService)),
                    (int)Enumerator.ResponseCode.BadRequest => BadRequest(Mapper.Map<Response>(responseService)),
                    _ => NoContent(),
                };
            }
            catch (UseCaseException ex)
            {
                response.Message = $"{nameof(DeleteCustomer)}: {ex.Message}";

                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        /// <summary>
        /// Get customer spend by date range and spend min async.
        /// </summary>
        /// <param name="getCustomerDto">The GetCustomerDto.</param>
        /// <returns>&lt;DataGridService&gt;.</returns>
        [HttpGet("CustomerSpendGet")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ResponseService), (int)HttpStatusCode.OK)]
        [Produces(MediaTypeNames.Application.Json, Type = typeof(GetCustomerDto))]
        public async Task<IActionResult> GetCustomerSpend([FromQuery] GetCustomerDto getCustomerDto)
        {
            Response response = new Response();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                ResponseService responseService = await _service.GetCustomerSpendAsync(getCustomerDto);
                return responseService.ResponseCode switch
                {
                    (int)Enumerator.ResponseCode.Ok => Ok(Mapper.Map<Response>(responseService)),
                    (int)Enumerator.ResponseCode.BadRequest => BadRequest(Mapper.Map<Response>(responseService)),
                    _ => NoContent(),
                };
            }
            catch (UseCaseException ex)
            {
                response.Message = $"{nameof(GetCustomerSpend)}: {ex.Message}";

                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}
