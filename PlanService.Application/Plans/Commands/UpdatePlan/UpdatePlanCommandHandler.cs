using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PlanService.Domain.Entities;
using PlanService.Domain.Repositories;

namespace PlanService.Application.Plans.Commands.UpdatePlan;

public class UpdatePlanCommandHandler(ILogger<UpdatePlanCommandHandler> logger,
    IMapper mapper, IPlanRepository planRepository) : IRequestHandler<UpdatePlanCommand>
{
    public async Task Handle(UpdatePlanCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Edit the plan data with Id {request.Id}");
        var plan = await planRepository.GetByIdAsync(request.Id);
        //plan.Name = request.Name;
        //plan.Description = request.Description;
        //plan.ContributionAmount = request.ContributionAmount;
        //plan.CoverageAmount = request.CoverageAmount;
        //plan.MinEntryAge = request.MinEntryAge;
        //plan.MaxEntryAge = request.MaxEntryAge; 
        // OR YOU CAN USE AUTOMAPPER (IF GOT SOME CONDITION THEN USE MANUAL MAPPER)
        mapper.Map(request, plan);

        await planRepository.SaveChanges();
    }
}