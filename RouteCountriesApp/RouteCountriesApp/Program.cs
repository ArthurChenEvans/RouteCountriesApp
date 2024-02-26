var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();



app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/countries", () => "1. USA \n2. Canada \n3. UK \n4. India \n5. Japan");
    endpoints.MapGet("/countries/{CountryID:int}", 
});
app.Run();
