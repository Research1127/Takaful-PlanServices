using MediatR;
using PlanService.Application.Plans.Dtos;


namespace PlanService.Application.Plans.Queries.GetByIdQuery;

public class GetByIdQuery(int id) : IRequest<PlanDto?>
{
    public int Id { get; set; } = id;
}