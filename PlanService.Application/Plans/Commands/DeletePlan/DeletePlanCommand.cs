using MediatR;

namespace PlanService.Application.Plans.Commands.DeletePlan;

public class DeletePlanCommand(int id) : IRequest
{
    public int Id { get; set; } = id;
}