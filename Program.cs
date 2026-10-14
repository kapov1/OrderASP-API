var builder = WebApplication.CreateBuilder(args);

#region Builder Configuration
    builder.Services
        .AddProblemDetails()
        .AddSingleton<OrderStorage>()
        .AddScoped<OrderService>()
        .AddSwaggerGen()
        .AddEndpointsApiExplorer()
        .AddControllers();    
#endregion

var app = builder.Build();

app.UseExceptionHandler();
app.UseStatusCodePages();

app.MapSwagger();
app.MapSwaggerUI();

app.MapControllers();

app.Run();