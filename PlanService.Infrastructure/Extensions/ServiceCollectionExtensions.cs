using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlanService.Domain.Repositories;
using PlanService.Infrastructure.Seeders;
using PlanService.Infrastructure.Persistence;
using PlanService.Infrastructure.Repositories;

namespace PlanService.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<PlanDbContext>(options => options.UseSqlServer(connectionString));
        
        services.AddScoped<IPlanSeeder, PlanSeeder>();
        services.AddScoped<IPlanRepository, PlanRepository>();
    }
}