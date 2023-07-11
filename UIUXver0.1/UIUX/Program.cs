using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.IO;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
var app = builder.Build();


app.UseStaticFiles();

app.MapGet("/", async (context) =>
{
    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "static.html");
    var content = await File.ReadAllTextAsync(filePath);
    await context.Response.WriteAsync(content);
});

app.UseHttpsRedirection();

app.UseRouting();


app.UseAuthorization();

app.MapRazorPages();

app.Run();
