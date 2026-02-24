using AutoMapper;
using PlanService.Domain.Entities;

namespace PlanService.Application.Plans.Dtos;

public class PlansProfile : Profile
{
    public PlansProfile()
    {
        CreateMap<Plan, PlanDto>();
    }
}