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

    public async Task<Plan?> GetByIdAsync(int id)
    {
        var plan = await dbContext.Plans.FirstOrDefaultAsync(p => p.Id == id);
        return plan;
    }

    public async Task<int> CreatePlan(Plan entity)
    {
        dbContext.Plans.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task DeletePlan(Plan entity)
    {
        dbContext.Plans.Remove(entity);
        await dbContext.SaveChangesAsync();
    }
}