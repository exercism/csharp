using System;

public enum Schedule
{
    Teenth,
    First,
    Second,
    Third,
    Fourth,
    Last
}

public class Meetup
{
    public Meetup(int month, int year)
    {
    }

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}