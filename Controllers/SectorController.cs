using Microsoft.AspNetCore.Mvc;
using DigitalProcess.Models;
using DigitalProcess.Services;

namespace DigitalProcess.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SectorController : ControllerBase
    {
        private readonly SectorService _service;

        public SectorController(SectorService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpPost]
        public IActionResult Create(Sector sector)
        {
            _service.Add(sector);
            return Ok();
        }
    }
}
