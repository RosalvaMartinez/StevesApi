using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api")]
public class HelloController : ControllerBase
{
    public DatabaseHandler db = new DatabaseHandler("127.0.0.1", "stevesdoors", "hazel", "whiskey");
    [HttpGet("hello")]
    public IActionResult GetHello()
    {
        Task<List<string>>  doortypes = db.ExecuteQueryAsync("SELECT Description FROM Product");
        var response = new { Doors = doortypes };
        return Ok(response);
    }
    
    [HttpGet("goodbye")]
    public IActionResult GetGoodbye()
    {
        var goodbye = new { Message = "Gewdbye!" };
        return Ok(goodbye);
    }
}

