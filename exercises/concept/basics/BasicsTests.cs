using Xunit;

public class LasagnaTests
{
    [Fact]
    public void Expected_minutes_in_oven()
    {
        Assert.Equal(40, new Lasagna().ExpectedMinutesInOven());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Remaining_minutes_in_oven()
    {
        Assert.Equal(15, new Lasagna().RemainingMinutesInOven(25));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Preparation_time_in_minutes_for_one_layer()
    {
        Assert.Equal(2, new Lasagna().PreparationTimeInMinutes(1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Preparation_time_in_minutes_for_multiple_layers()
    {
        Assert.Equal(8, new Lasagna().PreparationTimeInMinutes(4));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Elapsed_time_in_minutes_for_one_layer()
    {
        Assert.Equal(32, new Lasagna().ElapsedTimeInMinutes(1, 30));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Elapsed_time_in_minutes_for_multiple_layers()
    {
        Assert.Equal(16, new Lasagna().ElapsedTimeInMinutes(4, 8));
    }
}
