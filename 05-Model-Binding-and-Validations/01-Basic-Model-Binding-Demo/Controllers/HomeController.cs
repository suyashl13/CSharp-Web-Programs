using Microsoft.AspNetCore.Mvc;

public class HomeController: Controller {
    public IActionResult GetHome() {
        return Content("<h1>This is home route</h1>");
    }

    [HttpGet]
    [Route("/person")]
    public IActionResult GetPerson([FromQuery] bool isLoggedIn) {
        if (isLoggedIn)
        {
            return Json(Program.people.ToArray());
        } else {
            return Unauthorized("Not Logged in");
        }
    }

    [HttpGet]
    [Route("/person/{id}")]
    public IActionResult GetPersonWithId([FromRoute] int id) {
        return Content($"Person: {id}");
    }

    [HttpGet]
    [Route("/person/create")]
    public IActionResult CreatePersonByQueryParams(Person person) {
        if (person.Name == null)
        {
            return BadRequest("Please provide Person Name");
        } else if (person.Email == null) {
            return BadRequest("Please provide email");
        } else if (person.Age == default(int))
        {
            return BadRequest("Please provide age");
        }

        person.PersonId = Guid.NewGuid();
        Program.people.Add(person);

        return Json(person);
    }

    [HttpPost]
    [Route("/person")]
    public IActionResult CreatePerson(Person person) {
        person.PersonId = Guid.NewGuid();
        Program.people.Add(person);
        return Json(person);
    }
}