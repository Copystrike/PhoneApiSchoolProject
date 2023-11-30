using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhoneApiSchoolProject.Models;
using PhoneApiSchoolProject.Services;
using PhoneApiSchoolProject.View;

namespace PhoneApiSchoolProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private readonly IPhoneService _phoneService;
        private readonly IMapper _mapper;

        public PhoneController(IPhoneService phoneService, IMapper mapper)
        {
            this._phoneService = phoneService;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllPhones()
        {
            var phones = _phoneService.GetAllPhones();

            if (phones.Count == 0)
            {
                return NotFound();
            }

            return Ok(phones);
        }

        [HttpGet("{id}")]
        public IActionResult GetPhoneById(Guid id)
        {
            var phone = _phoneService.GetPhoneById(id);
            if (phone == null)
            {
                return NotFound();
            }

            return Ok(phone);
        }

        [HttpGet("brand/{brand}")]
        public IActionResult GetPhonesByBrand(string brand)
        {
            var phones = _phoneService.GetPhonesByBrand(brand);
            return Ok(phones);
        }

        [HttpPost]
        public IActionResult CreatePhone([FromBody] CreatePhoneView phoneView)
        {
            var newPhone = _mapper.Map<PhoneModel>(phoneView);
            var addedPhone = _phoneService.CreatePhone(newPhone);
            return Ok(addedPhone);
        }

        [HttpPut]
        // Return bad request if the phone is not found
        public IActionResult UpdatePhone([FromBody] UpdatePhoneView phoneView)
        {
            var newPhone = _mapper.Map<PhoneModel>(phoneView);
            var updatedPhone = _phoneService.UpdatePhone(newPhone);
            
            if (updatedPhone == null)
            {
                return BadRequest();
            }

            return Ok(updatedPhone);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePhone(Guid id)
        {
            _phoneService.GetPhoneById(id);
            return Ok();
        }

        [HttpGet("search/{search}")]
        public IActionResult SearchPhones(string search)
        {
            var phones = _phoneService.SearchPhones(search);
            return Ok(phones);
        }
    }
}