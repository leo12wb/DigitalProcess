using Microsoft.AspNetCore.Mvc;
public class ProcessController : Controller
{
    public IActionResult Index()
    {
        return View(); // isso renderiza Views/Process/Index.cshtml
    }

    public IActionResult Create()
    {
        return View(); // isso renderiza Views/Process/Create.cshtml (form)
    }
}
