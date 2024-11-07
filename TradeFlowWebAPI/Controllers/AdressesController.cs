using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TradeFlowAPI.Business.Abstract;
using TradeFlowAPI.Entities.DTOs;
using TradeFlowAPI.Entities.Concrete;
using System;

namespace TradeFlowWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdressesController : ControllerBase
    {
        private readonly IAdressService _adressService;

        public AdressesController(IAdressService adressService)
        {
            _adressService = adressService;
        }

        [HttpPost]
        public IActionResult Add(AdressDetailDto addressDto)
        {
            var result = _adressService.Add(addressDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var result = _adressService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, AdressDetailDto addressDto)
        {
            var result = _adressService.Update(id, addressDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getAll")]
        public IActionResult GetAllAddresses()
        {
            var result = _adressService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getByCity")]
        public IActionResult GetByCity(string city)
        {
            var result = _adressService.GetByCity(city);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getByState")]
        public IActionResult GetByState(string state)
        {
            var result = _adressService.GetByState(state);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getByZipCode")]
        public IActionResult GetByZipCode(string zipCode)
        {
            var result = _adressService.GetByZipCode(zipCode);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getByUserId")]
        public IActionResult GetByUserId(Guid userId)
        {
            var result = _adressService.GetByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getByAddressType")]
        public IActionResult GetByAddressType(int type)
        {
            var result = _adressService.GetByAddressType((TradeFlowAPI.Entities.Enums.AddressType)type);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
