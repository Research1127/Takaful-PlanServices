using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PlanService.Application.Plans.Dtos;
using PlanService.Domain.Repositories;

namespace PlanService.Application.Plans.Queries.GetAllQuery;

public class GetAllQueryHandler(ILogger<GetAllQueryHandler> logger,
    IMapper mapper,
    IPlanRepository planRepository) : IRequestHandler<GetAllQuery, IEnumerable<PlanDto>>
{
    public async Task<IEnumerable<PlanDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting All Plans");
        var plans = await planRepository.GetAllAsync();
        var planDtos = mapper.Map<IEnumerable<PlanDto>>(plans);
        return planDtos;

    }
}