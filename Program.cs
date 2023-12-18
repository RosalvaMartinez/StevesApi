using Newtonsoft.Json;

// Create a new web application builder using the provided command-line arguments
var builder = WebApplication.CreateBuilder(args);

// Add services required for Razor Pages
builder.Services.AddRazorPages();
// Add services required for both controllers and views
builder.Services.AddControllersWithViews();
// Add Newtonsoft.Json as the JSON serializer for controllers
builder.Services.AddControllers().AddNewtonsoftJson();

// Build the web application
var app = builder.Build();

// Enable HTTPS redirection
app.UseHttpsRedirection();
// Enable serving static files (e.g., CSS, images) from the wwwroot folder
app.UseStaticFiles();

// Enable authorization middleware
app.UseAuthorization();

// Configure the default controller route, specifying default values for controller, action, and optional id
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

// Start Application
app.Run();
