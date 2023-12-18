using System.Data;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api")]
public class StevesApiController : ControllerBase
{
    // Credentials passed into DatabaseHandler object to access db
    public DatabaseHandler db = new DatabaseHandler("127.0.0.1", "stevesdoors", "hazel", "whiskey");
    

    // HttpGet endpoint handler runs query that returns data from Product table
    [HttpGet("product")]

    // action method is asynchronous (Task) and will produce an IActionResult upon completion
    public async Task<IActionResult> GetProductAsync()
    {
        // Use our DatabaseHAndler to execute a SELECT query
        var dt = await db.ExecuteQueryAsync("SELECT * FROM Product");
        // Create a response object with the results of the query (DataTable serialized with NewtonSoft)
        // Newtonsoft package is used to facilitate the conversion between .NET objects and JSON (JavaScript Object Notation) data.
        var response = new { Products = dt };
        // Send response with query results back to frontend 
        return Ok(response);
    }

    // Endpoint Function runs query that adds data to Product table

    [HttpPost("product")]

    // handles asynchronous operation: fetches data, then returns an appropriate result 
    public async Task<IActionResult> AddProductAsync(Product product) //Use the Product class to extract data values in the request to use on line 36
    {
        // Inserts new row into Products table
        // Use the values of the product value argument and interpolate the values in the query string
        var affectedRows = await db.ExecuteNonQueryAsync($"INSERT INTO Product (ProductName, Description, Material, Size, Color, Price, StockQuantity) VALUES('{product.Productname}', '{product.Description}', '{product.Material}', '{product.Size}', '{product.Color}', {product.Price}, {product.StockQuantity})");
        return Ok(affectedRows);

    }
    
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

