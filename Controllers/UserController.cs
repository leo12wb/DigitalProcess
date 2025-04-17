using Microsoft.AspNetCore.Mvc;
public class UserController : Controller
{
    public IActionResult Index()
    {
        return View(); // isso renderiza Views/User/Index.cshtml
    }

    public IActionResult Create()
    {
        return View(); // isso renderiza Views/User/Create.cshtml (form)
    }
}
