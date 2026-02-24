using Microsoft.EntityFrameworkCore;
using PlanService.Application.Plans.Dtos;
using PlanService.Domain.Entities;
using PlanService.Domain.Repositories;
using PlanService.Infrastructure.Persistence;

namespace PlanService.Infrastructure.Repositories;

public class PlanRepository(PlanDbContext dbContext) : IPlanRepository
{
    public async Task<IEnumerable<Plan>> GetAllAsync()
    {
        var plans = await dbContext.Plans.ToListAsync();
        return plans;
    }
}