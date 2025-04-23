public static class BafflingBirthdays
{
    private static DateOnly RandomBirthdate(int year)
    {
        var month = Random.Shared.Next(1, 12 + 1);
        var day = Random.Shared.Next(1, DateTime.DaysInMonth(year, month) + 1);
        return new DateOnly(year, month, day);
    }

    public static DateOnly[] RandomBirthdates(int numberOfBirthdays)
    {
        var year = Random.Shared.Next(1900, DateTime.Now.Year);
        if (DateTime.IsLeapYear(year))
            year -= 1;

        return Enumerable.Range(0, numberOfBirthdays).Select(_ => RandomBirthdate(year)).ToArray();
    }

    public static bool SharedBirthday(DateOnly[] birthdays) =>
        birthdays
            .SelectMany((birthday, i) => birthdays.Skip(i + 1), MatchingBirthday)
            .Any(matching => matching);
    
    private static bool MatchingBirthday(DateOnly birthday1, DateOnly birthday2) =>
        birthday1.Month == birthday2.Month && birthday1.Day == birthday2.Day;

    public static double EstimatedProbabilityOfSharedBirthday(int numberOfBirthdays)
    {
        var matchingBirthdayIterationCount = 0;
        for (var i = 0; i < 10000; i++)
        {
            if (SharedBirthday(RandomBirthdates(numberOfBirthdays)))
                matchingBirthdayIterationCount++;
        }
        return matchingBirthdayIterationCount / 100.0;
    }
}
