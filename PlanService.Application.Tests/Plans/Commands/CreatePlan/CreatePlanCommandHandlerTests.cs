using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using Moq;
using PlanService.Application.Plans.Commands;
using PlanService.Domain.Entities;
using PlanService.Domain.Repositories;
using Xunit;

namespace PlanService.Application.Tests.Plans.Commands.CreatePlan;

[TestSubject(typeof(CreatePlanCommandHandler))]
public class CreatePlanCommandHandlerTests
{

    [Fact]
    public async Task Handle_ForValidCommand_ReturnsCorrectId()
    {
        // Arrange ------------------------------
        
        // ILogger part
        var loggerMock = new Mock<ILogger<CreatePlanCommandHandler>>();
        
        // IMapper part
        var command = new CreatePlanCommand();
        var plan = new Plan();
        var mapperMock = new Mock<IMapper>();
        mapperMock.Setup(m => m.Map<Plan>(command)).Returns(plan);
        
        // Repository part
        var repositoryMock = new Mock<IPlanRepository>();
        repositoryMock.Setup(repo => repo.CreatePlan(It.IsAny<Plan>())).ReturnsAsync(1);


        
        var commandHandler = new CreatePlanCommandHandler(loggerMock.Object, mapperMock.Object, repositoryMock.Object);

        // act ------------------------------

        var result = await commandHandler.Handle(command, CancellationToken.None);

        // assertion ------------------------------
        result.Should().Be(1);
    }
}