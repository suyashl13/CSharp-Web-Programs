using Microsoft.AspNetCore.Mvc;

public class Person
{
    public Guid? PersonId { get; set; }
    public string? Name { get; set; }

    public int Age { get; set; }

    public string? Email { get; set; }
}