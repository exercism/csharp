using Xunit;
using Exercism.Tests;

public class TimFromMarketingTests
{
    [Fact]
    [Task(1)]
    public void Label_for_employee()
    {
        Assert.Equal("[17] - Ryder Herbert - MARKETING", Badge.Print(17, "Ryder Herbert", "Marketing"));
    }

    [Fact]
    [Task(2)]
    public void Label_for_new_employee()
    {
        Assert.Equal("Bogdan Rosario - MARKETING", Badge.Print(null, "Bogdan Rosario", "Marketing"));
    }

    [Fact]
    [Task(3)]
    public void Label_for_owner()
    {
        Assert.Equal("[59] - Julie Sokato - OWNER", Badge.Print(59, "Julie Sokato", null));
    }

    [Fact]
    [Task(3)]
    public void Label_for_new_owner()
    {
        Assert.Equal("Amare Osei - OWNER", Badge.Print(null, "Amare Osei", null));
    }
}
