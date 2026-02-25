using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PlanService.Domain.Entities;
using PlanService.Domain.Repositories;

namespace PlanService.Application.Plans.Commands;

public class CreatePlanCommandHandler(ILogger<CreatePlanCommandHandler> logger,
    IMapper mapper, IPlanRepository planRepository) : IRequestHandler<CreatePlanCommand, int>
{
    public async Task<int> Handle(CreatePlanCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating a new plan");
        var plan = mapper.Map<Plan>(request);
        int id = await planRepository.CreatePlan(plan);
        return id;
    }
}