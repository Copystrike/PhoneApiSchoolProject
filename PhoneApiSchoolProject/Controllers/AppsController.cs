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
        private readonly IMapper _mapper;

        public AppsController(IAppsService appsService, IMapper mapper)
        {
            this._appsService = appsService;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllApps()
        {
            var apps = _appsService.GetAllApps();

            if (apps.Count == 0)
            {
                return NotFound();
            }

            return Ok(apps);
        }

        [HttpGet("{id}")]
        public IActionResult GetAppById(Guid id)
        {
            var app = _appsService.GetAppById(id);

            if (app == null)
            {
                return NotFound();
            }

            return Ok(app);
        }

        [HttpGet("paid/{isPaid}")]
        public IActionResult GetAppsByIsPaid(bool isPaid)
        {
            var apps = _appsService.GetAppsByIsPaid(isPaid);

            if (apps.Count == 0)
            {
                return NotFound();
            }

            return Ok(apps);
        }

        [HttpPost]
        public IActionResult AddApp([FromBody] CreateAppView appView)
        {
            var newApp = _mapper.Map<AppsModel>(appView);
            var addedApp = _appsService.AddApp(newApp);
            return Ok(addedApp);
        }

        [HttpPut]
        public IActionResult UpdateApp([FromBody] UpdateAppView appView)
        {
            var newApp = _mapper.Map<AppsModel>(appView);

            var existingApp = _appsService.GetAppById(newApp.Id);

            if (existingApp == null)
            {
                return NotFound();
            }

            _mapper.Map(appView, existingApp);

            var updatedApp = _appsService.UpdateApp(existingApp);

            return Ok(updatedApp);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteApp(Guid id)
        {
            var existingApp = _appsService.GetAppById(id);

            if (existingApp == null)
            {
                return NotFound();
            }

            _appsService.DeleteApp(id);
            return Ok();
        }

        [HttpGet("search/{name}")]
        public IActionResult SearchApps(string name)
        {
            var apps = _appsService.SearchApps(name);

            if (apps.Count == 0)
            {
                return NotFound();
            }

            return Ok(apps);
        }

        [HttpGet("os/{osId}")]
        public IActionResult GetAppsByOsId(Guid osId)
        {
            var apps = _appsService.GetAppsByOsId(osId);

            if (apps.Count == 0)
            {
                return NotFound();
            }

            return Ok(apps);
        }
    }
}