using Microsoft.AspNetCore.Mvc;
using DigitalProcess.Models;
using DigitalProcess.Services;

namespace DigitalProcess.Controllers
{
    [ApiController]
    [Route("api/processMovement")]
    public class ProcessMovementApiController : ControllerBase
    {
        private readonly ProcessMovementService _service;

        public ProcessMovementApiController(ProcessMovementService service)
        {
            _service = service;
        }

        [HttpGet("{processId}")]
        public IActionResult GetByProcess(int processId) =>
            Ok(_service.GetByProcess(processId));

        [HttpPost]
        public IActionResult Create(ProcessMovement movement)
        {
            _service.Add(movement);
            return Ok();
        }
    }
}
