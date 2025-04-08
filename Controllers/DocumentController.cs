using Microsoft.AspNetCore.Mvc;
using DigitalProcess.Models;
using DigitalProcess.Services;

namespace DigitalProcess.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentController : ControllerBase
    {
        private readonly DocumentService _service;

        public DocumentController(DocumentService service)
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
