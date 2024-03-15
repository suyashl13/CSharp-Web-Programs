using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    [HttpPost]
    [Route("/person")]
    public IActionResult RegisterPerson([ModelBinder(BinderType = typeof(CustomPersonBinder))] Person person)
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