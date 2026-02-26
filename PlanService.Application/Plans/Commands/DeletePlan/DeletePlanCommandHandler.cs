using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PlanService.Domain.Repositories;

namespace PlanService.Application.Plans.Commands.DeletePlan;

public class DeletePlanCommandHandler(ILogger<DeletePlanCommandHandler> logger,
    IPlanRepository planRepository): IRequestHandler<DeletePlanCommand>
{
    public async Task Handle(DeletePlanCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Deleting plan {request.Id}");
        var planToDelete = await planRepository.GetByIdAsync(request.Id);
        if (planToDelete == null)
        {
            throw new ApplicationException($"Plan with id {request.Id} not found");
        }
        await planRepository.DeletePlan(planToDelete);
    }
}