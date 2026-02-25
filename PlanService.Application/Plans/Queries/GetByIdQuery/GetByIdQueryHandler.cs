using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PlanService.Application.Plans.Dtos;
using PlanService.Domain.Repositories;

namespace PlanService.Application.Plans.Queries.GetByIdQuery;

public class GetByIdQueryHandler(ILogger<GetByIdQueryHandler> logger,
    IMapper mapper, IPlanRepository planRepository) : IRequestHandler<GetByIdQuery,PlanDto?>
{
    public async Task<PlanDto?> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Get Plan ID {request.Id}");
        var plan = await planRepository.GetByIdAsync(request.Id);
        var planDto = mapper.Map<PlanDto>(plan);
        return planDto;
        
    }
}