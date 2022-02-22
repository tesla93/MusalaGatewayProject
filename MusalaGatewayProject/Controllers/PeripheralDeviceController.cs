using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusalaGatewayProject.Data;
using MusalaGatewayProject.Models;
using MusalaGatewayProject.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusalaGatewayProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeripheralDeviceController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PeripheralDeviceController> _logger;
        private readonly IMapper _mapper;

        public PeripheralDeviceController(IUnitOfWork unitOfWork, ILogger<PeripheralDeviceController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPeripheralDevices()
        {
            try
            {
                var peripheralDevices = await _unitOfWork.PeripheralDevices.GetAll();
                var results = _mapper.Map<List<PeripheralDeviceDTO>>(peripheralDevices);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error ocurred in {nameof(GetPeripheralDevices)}");
                return StatusCode(500, "Internal server error. Please try again later");
            }
        }

        [HttpGet("{id:int}", Name = nameof(GetPeripheralDevice))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetPeripheralDevice(int id)
        {
            try
            {
                var peripheralDevice = await _unitOfWork.PeripheralDevices.Get(x => x.Id == id, new List<string> { nameof(PeripheralDevice.GatewayNavigation) });
                var result = _mapper.Map<PeripheralDeviceDTO>(peripheralDevice);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error ocurred in {nameof(GetPeripheralDevice)}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost(Name =nameof(CreatePeripheralDevice))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreatePeripheralDevice([FromBody] PeripheralDeviceDTO peripheralDeviceDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"the attempt to create a new resource has failed in  {nameof(CreatePeripheralDevice)}");
                return BadRequest(ModelState);
            }
            try
            {
                var peripheralDevice = _mapper.Map<PeripheralDevice>(peripheralDeviceDTO);
                await _unitOfWork.PeripheralDevices.Insert(peripheralDevice);
                await _unitOfWork.Save();
                return CreatedAtRoute(nameof(GetPeripheralDevice), new { id = peripheralDevice.Id }, peripheralDevice);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error ocurred in {nameof(CreatePeripheralDevice)}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id:int}", Name =nameof(UpdatePeripheralDevice))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdatePeripheralDevice(int id, [FromBody] PeripheralDeviceDTO peripheralDeviceDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid Update attempt in {nameof(UpdatePeripheralDevice)}");
                return BadRequest(ModelState);
            }
            try
            {
                var peripheralDevice = await _unitOfWork.PeripheralDevices.Get(q => q.Id == id);
                if (peripheralDevice == null)
                {
                    _logger.LogError($"Submitted data invalid in {nameof(UpdatePeripheralDevice)}");
                    return BadRequest("Submited data is invalid");
                }
                _mapper.Map(peripheralDeviceDTO, peripheralDevice);
                _unitOfWork.PeripheralDevices.Update(peripheralDevice);
                _unitOfWork.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in {nameof(UpdatePeripheralDevice)}");
                return StatusCode(500, "Something went wrong. Try again later.");
            }
        }

        [HttpDelete("{id:int}", Name =nameof(DeletePeripheralDevice))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletePeripheralDevice(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid Delete attempt in {nameof(DeletePeripheralDevice)}");
                return BadRequest();
            }
            try
            {
                var peripheralDevice = await _unitOfWork.PeripheralDevices.Get(q => q.Id == id);
                if (peripheralDevice == null)
                {
                    _logger.LogError($"Invalid Delete attempt in {nameof(DeletePeripheralDevice)}");
                    return BadRequest("Submitted data is invalid");
                }
                await _unitOfWork.PeripheralDevices.Delete(peripheralDevice);
                await _unitOfWork.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in {nameof(DeletePeripheralDevice)}");
                return StatusCode(500, "Internal server error. Please try again later");
            }
        }
    }
}
