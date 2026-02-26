using PlanService.Domain.Entities;

namespace PlanService.Domain.Repositories;

public interface IPlanRepository
{
    Task<IEnumerable<Plan>> GetAllAsync();
    Task<Plan?> GetByIdAsync(int id);

    Task<int> CreatePlan(Plan entity);

    Task DeletePlan(Plan entity);

}