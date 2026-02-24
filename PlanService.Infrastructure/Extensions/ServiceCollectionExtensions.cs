using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlanService.Infrastructure.Seeders;
using PlanService.Infrastructure.Persistence;

namespace PlanService.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<PlanDbContext>(options => options.UseSqlServer(connectionString));
        
        services.AddScoped<IPlanSeeder, PlanSeeder>();
    }
}