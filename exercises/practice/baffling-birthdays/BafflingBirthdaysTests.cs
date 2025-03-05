public class BafflingBirthdaysTests
{
    [Fact]
    public void MatchingBirthdayForSameDate()
    {
        var birthday1 = new DateOnly(2000, 1, 1);
        var birthday2 = new DateOnly(2000, 1, 1);
        Assert.True(BafflingBirthdays.MatchingBirthday(birthday1, birthday2));
    }
    
    [Fact]
    public void MatchingBirthdayForSameMonthAndDayButDifferentYear()
    {
        var birthday1 = new DateOnly(1999, 10, 23);
        var birthday2 = new DateOnly(1988, 10, 23);
        Assert.True(BafflingBirthdays.MatchingBirthday(birthday1, birthday2));
    }
    
    [Fact]
    public void MatchingBirthdayForSameYearAndMonthButDifferentDay()
    {
        var birthday1 = new DateOnly(2012, 5, 9);
        var birthday2 = new DateOnly(2012, 5, 17);
        Assert.False(BafflingBirthdays.MatchingBirthday(birthday1, birthday2));
    }
    
    [Fact]
    public void MatchingBirthdayForSameYearButDifferentMonthAndDay()
    {
        var birthday1 = new DateOnly(2007, 12, 19);
        var birthday2 = new DateOnly(2007, 4, 27);
        Assert.False(BafflingBirthdays.MatchingBirthday(birthday1, birthday2));
    }

    [Fact]
    public void MatchingBirthdayForDifferentYearMonthAndDay()
    {
        var birthday1 = new DateOnly(1997, 8, 4);
        var birthday2 = new DateOnly(1963, 11, 23);
        Assert.False(BafflingBirthdays.MatchingBirthday(birthday1, birthday2));
    }

    [Fact]
    public void RandomBirthdaysReturnSpecifiedNumberOfBirthdays()
    {
        for (var count = 1; count < 10; count++)
        {
            Assert.Equal(count, BafflingBirthdays.RandomBirthdates(count).Length);
        }
    }

    [Fact]
    public void RandomBirthdaysHaveFixedYearPerBatch()
    {
        var years = BafflingBirthdays.RandomBirthdates(100)
            .Select(birthdate => birthdate.Year)
            .ToHashSet();
        Assert.Single(years);
    }

    [Fact]
    public void RandomBirthdaysHaveRandomYearBetweenBatches()
    {
        var years = Enumerable.Range(0, 100)
            .Select(_ => BafflingBirthdays.RandomBirthdates(100).Select(birthdate => birthdate.Year))
            .ToHashSet();
        Assert.InRange(years.Count, 20, 100);
    }

    [Fact]
    public void RandomBirthdaysHaveRandomMonths()
    {
        var months = BafflingBirthdays.RandomBirthdates(100).Select(birthdate => birthdate.Month).ToHashSet();
        Assert.Equal(12, months.Count);
    }

    [Fact]
    public void RandomBirthdaysHaveRandomDays()
    {
        var days = BafflingBirthdays.RandomBirthdates(250).Select(birthdate => birthdate.Day).ToHashSet();
        Assert.Equal(31, days.Count);
    }
    
    [Fact]
    public void HasMatchingBirthdaysWithMatchingBirthdayPair()
    {
        DateOnly[] birthdates = [new(1970, 1, 19), new(1975, 6, 3), new(2003, 1, 19)];
        Assert.True(BafflingBirthdays.HasMatchingBirthdays(birthdates));
    }
    
    [Fact]
    public void HasMatchingBirthdaysWithoutMatchingBirthdayPair()
    {
        DateOnly[] birthdates = [new(1984, 4, 5), new(2000, 9, 17), new(1966, 10, 12)];
        Assert.False(BafflingBirthdays.HasMatchingBirthdays(birthdates));
    }
    
    [Fact]
    public void LikelihoodHasMatchingBirthdayForOnePerson()
    {
        Assert.Equal(0.0, BafflingBirthdays.LikelihoodHasMatchingBirthday(1));
    }
    
    [Fact]
    public void LikelihoodHasMatchingBirthdayFor10People()
    {
        Assert.Equal(11.7, BafflingBirthdays.LikelihoodHasMatchingBirthday(10), 1.0);
    }
    
    [Fact]
    public void LikelihoodHasMatchingBirthdayFor23People()
    {
        Assert.Equal(50.7, BafflingBirthdays.LikelihoodHasMatchingBirthday(23), tolerance: 1.0);
    }

    [Fact]
    public void LikelihoodHasMatchingBirthdayFor70People()
    {
        Assert.Equal(99.9, BafflingBirthdays.LikelihoodHasMatchingBirthday(70), tolerance: 1.0);
    }
}
