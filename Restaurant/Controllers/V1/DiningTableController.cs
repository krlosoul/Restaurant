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
    public class DiningTableController : ControllerBase
    {
        private readonly IDiningTableService _service;

        public DiningTableController(IDiningTableService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        /// <summary>
        /// Get all DiningTable async.
        /// </summary>
        /// <returns>&lt;DataGridService&gt;.</returns>
        [HttpGet("DiningTableGet")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ResponseService), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetDiningTable()
        {
            Response response = new Response();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                ResponseService responseService = await _service.GetDiningTableAsync();
                return responseService.ResponseCode switch
                {
                    (int)Enumerator.ResponseCode.Ok => Ok(Mapper.Map<Response>(responseService)),
                    (int)Enumerator.ResponseCode.BadRequest => BadRequest(Mapper.Map<Response>(responseService)),
                    _ => NoContent(),
                };
            }
            catch (UseCaseException ex)
            {
                response.Message = $"{nameof(GetDiningTable)}: {ex.Message}";

                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        /// <summary>
        /// Create DiningTable async.
        /// </summary>
        /// <param name="createDiningTableDto">The Dto CreateDiningTableDto.</param>
        /// <returns>&lt;DataGridService&gt;.</returns>
        [HttpPost("CreateDiningTable")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ResponseService), (int)HttpStatusCode.OK)]
        [Produces(MediaTypeNames.Application.Json, Type = typeof(CreateDiningTableDto))]
        public async Task<IActionResult> CreateDiningTable([FromBody] CreateDiningTableDto createDiningTableDto)
        {
            Response response = new Response();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                ResponseService responseService = await _service.CreateDiningTableAsync(createDiningTableDto);
                return responseService.ResponseCode switch
                {
                    (int)Enumerator.ResponseCode.Ok => Ok(Mapper.Map<Response>(responseService)),
                    (int)Enumerator.ResponseCode.BadRequest => BadRequest(Mapper.Map<Response>(responseService)),
                    _ => NoContent(),
                };
            }
            catch (UseCaseException ex)
            {
                response.Message = $"{nameof(CreateDiningTable)}: {ex.Message}";

                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        /// <summary>
        /// Update DiningTable async.
        /// </summary>
        /// <param name="diningTableDto">The Dto DiningTableDto.</param>
        /// <returns>&lt;DataGridService&gt;.</returns>
        [HttpPut("UpdateDiningTable")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ResponseService), (int)HttpStatusCode.OK)]
        [Produces(MediaTypeNames.Application.Json, Type = typeof(DiningTableDto))]
        public async Task<IActionResult> UpdateDiningTable([FromBody] DiningTableDto diningTableDto)
        {
            Response response = new Response();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                ResponseService responseService = await _service.UpdateDiningTableAsync(diningTableDto);
                return responseService.ResponseCode switch
                {
                    (int)Enumerator.ResponseCode.Ok => Ok(Mapper.Map<Response>(responseService)),
                    (int)Enumerator.ResponseCode.BadRequest => BadRequest(Mapper.Map<Response>(responseService)),
                    _ => NoContent(),
                };
            }
            catch (UseCaseException ex)
            {
                response.Message = $"{nameof(UpdateDiningTable)}: {ex.Message}";

                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        /// <summary>
        /// Delete DiningTable async.
        /// </summary>
        /// <param name="idDiningTable">The dining table identification.</param>
        /// <returns>&lt;DataGridService&gt;.</returns>
        [HttpDelete("DeleteDiningTable")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ResponseService), (int)HttpStatusCode.OK)]
        [Produces(MediaTypeNames.Application.Json, Type = typeof(int))]
        public async Task<IActionResult> DeleteDiningTable([FromQuery] int idDiningTable)
        {
            Response response = new Response();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                ResponseService responseService = await _service.DeleteDiningTableAsync(idDiningTable);
                return responseService.ResponseCode switch
                {
                    (int)Enumerator.ResponseCode.Ok => Ok(Mapper.Map<Response>(responseService)),
                    (int)Enumerator.ResponseCode.BadRequest => BadRequest(Mapper.Map<Response>(responseService)),
                    _ => NoContent(),
                };
            }
            catch (UseCaseException ex)
            {
                response.Message = $"{nameof(DeleteDiningTable)}: {ex.Message}";

                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}
