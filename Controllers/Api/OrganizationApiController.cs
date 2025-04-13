using Microsoft.AspNetCore.Mvc;
using DigitalProcess.Models;
using DigitalProcess.Services;

namespace DigitalProcess.Controllers.Api
{
    [ApiController]
    [Route("api/organization")]
    public class OrganizationApiController : ControllerBase
    {
        private readonly OrganizationService _service;

        public OrganizationApiController(OrganizationService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll(int page = 1)
        {
            const int pageSize = 15;
            var allOrganizations = _service.GetAll();
            var paginated = allOrganizations
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var result = new
            {
                Page = page,
                TotalItems = allOrganizations.Count,
                TotalPages = (int)Math.Ceiling(allOrganizations.Count / (double)pageSize),
                Items = paginated
            };

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var org = _service.GetById(id);
            if (org == null)
                return NotFound();

            return Ok(org);
        }

        [HttpPost]
        public IActionResult Create(Organization org)
        {
            _service.Add(org);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Organization updatedOrg)
        {
            var org = _service.GetById(id);
            if (org == null)
                return NotFound();

            org.Name = updatedOrg.Name;
            _service.Update(org);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var org = _service.GetById(id);
            if (org == null)
                return NotFound();

            _service.Delete(org);
            return Ok();
        }
    }
}
