using Xunit;

public class BirdCountTests
{
    [Fact(Skip = "Remove this Skip property to run this test")]
    public void LastWeek()
    {
        Assert.Equal(new int[] { 0, 2, 5, 3, 7, 8, 4 }, BirdCount.LastWeek());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void YesterdayForDisappointingWeek()
    {
        var counts = new int[] { 0, 0, 1, 0, 0, 1, 0 };
        var birdCount = new BirdCount(counts);
        Assert.Equal(1, birdCount.Yesterday());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void YesterdayDaysForBusyWeek()
    {
        var counts = new int[] { 8, 8, 9, 5, 4, 7, 10 };
        var birdCount = new BirdCount(counts);
        Assert.Equal(7, birdCount.Yesterday());
    }

    [Fact]
    public void TotalForDisappointingWeek()
    {
        var counts = new int[] { 0, 0, 1, 0, 0, 1, 0 };
        var birdCount = new BirdCount(counts);
        Assert.Equal(2, birdCount.Total());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void TotalForBusyWeek()
    {
        var counts = new int[] { 5, 9, 12, 6, 8, 8, 17 };
        var birdCount = new BirdCount(counts);
        Assert.Equal(65, birdCount.Total());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void BusyDaysForDisappointingWeek()
    {
        var counts = new int[] { 1, 1, 1, 0, 0, 0, 0 };
        var birdCount = new BirdCount(counts);
        Assert.Equal(0, birdCount.BusyDays());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void BusyDaysForBusyWeek()
    {
        var counts = new int[] { 4, 9, 5, 7, 8, 8, 2 };
        var birdCount = new BirdCount(counts);
        Assert.Equal(5, birdCount.BusyDays());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void HasDayWithoutBirdsWithDayWithoutBirds()
    {
        var counts = new int[] { 5, 5, 4, 0, 7, 6, 7 };
        var birdCount = new BirdCount(counts);
        Assert.True(birdCount.HasDayWithoutBirds());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void HasDayWithoutBirdsWithNoDayWithoutBirds()
    {
        var counts = new int[] { 4, 5, 9, 10, 9, 4, 3 };
        var birdCount = new BirdCount(counts);
        Assert.False(birdCount.HasDayWithoutBirds());
    }
}
