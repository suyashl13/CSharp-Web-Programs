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
        return new VirtualFileResult("/wwwroot/sample.pdf", "text/plain");
    }

    [Route("/download2")]
    public PhysicalFileResult DownloadFile() {
        return PhysicalFile(@"D:\Practice-Worspace\CSharp-Web-Programs\04-Controller-And-IActionResult\Controller-Demo\wwwroot\Sample.txt", "application/pdf");
    }

}