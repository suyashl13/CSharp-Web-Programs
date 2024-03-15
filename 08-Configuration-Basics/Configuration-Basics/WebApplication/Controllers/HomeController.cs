using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

[Route("/")]
public class HomeController : Controller
{

    private readonly IConfiguration _configuration;
    private readonly ConfigModel _options;

    public HomeController(IConfiguration configuration, IOptions<ConfigModel> options)
    {
        this._configuration = configuration;
        this._options = options.Value;
    }

    public IActionResult GetHome()
    {
        return Content(
            "<h1>Home</h1> " +
            $"<p>{_configuration.GetValue<string>("MyKey")}</p>", "text/html"
        );
    }

    [Route("/configvars")]
    public IActionResult GetConfigVars()
    {
        return Json(new
        {
            ClientId = _options.ClientId,
            ClientSecret = _options.ClientSecret,
            MyKey = _options.MyKey
        });
    }


}