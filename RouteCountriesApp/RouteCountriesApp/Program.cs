var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/", () => "1. USA \n2. Canada \n3. UK \n4. India \n5. Japan");
    endpoints.MapGet("/countries", () => "1. USA \n2. Canada \n3. UK \n4. India \n5. Japan");
    endpoints.MapGet("/countries/{CountryID:int:range(1,100)}", async context =>
    {
        if (context.Request.RouteValues.TryGetValue("CountryID", out var countryIDValue) && int.TryParse(countryIDValue?.ToString(), out int countryID))
        {
            var filePath = Path.Combine(app.Environment.WebRootPath, $"{countryID}.html");

            if (File.Exists(filePath))
            {
                context.Response.ContentType = "text/html";
                await context.Response.SendFileAsync(filePath);
            }
            else
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync("Country not found");
            }
        }
        else
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("Country ID must be an integer");
        }
       
    });
});
app.Run();
