using System;
using System.Collections.Generic;

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
    private readonly int month;
    private readonly int year;
    private readonly Dictionary<Schedule, Scheduler> schedulers;

    public Meetup(int month, int year)
    {
        this.month = month;
        this.year = year;
        schedulers = new Dictionary<Schedule, Scheduler>
        {
            { Schedule.Teenth, new TeenthScheduler() },
            { Schedule.First, new WeekNumberScheduler(1) },
            { Schedule.Second, new WeekNumberScheduler(2) },
            { Schedule.Third, new WeekNumberScheduler(3) },
            { Schedule.Fourth, new WeekNumberScheduler(4) },
            { Schedule.Last, new LastScheduler() }
        };
    }

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        return schedulers[schedule].Day(year, month, dayOfWeek);
    }

    private abstract class Scheduler
    {
        public abstract DateTime Day(int year, int month, DayOfWeek dayOfWeek);

        protected static DateTime FindFirstDayOfWeek(DayOfWeek dayOfWeek, DateTime startingDate, int step)
        {
            var date = startingDate;
            while (date.DayOfWeek != dayOfWeek)
                date = date.AddDays(step);
            return date;
        }
    }

    private class TeenthScheduler : Scheduler
    {
        public override DateTime Day(int year, int month, DayOfWeek dayOfWeek)
        {
            return FindFirstDayOfWeek(dayOfWeek, new DateTime(year, month, 13), 1);
        }
    }

    private class WeekNumberScheduler : Scheduler
    {
        private readonly int nthWeek;

        public WeekNumberScheduler(int nthWeek)
        {
            this.nthWeek = nthWeek - 1;
        }

        public override DateTime Day(int year, int month, DayOfWeek dayOfWeek)
        {
            var date = FindFirstDayOfWeek(dayOfWeek, new DateTime(year, month, 1), 1);
            return date.AddDays(nthWeek * 7);
        }
    }

    private class LastScheduler : Scheduler
    {
        public override DateTime Day(int year, int month, DayOfWeek dayOfWeek)
        {
            var startingDate = new DateTime(year, month, DateTime.DaysInMonth(year, month));
            return FindFirstDayOfWeek(dayOfWeek, startingDate, -1);
        }
    }
}