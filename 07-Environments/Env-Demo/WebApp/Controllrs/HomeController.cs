using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{

    private readonly IWebHostEnvironment _webHostEnvironment;

    public HomeController(IWebHostEnvironment webHostEnvironment) {
        _webHostEnvironment = webHostEnvironment;
    }

    [Route("/")]
    public String GetHome() => "Hello";

    [Route("/person/{Name:alpha}")]
    public IActionResult GetPerson([FromRoute] String Name)
    {
        return new JsonResult(new { name = Name, Environment = _webHostEnvironment.EnvironmentName });
    }
}