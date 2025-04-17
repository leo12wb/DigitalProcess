using Microsoft.AspNetCore.Mvc;
using DigitalProcess.Models;
using DigitalProcess.Services;

namespace DigitalProcess.Controllers
{
    [ApiController]
    [Route("api/processType")]
    public class ProcessTypeApiController : ControllerBase
    {
        private readonly ProcessTypeService _service;

        public ProcessTypeApiController(ProcessTypeService service)
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
