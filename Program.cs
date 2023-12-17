using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddControllers().AddNewtonsoftJson();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

// app.MapGet("/api/hello", () => 
// {
//     return "Hello World!";
// });


app.Run();
