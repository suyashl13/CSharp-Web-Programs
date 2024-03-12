using Microsoft.AspNetCore.Mvc;

public class StoreController : Controller
{
    [Route("/store/book/{BookName:alpha}")]
    public IActionResult Book()
    {
        String bookName = Convert.ToString(Request.RouteValues["bookName"]) ?? "Not Found";
        return Content($"<h1>Random Book: {bookName}</h1>", "text/html");
    }
}