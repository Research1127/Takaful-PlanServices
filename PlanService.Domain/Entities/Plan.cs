namespace PlanService.Domain.Entities;

public class Plan
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal ContributionAmount { get; set; }
    public decimal CoverageAmount { get; set; }
    public int MinEntryAge { get; set; }
    public int MaxEntryAge { get; set; }
    public int WaitingPeriodDays { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}