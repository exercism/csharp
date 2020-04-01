using Xunit;

public class LasagnaTests
{
    [Fact]
    public void ExpectedMinutesInOven() =>
        Assert.Equal(40, new Lasagna().ExpectedMinutesInOven());

    [Fact(Skip = "Remove to run test")]
    public void RemainingMinutesInOven() =>
        Assert.Equal(15, new Lasagna().RemainingMinutesInOven(25));

    [Fact(Skip = "Remove to run test")]
    public void PreparationTimeInMinutesForOneLayer() =>
        Assert.Equal(2, new Lasagna().PreparationTimeInMinutes(1));

    [Fact(Skip = "Remove to run test")]
    public void PreparationTimeInMinutesForMultipleLayers() =>
        Assert.Equal(8, new Lasagna().PreparationTimeInMinutes(4));

    [Fact(Skip = "Remove to run test")]
    public void TotalTimeInMinutesForOneLayer() =>
        Assert.Equal(32, new Lasagna().TotalTimeInMinutes(1, 30));

    [Fact(Skip = "Remove to run test")]
    public void TotalTimeInMinutesForMultipleLayers() =>
        Assert.Equal(16, new Lasagna().TotalTimeInMinutes(4, 8));
}