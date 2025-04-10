using Microsoft.AspNetCore.Mvc;
using DigitalProcess.Models;
using DigitalProcess.Services;

namespace DigitalProcess.Controllers.Api
{
    [ApiController]
    [Route("api/organization")]
    // [Route("api/[controller]")]
    public class OrganizationApiController : ControllerBase
    {
        private readonly OrganizationService _service;

        public OrganizationApiController(OrganizationService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpPost]
        public IActionResult Create(Organization org)
        {
            _service.Add(org);
            return Ok();
        }
    }
}
