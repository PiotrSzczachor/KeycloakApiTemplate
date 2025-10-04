using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Domain;
using Models.DTOs;

namespace KeycloakApiTemplate.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("address")]
    public class AddressController : Controller
    {
        private readonly IAddressesService _addressesService;
        public AddressController(IAddressesService addressService)
        {
            _addressesService = addressService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Address), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAddresses()
        {
            var offers = await _addressesService.GetAllAddressesAsync();
            return Ok();
        }


        [HttpPost]
        [ProducesResponseType(typeof(Address), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateAddress([FromBody] Address address)
        {
            if (address == null)
                return BadRequest("Event data is required.");

            var createdEvent = await _addressesService.CreateAddressAsync(address);

            return Ok(createdEvent);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Address), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateAddressAsync([FromBody] Address address)
        {
            var createdEvent = await _addressesService.UpdateAddressAsync(address);
            return Ok();
        }
    }
}