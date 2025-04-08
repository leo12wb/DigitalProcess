using Microsoft.AspNetCore.Mvc;
using DigitalProcess.Models;
using DigitalProcess.Services;

namespace DigitalProcess.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProcessTypeController : ControllerBase
    {
        private readonly ProcessTypeService _service;

        public ProcessTypeController(ProcessTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpPost]
        public IActionResult Create(ProcessType type)
        {
            _service.Add(type);
            return Ok();
        }
    }
}
