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
        private readonly IOsService _osService;

        public OsController(IOsService osService)
        {
            _osService = osService;
        }

        [HttpGet]
        public IActionResult GetAllOs()
        {
            var osList = _osService.GetAllOs();
            return Ok(osList);
        }

        [HttpGet("{id}")]
        public IActionResult GetOsById(Guid id)
        {
            var os = _osService.GetOsById(id);

            if (os == null)
            {
                return NotFound();
            }

            return Ok(os);
        }

        [HttpGet("opensource/{isOpenSource}")]
        public IActionResult GetAllOsOpenSource(bool isOpenSource)
        {
            var osList = _osService.GetByOpenSource(isOpenSource);
            return Ok(osList);
        }

        [HttpPost]
        public IActionResult CreateOs([FromBody] CreateOsView osView)
        {
            var osModel = _osService.CreateOs(osView);
            return Ok(osModel);
        }

        [HttpPut]
        public IActionResult UpdateOs([FromBody] UpdateOsView osView)
        {
            var updatedOs = _osService.UpdateOs(osView);

            return Ok(updatedOs);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOs(Guid id)
        {
            _osService.DeleteOs(id);
            return Ok();
        }

        [HttpGet("search/{search}")]
        public IActionResult SearchOs(string search)
        {
            var osList = _osService.SearchOs(search);
            return Ok(osList);
        }
    }
}
