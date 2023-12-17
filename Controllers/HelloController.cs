using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api")]
public class HelloController : ControllerBase
{
    [HttpGet("hello")]
    public IActionResult GetHello()
    {
        var response = new { Message = "Hello, World!" };
        return Ok(response);
    }
    
    [HttpGet("goodbye")]
    public IActionResult GetGoodbye()
    {
        var goodbye = new { Message = "Gewdbye!" };
        return Ok(goodbye);
    }
}

