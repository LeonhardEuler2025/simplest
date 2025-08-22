using Microsoft.AspNetCore.Mvc;

public class InputFoo
{
    public string? Name { get; set; }
    public int Value { get; set; }
}

public class OutputFoo
{
    public string Result { get; set; }
    public bool Success { get; set; }
}

[ApiController]
[Route("[controller]")]
public class FooController : ControllerBase
{
    [HttpPost]
    public ActionResult<OutputFoo> Post(InputFoo input)
    {
        if (string.IsNullOrEmpty(input.Name))
        {
            return BadRequest(new OutputFoo
            {
                Result = "Name cannot be null or empty.",
                Success = false
            });
        }

        var output = new OutputFoo
        {
            Result = $"Received {input.Name} with value {input.Value}",
            Success = true
        };
        return Ok(output);
    }
}