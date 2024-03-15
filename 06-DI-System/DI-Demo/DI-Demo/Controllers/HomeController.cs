using Microsoft.AspNetCore.Mvc;

namespace DI_Demo.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return Json(new {a="sss"});
    }
}
