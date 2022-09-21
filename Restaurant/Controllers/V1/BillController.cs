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
    public class BillController : ControllerBase
    {
        private readonly IBillService _service;

        public BillController(IBillService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        /// <summary>
        /// Create bill async.
        /// </summary>
        /// <param name="createBillDto">The CreateBillDto.</param>
        /// <returns>&lt;DataGridService&gt;.</returns>
        [HttpPost("CreateBill")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ResponseService), (int)HttpStatusCode.OK)]
        [Produces(MediaTypeNames.Application.Json, Type = typeof(CreateBillDto))]
        public async Task<IActionResult> CreateBill([FromBody] CreateBillDto createBillDto)
        {
            Response response = new Response();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                ResponseService responseService = await _service.CreateBillAsync(createBillDto);
                return responseService.ResponseCode switch
                {
                    (int)Enumerator.ResponseCode.Ok => Ok(Mapper.Map<Response>(responseService)),
                    (int)Enumerator.ResponseCode.BadRequest => BadRequest(Mapper.Map<Response>(responseService)),
                    _ => NoContent(),
                };
            }
            catch (UseCaseException ex)
            {
                response.Message = $"{nameof(CreateBill)}: {ex.Message}";

                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        /// <summary>
        /// Get bills with details async.
        /// </summary>
        /// <param name="getBillsWithDetailsDto">The GetBillDetailDto.</param>
        /// <returns>&lt;DataGridService&gt;.</returns>
        [HttpGet("BillsWithDetailsGet")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ResponseService), (int)HttpStatusCode.OK)]
        [Produces(MediaTypeNames.Application.Json, Type = typeof(GetBillsWithDetailsDto))]
        public async Task<IActionResult> GetBillsWithDetails([FromQuery] GetBillsWithDetailsDto getBillsWithDetailsDto)
        {
            Response response = new Response();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                ResponseService responseService = await _service.GetBillsWithDetailsAsync(getBillsWithDetailsDto);
                return responseService.ResponseCode switch
                {
                    (int)Enumerator.ResponseCode.Ok => Ok(Mapper.Map<Response>(responseService)),
                    (int)Enumerator.ResponseCode.BadRequest => BadRequest(Mapper.Map<Response>(responseService)),
                    _ => NoContent(),
                };
            }
            catch (UseCaseException ex)
            {
                response.Message = $"{nameof(GetBillsWithDetails)}: {ex.Message}";

                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}
