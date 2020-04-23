using Xunit;

public class NullabilityTests
{
    [Fact]
    public void LabelForEmployee()
    {
        Assert.Equal("[17] Ryder Herbert - MARKETING", Badge.Print(17, "Ryder Herbert", "Marketing"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void LabelForNewEmployee()
    {
        Assert.Equal("Bogdan Rosario - MARKETING", Badge.Print(null, "Bogdan Rosario", "Marketing"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void LabelForOwner()
    {
        Assert.Equal("[59] Julie Sokato - OWNER", Badge.Print(59, "Julie Sokato", null));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void LabelForNewOwner()
    {
        Assert.Equal("Amare Osei - OWNER", Badge.Print(null, "Amare Osei", null));
    }
}
