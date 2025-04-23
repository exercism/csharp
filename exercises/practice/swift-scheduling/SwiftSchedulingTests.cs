public class SwiftSchedulingTests
{
    [Fact]
    public void Now_translates_to_two_hours_later()
    {
        var meetingStart = new DateTime(2012, 2, 13, 9, 0, 0);
        var expected = new DateTime(2012, 2, 13, 11, 0, 0);
        Assert.Equal(expected, SwiftScheduling.DeliveryDate(meetingStart, "NOW"), TimeSpan.FromSeconds(1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Asap_before_one_in_the_afternoon_translates_to_today_at_five_in_the_afternoon()
    {
        var meetingStart = new DateTime(1999, 6, 3, 9, 45, 0);
        var expected = new DateTime(1999, 6, 3, 17, 0, 0);
        Assert.Equal(expected, SwiftScheduling.DeliveryDate(meetingStart, "ASAP"), TimeSpan.FromSeconds(1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Asap_at_one_in_the_afternoon_translates_to_tomorrow_at_one_in_the_afternoon()
    {
        var meetingStart = new DateTime(2008, 12, 21, 13, 0, 0);
        var expected = new DateTime(2008, 12, 22, 13, 0, 0);
        Assert.Equal(expected, SwiftScheduling.DeliveryDate(meetingStart, "ASAP"), TimeSpan.FromSeconds(1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Asap_after_one_in_the_afternoon_translates_to_tomorrow_at_one_in_the_afternoon()
    {
        var meetingStart = new DateTime(2008, 12, 21, 14, 50, 0);
        var expected = new DateTime(2008, 12, 22, 13, 0, 0);
        Assert.Equal(expected, SwiftScheduling.DeliveryDate(meetingStart, "ASAP"), TimeSpan.FromSeconds(1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Eow_on_monday_translates_to_friday_at_five_in_the_afternoon()
    {
        var meetingStart = new DateTime(2025, 2, 3, 16, 0, 0);
        var expected = new DateTime(2025, 2, 7, 17, 0, 0);
        Assert.Equal(expected, SwiftScheduling.DeliveryDate(meetingStart, "EOW"), TimeSpan.FromSeconds(1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Eow_on_tuesday_translates_to_friday_at_five_in_the_afternoon()
    {
        var meetingStart = new DateTime(1997, 4, 29, 10, 50, 0);
        var expected = new DateTime(1997, 5, 2, 17, 0, 0);
        Assert.Equal(expected, SwiftScheduling.DeliveryDate(meetingStart, "EOW"), TimeSpan.FromSeconds(1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Eow_on_wednesday_translates_to_friday_at_five_in_the_afternoon()
    {
        var meetingStart = new DateTime(2005, 9, 14, 11, 0, 0);
        var expected = new DateTime(2005, 9, 16, 17, 0, 0);
        Assert.Equal(expected, SwiftScheduling.DeliveryDate(meetingStart, "EOW"), TimeSpan.FromSeconds(1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Eow_on_thursday_translates_to_sunday_at_eight_in_the_evening()
    {
        var meetingStart = new DateTime(2011, 5, 19, 8, 30, 0);
        var expected = new DateTime(2011, 5, 22, 20, 0, 0);
        Assert.Equal(expected, SwiftScheduling.DeliveryDate(meetingStart, "EOW"), TimeSpan.FromSeconds(1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Eow_on_friday_translates_to_sunday_at_eight_in_the_evening()
    {
        var meetingStart = new DateTime(2022, 8, 5, 14, 0, 0);
        var expected = new DateTime(2022, 8, 7, 20, 0, 0);
        Assert.Equal(expected, SwiftScheduling.DeliveryDate(meetingStart, "EOW"), TimeSpan.FromSeconds(1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Eow_translates_to_leap_day()
    {
        var meetingStart = new DateTime(2008, 2, 25, 10, 30, 0);
        var expected = new DateTime(2008, 2, 29, 17, 0, 0);
        Assert.Equal(expected, SwiftScheduling.DeliveryDate(meetingStart, "EOW"), TimeSpan.FromSeconds(1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Two_m_before_the_second_month_of_this_year_translates_to_the_first_workday_of_the_second_month_of_this_year()
    {
        var meetingStart = new DateTime(2007, 1, 2, 14, 15, 0);
        var expected = new DateTime(2007, 2, 1, 8, 0, 0);
        Assert.Equal(expected, SwiftScheduling.DeliveryDate(meetingStart, "2M"), TimeSpan.FromSeconds(1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Eleven_m_in_the_eleventh_month_translates_to_the_first_workday_of_the_eleventh_month_of_next_year()
    {
        var meetingStart = new DateTime(2013, 11, 21, 15, 30, 0);
        var expected = new DateTime(2014, 11, 3, 8, 0, 0);
        Assert.Equal(expected, SwiftScheduling.DeliveryDate(meetingStart, "11M"), TimeSpan.FromSeconds(1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Four_m_in_the_ninth_month_translates_to_the_first_workday_of_the_fourth_month_of_next_year()
    {
        var meetingStart = new DateTime(2019, 11, 18, 15, 15, 0);
        var expected = new DateTime(2020, 4, 1, 8, 0, 0);
        Assert.Equal(expected, SwiftScheduling.DeliveryDate(meetingStart, "4M"), TimeSpan.FromSeconds(1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Q1_in_the_first_quarter_translates_to_the_last_workday_of_the_first_quarter_of_this_year()
    {
        var meetingStart = new DateTime(2003, 1, 1, 10, 45, 0);
        var expected = new DateTime(2003, 3, 31, 8, 0, 0);
        Assert.Equal(expected, SwiftScheduling.DeliveryDate(meetingStart, "Q1"), TimeSpan.FromSeconds(1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Q4_in_the_second_quarter_translates_to_the_last_workday_of_the_fourth_quarter_of_this_year()
    {
        var meetingStart = new DateTime(2001, 4, 9, 9, 0, 0);
        var expected = new DateTime(2001, 12, 31, 8, 0, 0);
        Assert.Equal(expected, SwiftScheduling.DeliveryDate(meetingStart, "Q4"), TimeSpan.FromSeconds(1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Q3_in_the_fourth_quarter_translates_to_the_last_workday_of_the_third_quarter_of_next_year()
    {
        var meetingStart = new DateTime(2022, 10, 6, 11, 0, 0);
        var expected = new DateTime(2023, 9, 29, 8, 0, 0);
        Assert.Equal(expected, SwiftScheduling.DeliveryDate(meetingStart, "Q3"), TimeSpan.FromSeconds(1));
    }
}
