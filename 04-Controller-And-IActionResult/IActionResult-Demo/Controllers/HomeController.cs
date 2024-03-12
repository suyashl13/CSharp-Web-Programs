using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    [Route("/file-download")]
    public IActionResult FileDownload()
    {
        
        if (!Request.Query.ContainsKey("isloggedin")) {
            return BadRequest("is loggedin not found");
        }

        if (!Convert.ToBoolean(Request.Query["isloggedin"]))
        {
            return Unauthorized("Is not authenticated");
        }

        if (!Request.Query.ContainsKey("bookid"))
        {
            return BadRequest("Book id not provided.");
        }

        if (String.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
        {
            return BadRequest("Book id cannot be null");
        }

        int bookid = Convert.ToInt32(Request.Query["bookid"]);
        if (bookid < 0 || bookid > 1000)
        {
            return NotFound("Book Not found");
        }
        return File("sample.pdf", "application/pdf");
    }


    [Route("/bookstore")]
    public IActionResult ValidateAndRedirectToBookRoute() {
        
        if (!Request.Query.ContainsKey("isloggedin"))
        {
            return Unauthorized("No login credentials found");
        }

        if (!Convert.ToBoolean(Request.Query["isloggedin"]))
        {
            return Unauthorized("Is not logged in");
        }


        // Using Local Redirection
        // return LocalRedirect($"/store/books");

        return new RedirectToActionResult("Book", "Store", new {bookName="Eat that frog"}, permanent: true);
    }

}