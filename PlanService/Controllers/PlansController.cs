using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlanService.Application.Plans.Queries.GetAllQuery;
using PlanService.Application.Plans.Queries.GetByIdQuery;

namespace PlanService.Controllers;

[ApiController]
[Route("api/plans")]
public class PlansController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllPlan()
    {
        var plans = await mediator.Send(new GetAllQuery());
        return Ok(plans);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPlan(int id)
    {
        var plan = await mediator.Send(new GetByIdQuery(id));
        if (plan == null)
        {
            return NotFound();
        }
        return Ok(plan);
    }
}
