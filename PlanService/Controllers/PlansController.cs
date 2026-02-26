using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlanService.Application.Plans.Commands;
using PlanService.Application.Plans.Commands.DeletePlan;
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
    public async Task<IActionResult> GetPlanById( [FromRoute]int id)
    {
        var plan = await mediator.Send(new GetByIdQuery(id));
        if (plan == null)
        {
            return NotFound();
        }
        return Ok(plan);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreatePlan(CreatePlanCommand command)
    {
        int id = await mediator.Send(command);
        return CreatedAtAction(nameof(GetPlanById), new {id}, null);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePlan( [FromRoute]int id)
    {
        await mediator.Send(new DeletePlanCommand(id));
        return NotFound();
    }
}
