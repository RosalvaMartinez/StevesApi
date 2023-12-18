using Microsoft.AspNetCore.Mvc;

// Define a controller class named HomeController
public class HomeController : Controller
{
    // Define an action method named Index
    public IActionResult Index()
    {
        // Return a view result for the "Index" action
        return View();
    }

}