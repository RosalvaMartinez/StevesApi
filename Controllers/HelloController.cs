using System.Data;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api")]
public class HelloController : ControllerBase
{
    public DatabaseHandler db = new DatabaseHandler("127.0.0.1", "stevesdoors", "hazel", "whiskey");
    [HttpGet("hello")]
    public async Task<IActionResult> GetHelloAsync()
    {
        var dt = await db.ExecuteQueryAsync("SELECT * FROM Product");

        //var dt =  Task<DataTable>.Run( ()=> { db.ExecuteQueryAsync("SELECT * FROM Product") });
        //Console.WriteLine(dt);
         foreach (DataRow row in dt.Rows)
        {
            Console.WriteLine($"ProductID: {row["ProductID"]}, ProductName: {row["ProductName"]}");
        }
        var response = new { Doors = dt };
        return Ok(response);
    }
    
    [HttpGet("goodbye")]
    public IActionResult GetGoodbye()
    {
        var goodbye = new { Message = "Goodbye!" };
        return Ok(goodbye);
    }
}

