using Microsoft.AspNetCore.Mvc;
using DigitalProcess.Models;
using DigitalProcess.Services;
public class OrganizationsController : Controller
{
    private readonly OrganizationService _service;

    public OrganizationsController(OrganizationService service)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        // var organizations = _service.GetAll();
        return View(); // isso renderiza Views/Organizations/Index.cshtml
    }

    public IActionResult Create()
    {
        return View(); // isso renderiza Views/Organizations/Create.cshtml (form)
    }

    [HttpPost]
    public IActionResult Create(Organization org)
    {
        _service.Add(org);
        return RedirectToAction("Index");
    }
}
