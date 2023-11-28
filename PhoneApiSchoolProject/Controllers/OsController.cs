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
    public class OsController : ControllerBase
    {
        private readonly IOsService _oSService;
        private readonly IMapper _mapper;

        public OsController(IOsService osService, IMapper mapper)
        {
            this._oSService = osService;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllOs()
        {
            var osList = _oSService.GetAllOs();
            
            if (osList.Count == 0)
            {
                return NotFound();
            }
            
            return Ok(osList);
        }

        [HttpGet("{id}")]
        public IActionResult GetOsById(Guid id)
        {
            var os = _oSService.GetOsById(id);

            if (os == null)
            {
                return NotFound();
            }

            return Ok(os);
        }

        [HttpGet("opensource/{isOpenSource}")]
        public IActionResult GetAllOsOpenSource(bool isOpenSource)
        {
            var os = _oSService.GetByOpenSource(isOpenSource);

            if (os.Count == 0)
            {
                return NotFound();
            }

            return Ok(os);
        }

        [HttpPost]
        public IActionResult CreateOs([FromBody] CreateOsView osView)
        {
            var newOs = _mapper.Map<OsModel>(osView);
            var addedOs = _oSService.CreateOs(newOs);
            return Ok(addedOs);
        }

        [HttpPut]
        public IActionResult UpdateOs([FromBody] UpdateOsView osView)
        {
            var newOs = _mapper.Map<OsModel>(osView);

            var existingOs = _oSService.GetOsById(newOs.Id);

            if (existingOs == null)
            {
                return NotFound();
            }

            _mapper.Map(osView, existingOs);

            var updatedOs = _oSService.UpdateOs(existingOs);

            return Ok(updatedOs);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOs(Guid id)
        {
            var existingOs = _oSService.GetOsById(id);

            if (existingOs == null)
            {
                return NotFound();
            }

            _oSService.DeleteOs(id);
            return Ok();
        }

        [HttpGet("search/{search}")]
        public IActionResult SearchOs(string search)
        {
            var os = _oSService.SearchOs(search);

            if (os.Count == 0)
            {
                return NotFound();
            }

            return Ok(os);
        }
    }
}