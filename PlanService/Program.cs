
using PlanService.Application.Extensions;
using PlanService.Infrastructure.Extensions;
using PlanService.Infrastructure.Seeders;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;


var builder = WebApplication.CreateBuilder(args);


builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(8080); // Container port
    
    // Local development ports (optional)
    options.ListenLocalhost(5260);   // HTTP

});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers(); // Important
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

// Serilog Part
builder.Host.UseSerilog((context, configuration) => configuration
    .WriteTo.Console(theme: AnsiConsoleTheme.Code,
        outputTemplate: "[{Timestamp: dd:MM:yyyy HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
    .ReadFrom.Configuration(context.Configuration));


var app = builder.Build();


var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IPlanSeeder>();
await seeder.Seed();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers(); // Important
app.Run();
