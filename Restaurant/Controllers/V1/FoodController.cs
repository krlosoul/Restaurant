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
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _service;

        public FoodController(IFoodService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        /// <summary>
        /// Get all Food async.
        /// </summary>
        /// <returns>&lt;DataGridService&gt;.</returns>
        [HttpGet("FoodGet")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ResponseService), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetFood()
        {
            Response response = new Response();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                ResponseService responseService = await _service.GetFoodAsync();
                return responseService.ResponseCode switch
                {
                    (int)Enumerator.ResponseCode.Ok => Ok(Mapper.Map<Response>(responseService)),
                    (int)Enumerator.ResponseCode.BadRequest => BadRequest(Mapper.Map<Response>(responseService)),
                    _ => NoContent(),
                };
            }
            catch (UseCaseException ex)
            {
                response.Message = $"{nameof(GetFood)}: {ex.Message}";

                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        /// <summary>
        /// Create Food async.
        /// </summary>
        /// <param name="createFoodDto">The CreateFoodDto.</param>
        /// <returns>&lt;DataGridService&gt;.</returns>
        [HttpPost("CreateFood")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ResponseService), (int)HttpStatusCode.OK)]
        [Produces(MediaTypeNames.Application.Json, Type = typeof(CreateFoodDto))]
        public async Task<IActionResult> CreateFood([FromBody] CreateFoodDto createFoodDto)
        {
            Response response = new Response();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                ResponseService responseService = await _service.CreateFoodAsync(createFoodDto);
                return responseService.ResponseCode switch
                {
                    (int)Enumerator.ResponseCode.Ok => Ok(Mapper.Map<Response>(responseService)),
                    (int)Enumerator.ResponseCode.BadRequest => BadRequest(Mapper.Map<Response>(responseService)),
                    _ => NoContent(),
                };
            }
            catch (UseCaseException ex)
            {
                response.Message = $"{nameof(CreateFood)}: {ex.Message}";

                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        /// <summary>
        /// Update Food async.
        /// </summary>
        /// <param name="FoodDto">The Dto FoodDto.</param>
        /// <returns>&lt;DataGridService&gt;.</returns>
        [HttpPut("UpdateFood")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ResponseService), (int)HttpStatusCode.OK)]
        [Produces(MediaTypeNames.Application.Json, Type = typeof(FoodDto))]
        public async Task<IActionResult> UpdateFood([FromBody] FoodDto FoodDto)
        {
            Response response = new Response();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                ResponseService responseService = await _service.UpdateFoodAsync(FoodDto);
                return responseService.ResponseCode switch
                {
                    (int)Enumerator.ResponseCode.Ok => Ok(Mapper.Map<Response>(responseService)),
                    (int)Enumerator.ResponseCode.BadRequest => BadRequest(Mapper.Map<Response>(responseService)),
                    _ => NoContent(),
                };
            }
            catch (UseCaseException ex)
            {
                response.Message = $"{nameof(UpdateFood)}: {ex.Message}";

                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        /// <summary>
        /// Delete Food async.
        /// </summary>
        /// <param name="idFood">The food identification.</param>
        /// <returns>&lt;DataGridService&gt;.</returns>
        [HttpDelete("DeleteFood")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ResponseService), (int)HttpStatusCode.OK)]
        [Produces(MediaTypeNames.Application.Json, Type = typeof(int))]
        public async Task<IActionResult> DeleteFood([FromQuery] int idFood)
        {
            Response response = new Response();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                ResponseService responseService = await _service.DeleteFoodAsync(idFood);
                return responseService.ResponseCode switch
                {
                    (int)Enumerator.ResponseCode.Ok => Ok(Mapper.Map<Response>(responseService)),
                    (int)Enumerator.ResponseCode.BadRequest => BadRequest(Mapper.Map<Response>(responseService)),
                    _ => NoContent(),
                };
            }
            catch (UseCaseException ex)
            {
                response.Message = $"{nameof(DeleteFood)}: {ex.Message}";

                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        /// <summary>
        /// Get sales food async.
        /// </summary>
        /// <param name="requestService">The Dto RequestService.</param>
        /// <returns>&lt;DataGridService&gt;.</returns>
        [HttpGet("SalesFoodGet")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ResponseService), (int)HttpStatusCode.OK)]
        [Produces(MediaTypeNames.Application.Json, Type = typeof(DateRangeDto))]
        public async Task<IActionResult> GetSalesFood([FromQuery] DateRangeDto requestService)
        {
            Response response = new Response();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                ResponseService responseService = await _service.GetSalesFoodAsync(requestService);
                return responseService.ResponseCode switch
                {
                    (int)Enumerator.ResponseCode.Ok => Ok(Mapper.Map<Response>(responseService)),
                    (int)Enumerator.ResponseCode.BadRequest => BadRequest(Mapper.Map<Response>(responseService)),
                    _ => NoContent(),
                };
            }
            catch (UseCaseException ex)
            {
                response.Message = $"{nameof(GetSalesFood)}: {ex.Message}";

                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}
