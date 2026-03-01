using FluentValidation.TestHelper;
using JetBrains.Annotations;
using PlanService.Application.Plans.Commands;
using Xunit;

namespace PlanService.Application.Tests.Plans.Commands.CreatePlan;

public class CreatePlanValidatorTests
{

    [Fact]
    public void Validator_ForValidCommand_ShouldNotHaveValidationError()
    {
        // arrange
        var command = new CreatePlanCommand()
        {
            Name = "TestPlan",
            Description = "TestPlan using Xunit",
            ContributionAmount = 100,
            CoverageAmount = 150,
            MinEntryAge = 20,
            MaxEntryAge = 30,
        };
        
        var validator = new CreatePlanValidator();
        
        // act

        var result = validator.TestValidate(command);
        
        // assert
        
        result.ShouldNotHaveAnyValidationErrors();
        
        
    }
    
    [Fact]
    public void Validator_ForInValidCommand_ShouldHaveValidationError()
    {
        // arrange
        var command = new CreatePlanCommand()
        {
            Name = "Te",
            Description = "TestPlan using Xunit",
            ContributionAmount = -1,
            CoverageAmount = -4,
            MinEntryAge = 10,
            MaxEntryAge = 5,
        };
        
        var validator = new CreatePlanValidator();
        
        // act

        var result = validator.TestValidate(command);
        
        // assert

        result.ShouldHaveValidationErrorFor(x => x.Name);
        result.ShouldHaveValidationErrorFor(x => x.ContributionAmount);
        result.ShouldHaveValidationErrorFor(x => x.CoverageAmount);
        result.ShouldHaveValidationErrorFor(x => x.MinEntryAge);
        result.ShouldHaveValidationErrorFor(x => x.MaxEntryAge);
        
        
        
    }
    
    
    // To Test Many Data At The Same Time
    [Theory]
    [InlineData("A")]
    [InlineData("AB")]
    [InlineData("AC")]
    
    public void Validator_ForInvalidName_ShouldHaveValidationError(string name)
    {
        // arrange
        var command = new CreatePlanCommand()
        {
            Name = name,
            Description = "TestPlan using Xunit",
            ContributionAmount = 100,
            CoverageAmount = 150,
            MinEntryAge = 20,
            MaxEntryAge = 30,

        };
        
        var validator = new CreatePlanValidator();
        
        // act
        var result = validator.TestValidate(command);
        
        // assert
        
        result.ShouldHaveValidationErrorFor(x => x.Name);
    }
}