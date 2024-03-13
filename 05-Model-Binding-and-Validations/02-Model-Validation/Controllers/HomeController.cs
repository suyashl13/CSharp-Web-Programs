using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    [HttpPost]
    [Route("/person")]
    public IActionResult RegisterPerson([Bind([
        nameof(Person.Name), nameof(Person.Email),
     nameof(Person.Password), nameof(Person.Phone),
     nameof(Person.PersonId)])] Person person)
    {
        person.PersonId = Guid.NewGuid();

        if (!ModelState.IsValid)
        {
            Response.StatusCode = 401;
            return Json(
                ModelState.Values.SelectMany(
                    values => values.Errors.Select(val => val.ErrorMessage)
                )
            );
        }

        return Json(person);
    }
}