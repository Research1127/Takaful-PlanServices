using MediatR;
using PlanService.Application.Plans.Dtos;

namespace PlanService.Application.Plans.Queries.GetAllQuery;

public class GetAllQuery : IRequest<IEnumerable<PlanDto>>
{
    
}