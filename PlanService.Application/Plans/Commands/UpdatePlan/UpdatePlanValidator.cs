using FluentValidation;

namespace PlanService.Application.Plans.Commands.UpdatePlan;

public class UpdatePlanValidator : AbstractValidator<UpdatePlanCommand>
{
    public UpdatePlanValidator()
    {
        RuleFor(x => x.Name).NotEmpty().Length(3, 100);
        RuleFor(x => x.Description).NotEmpty().MaximumLength(500);
        RuleFor(x => x.ContributionAmount).GreaterThan(0).WithMessage("ContributionAmount must be greater than 0");
        RuleFor(x => x.CoverageAmount).GreaterThan(0).WithMessage("CoverageAmount must be greater than 0");
        RuleFor(x => x.MinEntryAge).InclusiveBetween(18, 100);
        RuleFor(x => x.MaxEntryAge).InclusiveBetween(18, 100);
        
        // Max Age must be >= Min Age

        RuleFor(x => x)
            .Must(x => x.MaxEntryAge >= x.MinEntryAge)
            .WithMessage("MaxEntryAge must be greater than MinEntryAge");
        
        // Coverage must be greater than contribution
        
        RuleFor(x => x)
            .Must(x => x.CoverageAmount > x.ContributionAmount)
            .WithMessage("CoverageAmount must be greater than CoverageAmount");
    }
}