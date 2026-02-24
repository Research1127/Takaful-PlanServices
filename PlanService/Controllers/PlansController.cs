using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlanService.Application.Plans.Queries.GetAllQuery;

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
}