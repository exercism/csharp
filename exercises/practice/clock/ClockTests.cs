public class ClockTests
{
    [Fact]
    public void On_the_hour()
    {
        Assert.Equal("08:00", new Clock(8, 0).ToString());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Past_the_hour()
    {
        Assert.Equal("11:09", new Clock(11, 9).ToString());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Midnight_is_zero_hours()
    {
        Assert.Equal("00:00", new Clock(24, 0).ToString());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Hour_rolls_over()
    {
        Assert.Equal("01:00", new Clock(25, 0).ToString());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Hour_rolls_over_continuously()
    {
        Assert.Equal("04:00", new Clock(100, 0).ToString());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Sixty_minutes_is_next_hour()
    {
        Assert.Equal("02:00", new Clock(1, 60).ToString());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Minutes_roll_over()
    {
        Assert.Equal("02:40", new Clock(0, 160).ToString());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Minutes_roll_over_continuously()
    {
        Assert.Equal("04:43", new Clock(0, 1723).ToString());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Hour_and_minutes_roll_over()
    {
        Assert.Equal("03:40", new Clock(25, 160).ToString());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Hour_and_minutes_roll_over_continuously()
    {
        Assert.Equal("11:01", new Clock(201, 3001).ToString());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Hour_and_minutes_roll_over_to_exactly_midnight()
    {
        Assert.Equal("00:00", new Clock(72, 8640).ToString());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Negative_hour()
    {
        Assert.Equal("23:15", new Clock(-1, 15).ToString());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Negative_hour_rolls_over()
    {
        Assert.Equal("23:00", new Clock(-25, 0).ToString());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Negative_hour_rolls_over_continuously()
    {
        Assert.Equal("05:00", new Clock(-91, 0).ToString());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Negative_minutes()
    {
        Assert.Equal("00:20", new Clock(1, -40).ToString());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Negative_minutes_roll_over()
    {
        Assert.Equal("22:20", new Clock(1, -160).ToString());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Negative_minutes_roll_over_continuously()
    {
        Assert.Equal("16:40", new Clock(1, -4820).ToString());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Negative_sixty_minutes_is_previous_hour()
    {
        Assert.Equal("01:00", new Clock(2, -60).ToString());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Negative_hour_and_minutes_both_roll_over()
    {
        Assert.Equal("20:20", new Clock(-25, -160).ToString());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Negative_hour_and_minutes_both_roll_over_continuously()
    {
        Assert.Equal("22:10", new Clock(-121, -5810).ToString());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Add_minutes()
    {
        Assert.Equal("10:03", new Clock(10, 0).Add(3).ToString());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Add_no_minutes()
    {
        Assert.Equal("06:41", new Clock(6, 41).Add(0).ToString());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Add_to_next_hour()
    {
        Assert.Equal("01:25", new Clock(0, 45).Add(40).ToString());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Add_more_than_one_hour()
    {
        Assert.Equal("11:01", new Clock(10, 0).Add(61).ToString());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Add_more_than_two_hours_with_carry()
    {
        Assert.Equal("03:25", new Clock(0, 45).Add(160).ToString());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Add_across_midnight()
    {
        Assert.Equal("00:01", new Clock(23, 59).Add(2).ToString());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Add_more_than_one_day_1500_min_25_hrs()
    {
        Assert.Equal("06:32", new Clock(5, 32).Add(1500).ToString());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Add_more_than_two_days()
    {
        Assert.Equal("11:21", new Clock(1, 1).Add(3500).ToString());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Subtract_minutes()
    {
        Assert.Equal("10:00", new Clock(10, 3).Subtract(3).ToString());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Subtract_to_previous_hour()
    {
        Assert.Equal("09:33", new Clock(10, 3).Subtract(30).ToString());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Subtract_more_than_an_hour()
    {
        Assert.Equal("08:53", new Clock(10, 3).Subtract(70).ToString());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Subtract_across_midnight()
    {
        Assert.Equal("23:59", new Clock(0, 3).Subtract(4).ToString());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Subtract_more_than_two_hours()
    {
        Assert.Equal("21:20", new Clock(0, 0).Subtract(160).ToString());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Subtract_more_than_two_hours_with_borrow()
    {
        Assert.Equal("03:35", new Clock(6, 15).Subtract(160).ToString());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Subtract_more_than_one_day_1500_min_25_hrs()
    {
        Assert.Equal("04:32", new Clock(5, 32).Subtract(1500).ToString());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Subtract_more_than_two_days()
    {
        Assert.Equal("00:20", new Clock(2, 20).Subtract(3000).ToString());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Clocks_with_same_time()
    {
        Assert.Equal(new Clock(15, 37), new Clock(15, 37));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Clocks_a_minute_apart()
    {
        Assert.NotEqual(new Clock(15, 36), new Clock(15, 37));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Clocks_an_hour_apart()
    {
        Assert.NotEqual(new Clock(14, 37), new Clock(15, 37));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Clocks_with_hour_overflow()
    {
        Assert.Equal(new Clock(10, 37), new Clock(34, 37));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Clocks_with_hour_overflow_by_several_days()
    {
        Assert.Equal(new Clock(3, 11), new Clock(99, 11));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Clocks_with_negative_hour()
    {
        Assert.Equal(new Clock(22, 40), new Clock(-2, 40));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Clocks_with_negative_hour_that_wraps()
    {
        Assert.Equal(new Clock(17, 3), new Clock(-31, 3));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Clocks_with_negative_hour_that_wraps_multiple_times()
    {
        Assert.Equal(new Clock(13, 49), new Clock(-83, 49));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Clocks_with_minute_overflow()
    {
        Assert.Equal(new Clock(0, 1), new Clock(0, 1441));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Clocks_with_minute_overflow_by_several_days()
    {
        Assert.Equal(new Clock(2, 2), new Clock(2, 4322));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Clocks_with_negative_minute()
    {
        Assert.Equal(new Clock(2, 40), new Clock(3, -20));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Clocks_with_negative_minute_that_wraps()
    {
        Assert.Equal(new Clock(4, 10), new Clock(5, -1490));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Clocks_with_negative_minute_that_wraps_multiple_times()
    {
        Assert.Equal(new Clock(6, 15), new Clock(6, -4305));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Clocks_with_negative_hours_and_minutes()
    {
        Assert.Equal(new Clock(7, 32), new Clock(-12, -268));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Clocks_with_negative_hours_and_minutes_that_wrap()
    {
        Assert.Equal(new Clock(18, 7), new Clock(-54, -11513));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Full_clock_and_zeroed_clock()
    {
        Assert.Equal(new Clock(24, 0), new Clock(0, 0));
    }
}
