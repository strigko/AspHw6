using AspHw6;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSingleton<RequestLoggingService>();
builder.Services.AddScoped<ShoppingCartService>();

var app = builder.Build();

app.Use(async (context, next) =>
{
    var request = $"{context.Request.Method} {context.Request.Path}";

    Console.WriteLine($"Request: {request}");

    await next();

    var requestInfo = $"{request} | Status: {context.Response.StatusCode}";

    var loggingService = context.RequestServices
        .GetRequiredService<RequestLoggingService>();

    loggingService.AddRequest(requestInfo);
});

app.MapControllers();

app.Run();