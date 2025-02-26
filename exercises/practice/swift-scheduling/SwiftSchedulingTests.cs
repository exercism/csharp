public class SwiftSchedulingTests
{
    [Fact]
    public void NowTranslatesToTwoHoursLater()
    {
        var meetingStart = new DateTime(2012, 2, 13, 9, 0, 0);
        var expected = new DateTime(2012, 2, 13, 11, 0, 0);
        Assert.Equal(expected, SwiftScheduling.DeliveryDate(meetingStart, "NOW"), TimeSpan.FromSeconds(1));
    }
 
    [Fact]
    public void AsapBeforeNoonTranslatesToTodayAtFiveInTheAfternoon()
    {
        var meetingStart = new DateTime(1999, 6, 3, 9, 45, 0);
        var expected = new DateTime(1999, 6, 3, 17, 0, 0);
        Assert.Equal(expected, SwiftScheduling.DeliveryDate(meetingStart, "ASAP"), TimeSpan.FromSeconds(1));
    }
 
    [Fact]
    public void AsapAfterNoonTranslatesToTomorrowAtNoon()
    {
        var meetingStart = new DateTime(2008, 12, 21, 13, 30, 0);
        var expected = new DateTime(2008, 12, 22, 12, 0, 0);
        Assert.Equal(expected, SwiftScheduling.DeliveryDate(meetingStart, "ASAP"), TimeSpan.FromSeconds(1));
    }
 
    [Fact]
    public void EowOnMondayTranslatesToFridayAtFiveInTheAfternoon()
    {
        var meetingStart = new DateTime(2025, 2, 3);
        var expected = new DateTime(2025, 2, 7, 17, 0, 0);
        Assert.Equal(expected, SwiftScheduling.DeliveryDate(meetingStart, "EOW"), TimeSpan.FromSeconds(1));
    }
 
    [Fact]
    public void EowOnTuesdayTranslatesToFridayAtFiveInTheAfternoon()
    {
        var meetingStart = new DateTime(1997, 4, 29);
        var expected = new DateTime(1997, 5, 2, 17, 0, 0);
        Assert.Equal(expected, SwiftScheduling.DeliveryDate(meetingStart, "EOW"), TimeSpan.FromSeconds(1));
    }
 
    [Fact]
    public void EowOnWednesdayTranslatesToFridayAtFiveInTheAfternoon()
    {
        var meetingStart = new DateTime(2005, 9, 14);
        var expected = new DateTime(2005, 9, 16, 17, 0, 0);
        Assert.Equal(expected, SwiftScheduling.DeliveryDate(meetingStart, "EOW"), TimeSpan.FromSeconds(1));
    }
 
    [Fact]
    public void EowOnThursdayTranslatesToSundayAtEightInTheEvening()
    {
        var meetingStart = new DateTime(2011, 5, 19);
        var expected = new DateTime(2011, 5, 22, 20, 0, 0);
        Assert.Equal(expected, SwiftScheduling.DeliveryDate(meetingStart, "EOW"), TimeSpan.FromSeconds(1));
    }
 
    [Fact]
    public void EowOnFridayTranslatesToSundayAtEightInTheEvening()
    {
        var meetingStart = new DateTime(2022, 8, 5);
        var expected = new DateTime(2022, 8, 7, 20, 0, 0);
        Assert.Equal(expected, SwiftScheduling.DeliveryDate(meetingStart, "EOW"), TimeSpan.FromSeconds(1));
    }

    [Fact]
    public void TwoMTranslatesToTheFirstWorkdayOfTheSecondMonth()
    {
        var meetingStart = new DateTime(2007, 1, 2);
        var expected = new DateTime(2007, 2, 1, 8, 0, 0);
        Assert.Equal(expected, SwiftScheduling.DeliveryDate(meetingStart, "2M"), TimeSpan.FromSeconds(1));
    }

    [Fact]
    public void FiveMTranslatesToTheFirstWorkdayOfTheFifthMonth()
    {
        var meetingStart = new DateTime(2013, 2, 11);
        var expected = new DateTime(2013, 5, 1, 8, 0, 0);
        Assert.Equal(expected, SwiftScheduling.DeliveryDate(meetingStart, "5M"), TimeSpan.FromSeconds(1));
    }

    [Fact]
    public void Q1TranslatesToTheLastWorkdayOfTheFirstQuarter()
    {
        var meetingStart = new DateTime(2011, 2, 23);
        var expected = new DateTime(2011, 3, 31, 8, 0, 0);
        Assert.Equal(expected, SwiftScheduling.DeliveryDate(meetingStart, "Q1"), TimeSpan.FromSeconds(1));
    }

    [Fact]
    public void Q4TranslatesToTheLastWorkdayOfTheFourthQuarter()
    {
        var meetingStart = new DateTime(2023, 4, 19);
        var expected = new DateTime(2023, 12, 29, 8, 0, 0);
        Assert.Equal(expected, SwiftScheduling.DeliveryDate(meetingStart, "Q4"), TimeSpan.FromSeconds(1));
    }
}
