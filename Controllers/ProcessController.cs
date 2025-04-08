using Microsoft.AspNetCore.Mvc;
using DigitalProcess.Models;
using DigitalProcess.Services;

namespace DigitalProcess.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProcessController : ControllerBase
    {
        private readonly ProcessService _service;

        public ProcessController(ProcessService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpPost]
        public IActionResult Create(Process process)
        {
            _service.Add(process);
            return Ok(process);
        }
    }
}
