using Microsoft.AspNetCore.Mvc;
using DigitalProcess.Models;
using DigitalProcess.Services;

namespace DigitalProcess.Controllers
{
    [ApiController]
    [Route("api/process")]
    public class ProcessApiController : ControllerBase
    {
        private readonly ProcessService _service;

        public ProcessApiController(ProcessService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll(int page = 1)
        {
            const int pageSize = 15;
            var all = _service.GetAll();
            var paginated = all
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var result = new
            {
                Page = page,
                TotalItems = all.Count,
                TotalPages = (int)Math.Ceiling(all.Count / (double)pageSize),
                Items = paginated
            };

            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var res = _service.GetById(id);
            if (res == null)
                return NotFound();

            return Ok(res);
        }

        [HttpPost]
        public IActionResult Create(Process process)
        {
            _service.Add(process);
            return Ok(process);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Process updatedProcess)
        {
            var process = _service.GetById(id);
            if (process == null)
                return NotFound();

            process.TypeId = updatedProcess.TypeId;
            process.OriginOrganizationId = updatedProcess.OriginOrganizationId;
            process.OriginSectorId = updatedProcess.OriginSectorId;
            process.CurrentOrganizationId = updatedProcess.CurrentOrganizationId;
            process.CurrentSectorId	= updatedProcess.CurrentSectorId;

            _service.Update(process);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var res = _service.GetById(id);
            if (res == null)
                return NotFound();

            _service.Delete(res);
            return Ok();
        }
    }
}
