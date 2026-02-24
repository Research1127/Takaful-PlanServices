using Microsoft.EntityFrameworkCore;
using PlanService.Domain.Entities;

namespace PlanService.Infrastructure.Persistence;

public class PlanDbContext : DbContext
{
    public PlanDbContext(DbContextOptions<PlanDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Plan> Plans { get; set; }
}