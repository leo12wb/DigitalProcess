using Microsoft.AspNetCore.Mvc;
using DigitalProcess.Models;
using DigitalProcess.Services;

namespace DigitalProcess.Controllers
{
    [ApiController]
    [Route("api/document")]
    public class DocumentApiController : ControllerBase
    {
        private readonly DocumentService _service;

        public DocumentApiController(DocumentService service)
        {
            _service = service;
        }

        [HttpGet("{processId}")]
        public IActionResult GetByProcess(int processId) =>
            Ok(_service.GetByProcess(processId));

        [HttpPost]
        public IActionResult Create(Document document)
        {
            _service.Add(document);
            return Ok();
        }
    }
}
