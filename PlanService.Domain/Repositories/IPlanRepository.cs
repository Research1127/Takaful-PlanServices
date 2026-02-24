using PlanService.Domain.Entities;

namespace PlanService.Domain.Repositories;

public interface IPlanRepository
{
    Task<IEnumerable<Plan>> GetAllAsync();
}