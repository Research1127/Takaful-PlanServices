using AutoMapper;
using PlanService.Application.Plans.Commands;
using PlanService.Domain.Entities;

namespace PlanService.Application.Plans.Dtos;

public class PlansProfile : Profile
{
    public PlansProfile()
    {
        CreateMap<Plan, PlanDto>();
        
        CreateMap<CreatePlanCommand, Plan>();
    }
}