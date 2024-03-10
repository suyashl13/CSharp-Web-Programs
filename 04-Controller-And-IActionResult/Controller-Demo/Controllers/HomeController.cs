using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

public class HomeController : Controller
{
    [Route("")]
    public ContentResult GetHomeContent()
    {
        return new ContentResult()
        {
            ContentType="text/html",
            Content = "<h1>Hello from Suyash...</h1>"
        };
    }

    [Route("/api")]
    public JsonResult GetApi() {
        Person person = new Person() {
            Id = Guid.NewGuid(),
            Email = "suyash.lawand@gmail.com",
            FullName = "Suyash Lawand"
        };
        // return new JsonResult(person); equal to
        return Json(person);
    }

    [Route("/download")]
    public VirtualFileResult FileDownload() {
        return new VirtualFileResult("/wwwroot/Sample.txt", "text/plain");
    }

}