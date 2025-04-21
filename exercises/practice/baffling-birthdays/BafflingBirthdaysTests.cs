public class BafflingBirthdaysTests
{
    [Fact]
    public void Shared_birthday_one_birthdate()
    {
        DateOnly[] birthdates = [
            new(2000, 1, 1)
        ];
        Assert.False(BafflingBirthdays.SharedBirthday(birthdates));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Shared_birthday_two_birthdates_with_same_year_month_and_day()
    {
        DateOnly[] birthdates = [
            new(2000, 1, 1),
            new(2000, 1, 1)
        ];
        Assert.True(BafflingBirthdays.SharedBirthday(birthdates));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Shared_birthday_two_birthdates_with_same_year_and_month_but_different_day()
    {
        DateOnly[] birthdates = [
            new(2012, 5, 9),
            new(2012, 5, 17)
        ];
        Assert.False(BafflingBirthdays.SharedBirthday(birthdates));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Shared_birthday_two_birthdates_with_same_month_and_day_but_different_year()
    {
        DateOnly[] birthdates = [
            new(1999, 10, 23),
            new(1988, 10, 23)
        ];
        Assert.True(BafflingBirthdays.SharedBirthday(birthdates));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Shared_birthday_two_birthdates_with_same_year_but_different_month_and_day()
    {
        DateOnly[] birthdates = [
            new(2007, 12, 19),
            new(2007, 4, 27)
        ];
        Assert.False(BafflingBirthdays.SharedBirthday(birthdates));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Shared_birthday_two_birthdates_with_different_year_month_and_day()
    {
        DateOnly[] birthdates = [
            new(1997, 8, 4),
            new(1963, 11, 23)
        ];
        Assert.False(BafflingBirthdays.SharedBirthday(birthdates));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Shared_birthday_multiple_birthdates_without_shared_birthday()
    {
        DateOnly[] birthdates = [
            new(1966, 7, 29),
            new(1977, 2, 12),
            new(2001, 12, 25),
            new(1980, 11, 10)
        ];
        Assert.False(BafflingBirthdays.SharedBirthday(birthdates));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Shared_birthday_multiple_birthdates_with_one_shared_birthday()
    {
        DateOnly[] birthdates = [
            new(1966, 7, 29),
            new(1977, 2, 12),
            new(2001, 7, 29),
            new(1980, 11, 10)
        ];
        Assert.True(BafflingBirthdays.SharedBirthday(birthdates));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Shared_birthday_multiple_birthdates_with_more_than_one_shared_birthday()
    {
        DateOnly[] birthdates = [
            new(1966, 7, 29),
            new(1977, 2, 12),
            new(2001, 12, 25),
            new(1980, 7, 29),
            new(2019, 2, 12)
        ];
        Assert.True(BafflingBirthdays.SharedBirthday(birthdates));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Random_birthdates_generate_requested_number_of_birthdates()
    {
        for (var count = 1; count < 10; count++)
        {
            var randomBirthdates = BafflingBirthdays.RandomBirthdates(count);
            Assert.Equal(count, randomBirthdates.Length);
        }
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Random_birthdates_years_are_not_leap_years()
    {
        var uniqueRandomYears = BafflingBirthdays.RandomBirthdates(50)
            .Select(birthdate => birthdate.Year)
            .ToHashSet();
        Assert.All(uniqueRandomYears, year => Assert.False(DateTime.IsLeapYear(year)));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Random_birthdates_months_are_random()
    {
        var uniqueRandomMonths = BafflingBirthdays.RandomBirthdates(100)
            .Select(birthdate => birthdate.Month)
            .ToHashSet();
        Assert.Equal(12, uniqueRandomMonths.Count);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Random_birthdates_days_are_random()
    {
        var uniqueRandomDays = BafflingBirthdays.RandomBirthdates(300)
            .Select(birthdate => birthdate.Day)
            .ToHashSet();
        Assert.Equal(31, uniqueRandomDays.Count);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Estimated_probability_of_at_least_one_shared_birthday_for_one_person()
    {
        Assert.Equal(0.0, BafflingBirthdays.EstimatedProbabilityOfSharedBirthday(1), tolerance: 1.0);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Estimated_probability_of_at_least_one_shared_birthday_among_ten_people()
    {
        Assert.Equal(11.694818, BafflingBirthdays.EstimatedProbabilityOfSharedBirthday(10), tolerance: 1.0);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Estimated_probability_of_at_least_one_shared_birthday_among_twenty_three_people()
    {
        Assert.Equal(50.729723, BafflingBirthdays.EstimatedProbabilityOfSharedBirthday(23), tolerance: 1.0);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Estimated_probability_of_at_least_one_shared_birthday_among_seventy_people()
    {
        Assert.Equal(99.915958, BafflingBirthdays.EstimatedProbabilityOfSharedBirthday(70), tolerance: 1.0);
    }
}
