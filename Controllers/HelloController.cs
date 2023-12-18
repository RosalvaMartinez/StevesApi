using System.Data;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api")]
public class HelloController : ControllerBase
{
    public DatabaseHandler db = new DatabaseHandler("127.0.0.1", "stevesdoors", "hazel", "whiskey");
    
    [HttpGet("product")]
    public async Task<IActionResult> GetProductAsync()
    {
        var dt = await db.ExecuteQueryAsync("SELECT * FROM Product");

        //var dt =  Task<DataTable>.Run( ()=> { db.ExecuteQueryAsync("SELECT * FROM Product") });
        //Console.WriteLine(dt);
         foreach (DataRow row in dt.Rows)
        {
            Console.WriteLine($"ProductID: {row["ProductID"]}, ProductName: {row["ProductName"]}");
        }
        var response = new { Products = dt };
        return Ok(response);
    }

    // [HttpPost("product")]
    // public async Task<IActionResult> AddProductAsync()
    // {
    //     var affectedRows = await db.ExecuteNonQueryAsync("INSERT INTO Product ");
    //     var response = new { Employees = dt };
    //     return Ok(response);
    // }
    
    [HttpGet("customer")]
    public async Task<IActionResult> GetCustomerAsync()
    {
        var dt = await db.ExecuteQueryAsync("SELECT * FROM Customer");
        var response = new { Customers = dt };
        return Ok(response);
    }

    [HttpGet("order")]
    public async Task<IActionResult> GetOrderAsync()
    {
        var dt = await db.ExecuteQueryAsync("SELECT * FROM `Order`");
        var response = new { Orders = dt };
        return Ok(response);
    }

    [HttpGet("supplier")]
    public async Task<IActionResult> GetSupplierAsync()
    {
        var dt = await db.ExecuteQueryAsync("SELECT * FROM Supplier");
        var response = new { Suppliers = dt };
        return Ok(response);
    }

    [HttpGet("invoice")]
    public async Task<IActionResult> GetInvoiceAsync()
    {
        var dt = await db.ExecuteQueryAsync("SELECT * FROM Invoice");
        var response = new { Invoices = dt };
        return Ok(response);
    }

    [HttpGet("qualitycontrol")]
    public async Task<IActionResult> GetQualityControlAsync()
    {
        var dt = await db.ExecuteQueryAsync("SELECT * FROM QualityControl");
        var response = new { Qualitycontrol= dt };
        return Ok(response);
    }

    [HttpGet("shipping")]
    public async Task<IActionResult> GetShippingAsync()
    {
        var dt = await db.ExecuteQueryAsync("SELECT * FROM Shipping");
        var response = new { Shipping = dt };
        return Ok(response);
    }

    [HttpGet("employee")]
    public async Task<IActionResult> GetEmployeeAsync()
    {
        var dt = await db.ExecuteQueryAsync("SELECT * FROM Employee");
        var response = new { Employees = dt };
        return Ok(response);
    }
}

