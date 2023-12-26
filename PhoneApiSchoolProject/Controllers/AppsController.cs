using System.Runtime.InteropServices;
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
    public class AppsController : ControllerBase
    {
        private readonly IAppsService _appsService;
        public AppsController(IAppsService appsService)
        {
            this._appsService = appsService;
        }

        [HttpGet]
        public IActionResult GetAllApps()
        {
            var apps = _appsService.GetAllApps();
            return Ok(apps);
        }

        [HttpGet("{id}")]
        public IActionResult GetAppById(Guid id)
        {
            var app = _appsService.GetAppById(id);
            return Ok(app);
        }

        [HttpGet("paid/{isPaid}")]
        public IActionResult GetAppsByIsPaid(bool isPaid)
        {
            var apps = _appsService.GetAppsByIsPaid(isPaid);
            return Ok(apps);
        }

        [HttpPost]
        public IActionResult CreateApp([FromBody] CreateAppView appView)
        {
            var addedApp = _appsService.CreateApp(appView);
            return Ok(addedApp);
        }

        [HttpPut]
        public IActionResult UpdateApp([FromBody] UpdateAppView appView)
        {
            var updatedApp = _appsService.UpdateApp(appView);
            
            if (updatedApp == null)
            {
                return NotFound();
            }
            
            return Ok(updatedApp);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteApp(Guid id)
        {
            _appsService.DeleteApp(id);
            return Ok();
        }

        [HttpGet("search/{name}")]
        public IActionResult SearchApps(string name)
        {
            var apps = _appsService.SearchApps(name);
            return Ok(apps);
        }

        [HttpGet("os/{osId}")]
        public IActionResult GetAppsByOsId(Guid osId)
        {
            var apps = _appsService.GetAppsByOsId(osId);
            return Ok(apps);
        }
    }
}