using Microsoft.AspNetCore.Mvc;
using DigitalProcess.Models;
using DigitalProcess.Services;

namespace DigitalProcess.Controllers
{
    [ApiController]
    [Route("api/sector")]
    public class SectorApiController : ControllerBase
    {
        private readonly SectorService _service;

        public SectorApiController(SectorService service)
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
        public IActionResult Create(Sector sector)
        {
            _service.Add(sector);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Sector updatedSector)
        {
            var sector = _service.GetById(id);
            if (sector == null)
                return NotFound();

            sector.Name = updatedSector.Name;
            _service.Update(sector);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var sector = _service.GetById(id);
            if (sector == null)
                return NotFound();

            _service.Delete(sector);
            return Ok();
        }
    }
}
