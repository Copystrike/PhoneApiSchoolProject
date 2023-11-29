using AutoMapper;
using Microsoft.AspNetCore.Http;
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

            if (phones.Count == 0)
            {
                return NotFound();
            }

            // Bad request


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

            var existingPhone = _phoneService.GetPhoneById(newPhone.Id);

            if (existingPhone == null)
            {
                return NotFound();
            }

            _mapper.Map(phoneView, existingPhone);

            var updatedPhone = _phoneService.UpdatePhone(existingPhone);

            return Ok(updatedPhone);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePhone(Guid id)
        {
            var existingPhone = _phoneService.GetPhoneById(id);

            if (existingPhone == null)
            {
                return NotFound();
            }

            var isDeleted = _phoneService.DeletePhone(id); 
            
            if (!isDeleted)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            
            
            return Ok();
        }

        [HttpGet("search/{search}")]
        public IActionResult SearchPhones(string search)
        {
            var phones = _phoneService.SearchPhones(search);

            if (phones.Count == 0)
            {
                return NotFound();
            }

            return Ok(phones);
        }
    }
}