using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusalaGatewayProject.Data;
using MusalaGatewayProject.Models;
using MusalaGatewayProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusalaGatewayProject.Helpers;

namespace MusalaGatewayProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatewayController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GatewayController> _logger;
        private readonly IMapper _mapper;

        public GatewayController(IUnitOfWork unitOfWork, ILogger<GatewayController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(Name = nameof(GetGateways))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetGateways([FromQuery] RequestParams requestParams)
        {
            try
            {
                var gateways = await _unitOfWork.Gateways.GetAll();
                var results = _mapper.Map<List<GatewayDTO>>(gateways);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in {nameof(GetGateways)}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{serialNumber:Guid}", Name = nameof(GetGateway))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetGateway(Guid serialNumber)
        {
            try
            {
                var gateways = await _unitOfWork.Gateways.Get(x => x.SerialNumber == serialNumber, new List<string> { nameof(Gateway.PeripheralDevices) });
                var result = _mapper.Map<GatewayDTO>(gateways);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in {nameof(GetGateways)}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost(Name = nameof(CreateGateway))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateGateway([FromBody] GatewayDTO gatewayDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateGateway)}");
                return BadRequest(ModelState);
            }

            if (!Helper.IsValidIpv4(gatewayDTO.IpAddress))
            {
                _logger.LogError("Invalid IP address in the model");
                return BadRequest("Invalid IP address in the model");
            }
            try
            {
            var gateway = _mapper.Map<Gateway>(gatewayDTO);
            await _unitOfWork.Gateways.Insert(gateway);
            await _unitOfWork.Save();
            return CreatedAtRoute(nameof(GetGateway), new { serialNumber = gateway.SerialNumber }, gateway);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in {nameof(GetGateways)}");
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPut("{serialNumber:Guid}", Name = nameof(UpdateGateway))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateGateway(Guid serialNumber, [FromBody] GatewayDTO gatewayDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid Update attempt in {nameof(UpdateGateway)}");
                return BadRequest(ModelState);
            }
            if (!Helper.IsValidIpv4(gatewayDTO.IpAddress))
            {
                _logger.LogError("Invalid IP address in the model");
                return BadRequest("Invalid IP address in the model");
            }
            try
            {
                var gateway = await _unitOfWork.Gateways.Get(q => q.SerialNumber == serialNumber);
                if (gateway == null)
                {
                    _logger.LogError($"Submitted data invalid in {nameof(UpdateGateway)}");
                    return BadRequest("Submited data is invalid");
                }
                _mapper.Map(gatewayDTO, gateway);
                _unitOfWork.Gateways.Update(gateway);
                await _unitOfWork.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in {nameof(GetGateways)}");
                return StatusCode(500, ex.Message);
            }
            

        }

        [HttpDelete("{serialNumber:Guid}", Name = nameof(DeleteGateway))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteGateway(Guid serialNumber)
        {
            try
            {
                var gateway = await _unitOfWork.Gateways.Get(q => q.SerialNumber == serialNumber);
                if (gateway == null)
                {
                    _logger.LogError($"Invalid Delete attempt in {nameof(DeleteGateway)}");
                    return BadRequest("Submitted data is invalid");
                }
                await _unitOfWork.Gateways.Delete(gateway);
                await _unitOfWork.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in {nameof(GetGateways)}");
                return StatusCode(500, ex.Message);
            }
            

        }


    }
}
