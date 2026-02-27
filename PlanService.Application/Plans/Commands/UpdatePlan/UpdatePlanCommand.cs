using MediatR;

namespace PlanService.Application.Plans.Commands.UpdatePlan;

public class UpdatePlanCommand : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal ContributionAmount { get; set; }
    public decimal CoverageAmount { get; set; }
    public int MinEntryAge { get; set; }
    public int MaxEntryAge { get; set; }
}