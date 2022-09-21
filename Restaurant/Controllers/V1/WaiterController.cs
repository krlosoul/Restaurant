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
    public class WaiterController : ControllerBase
    {
        private readonly IWaiterService _service;

        public WaiterController(IWaiterService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        /// <summary>
        /// Get all Waiter async.
        /// </summary>
        /// <returns>&lt;DataGridService&gt;.</returns>
        [HttpGet("WaiterGet")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ResponseService), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetWaiter()
        {
            Response response = new Response();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                ResponseService responseService = await _service.GetWaiterAsync();
                return responseService.ResponseCode switch
                {
                    (int)Enumerator.ResponseCode.Ok => Ok(Mapper.Map<Response>(responseService)),
                    (int)Enumerator.ResponseCode.BadRequest => BadRequest(Mapper.Map<Response>(responseService)),
                    _ => NoContent(),
                };
            }
            catch (UseCaseException ex)
            {
                response.Message = $"{nameof(GetWaiter)}: {ex.Message}";

                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        /// <summary>
        /// Create Waiter async.
        /// </summary>
        /// <param name="createWaiterDto">The CreateWaiterDto.</param>
        /// <returns>&lt;DataGridService&gt;.</returns>
        [HttpPost("CreateWaiter")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ResponseService), (int)HttpStatusCode.OK)]
        [Produces(MediaTypeNames.Application.Json, Type = typeof(CreateWaiterDto))]
        public async Task<IActionResult> CreateWaiter([FromBody] CreateWaiterDto createWaiterDto)
        {
            Response response = new Response();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                ResponseService responseService = await _service.CreateWaiterAsync(createWaiterDto);
                return responseService.ResponseCode switch
                {
                    (int)Enumerator.ResponseCode.Ok => Ok(Mapper.Map<Response>(responseService)),
                    (int)Enumerator.ResponseCode.BadRequest => BadRequest(Mapper.Map<Response>(responseService)),
                    _ => NoContent(),
                };
            }
            catch (UseCaseException ex)
            {
                response.Message = $"{nameof(CreateWaiter)}: {ex.Message}";

                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        /// <summary>
        /// Update Waiter async.
        /// </summary>
        /// <param name="WaiterDto">The Dto WaiterDto.</param>
        /// <returns>&lt;DataGridService&gt;.</returns>
        [HttpPut("UpdateWaiter")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ResponseService), (int)HttpStatusCode.OK)]
        [Produces(MediaTypeNames.Application.Json, Type = typeof(WaiterDto))]
        public async Task<IActionResult> UpdateWaiter([FromBody] WaiterDto WaiterDto)
        {
            Response response = new Response();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                ResponseService responseService = await _service.UpdateWaiterAsync(WaiterDto);
                return responseService.ResponseCode switch
                {
                    (int)Enumerator.ResponseCode.Ok => Ok(Mapper.Map<Response>(responseService)),
                    (int)Enumerator.ResponseCode.BadRequest => BadRequest(Mapper.Map<Response>(responseService)),
                    _ => NoContent(),
                };
            }
            catch (UseCaseException ex)
            {
                response.Message = $"{nameof(UpdateWaiter)}: {ex.Message}";

                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        /// <summary>
        /// Delete Waiter async.
        /// </summary>
        /// <param name="idWaiter">The waiter identification.</param>
        /// <returns>&lt;DataGridService&gt;.</returns>
        [HttpDelete("DeleteWaiter")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ResponseService), (int)HttpStatusCode.OK)]
        [Produces(MediaTypeNames.Application.Json, Type = typeof(int))]
        public async Task<IActionResult> DeleteWaiter([FromQuery] int idWaiter)
        {
            Response response = new Response();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                ResponseService responseService = await _service.DeleteWaiterAsync(idWaiter);
                return responseService.ResponseCode switch
                {
                    (int)Enumerator.ResponseCode.Ok => Ok(Mapper.Map<Response>(responseService)),
                    (int)Enumerator.ResponseCode.BadRequest => BadRequest(Mapper.Map<Response>(responseService)),
                    _ => NoContent(),
                };
            }
            catch (UseCaseException ex)
            {
                response.Message = $"{nameof(DeleteWaiter)}: {ex.Message}";

                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        /// <summary>
        /// Get waiter sales async.
        /// </summary>
        /// <param name="dateRangeDto">The DateRangeDto.</param>
        /// <returns>&lt;DataGridService&gt;.</returns>
        [HttpGet("WaiterSalesGet")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ResponseService), (int)HttpStatusCode.OK)]
        [Produces(MediaTypeNames.Application.Json, Type = typeof(DateRangeDto))]
        public async Task<IActionResult> GetWaiterSales([FromQuery] DateRangeDto dateRangeDto)
        {
            Response response = new Response();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                ResponseService responseService = await _service.GetWaiterSalesAsync(dateRangeDto);
                return responseService.ResponseCode switch
                {
                    (int)Enumerator.ResponseCode.Ok => Ok(Mapper.Map<Response>(responseService)),
                    (int)Enumerator.ResponseCode.BadRequest => BadRequest(Mapper.Map<Response>(responseService)),
                    _ => NoContent(),
                };
            }
            catch (UseCaseException ex)
            {
                response.Message = $"{nameof(GetWaiterSales)}: {ex.Message}";

                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}
