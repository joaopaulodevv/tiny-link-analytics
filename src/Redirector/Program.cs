var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();




app.MapGet("/tiny-link/{short_code}", async (string short_code) =>
{
    var client = new HttpClient();

    


    var response = await client.GetAsync("");


    return Results.NoContent();
});





app.Run();
