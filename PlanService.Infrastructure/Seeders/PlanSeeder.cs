using Microsoft.EntityFrameworkCore;
using PlanService.Domain.Entities;
using PlanService.Infrastructure.Persistence;


namespace PlanService.Infrastructure.Seeders;

public class PlanSeeder(PlanDbContext dbcontext) : IPlanSeeder
{
    public async Task Seed()
    {
        Console.WriteLine("🔥 PlanSeeder is running");

        var count = await dbcontext.Plans.CountAsync();
        Console.WriteLine($"Current plan count: {count}");

        if (count == 0)
        {
            var plans = GetPlans();
            dbcontext.Plans.AddRange(plans);
            await dbcontext.SaveChangesAsync();
            Console.WriteLine("✅ Plans inserted!");
        }
        else
        {
            Console.WriteLine("⚠️ Plans already exist");
        }
    }

    private IEnumerable<Plan> GetPlans()
    {
        var now = DateTime.UtcNow;
        List<Plan> plans =
        [
            // 🏥 Medical Plans
        new Plan
        {
            Name = "Medical Shield Basic",
            Description = "Basic hospital and surgical coverage.",
            ContributionAmount = 150,
            CoverageAmount = 150000,
            MinEntryAge = 0,
            MaxEntryAge = 65,
            WaitingPeriodDays = 30,
            IsActive = true,
            CreatedAt = now
        },
        new Plan
        {
            Name = "Medical Shield Premium",
            Description = "Comprehensive medical coverage with high annual limit.",
            ContributionAmount = 350,
            CoverageAmount = 1000000,
            MinEntryAge = 0,
            MaxEntryAge = 70,
            WaitingPeriodDays = 60,
            IsActive = true,
            CreatedAt = now
        },

        // 👨‍👩‍👧 Family Protection
        new Plan
        {
            Name = "Family Protection Basic",
            Description = "Affordable protection for breadwinner.",
            ContributionAmount = 120,
            CoverageAmount = 100000,
            MinEntryAge = 18,
            MaxEntryAge = 60,
            WaitingPeriodDays = 30,
            IsActive = true,
            CreatedAt = now
        },
        new Plan
        {
            Name = "Family Protection Plus",
            Description = "Extended family coverage with higher sum assured.",
            ContributionAmount = 220,
            CoverageAmount = 300000,
            MinEntryAge = 18,
            MaxEntryAge = 65,
            WaitingPeriodDays = 30,
            IsActive = true,
            CreatedAt = now
        },

        // 🎓 Education Plan
        new Plan
        {
            Name = "Smart Education Saver",
            Description = "Savings plan for child’s future education.",
            ContributionAmount = 200,
            CoverageAmount = 200000,
            MinEntryAge = 0,
            MaxEntryAge = 15,
            WaitingPeriodDays = 90,
            IsActive = true,
            CreatedAt = now
        },

        // ❤️ Critical Illness
        new Plan
        {
            Name = "Critical Care Protection",
            Description = "Covers 36 critical illnesses.",
            ContributionAmount = 180,
            CoverageAmount = 250000,
            MinEntryAge = 18,
            MaxEntryAge = 60,
            WaitingPeriodDays = 60,
            IsActive = true,
            CreatedAt = now
        },

        // 👴 Senior Plan
        new Plan
        {
            Name = "Golden Age Senior Plan",
            Description = "Medical coverage designed for senior citizens.",
            ContributionAmount = 300,
            CoverageAmount = 150000,
            MinEntryAge = 50,
            MaxEntryAge = 80,
            WaitingPeriodDays = 30,
            IsActive = true,
            CreatedAt = now
        },

        // 🕋 Hajj / Umrah Savings
        new Plan
        {
            Name = "Hajj & Umrah Saver",
            Description = "Savings and protection plan for pilgrimage.",
            ContributionAmount = 100,
            CoverageAmount = 50000,
            MinEntryAge = 18,
            MaxEntryAge = 65,
            WaitingPeriodDays = 30,
            IsActive = true,
            CreatedAt = now
        }
        ];

        return plans;
    }
}