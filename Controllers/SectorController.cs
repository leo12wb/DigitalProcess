using Microsoft.AspNetCore.Mvc;
public class SectorController : Controller
{
    public IActionResult Index()
    {
        return View(); // isso renderiza Views/Sector/Index.cshtml
    }

    public IActionResult Create()
    {
        return View(); // isso renderiza Views/Sector/Create.cshtml (form)
    }
}
