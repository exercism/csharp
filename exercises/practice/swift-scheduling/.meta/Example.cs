public static class SwiftScheduling
{
    public static DateTime DeliveryDate(DateTime meetingStart, string description) =>
        description switch
        {
            "NOW" => meetingStart.AddHours(2),
            "ASAP" when meetingStart.Hour <= 12 => meetingStart.AtHour(17),
            "ASAP" => meetingStart.AddDays(1).AtHour(13),
            "EOW" => meetingStart.DayOfWeek switch
            {
                DayOfWeek.Thursday or DayOfWeek.Friday => meetingStart.AddDays(7 - (int)meetingStart.DayOfWeek).AtHour(20),
                _ => meetingStart.AddDays(DayOfWeek.Friday - meetingStart.DayOfWeek).AtHour(17),
            }, 
            _  when description.EndsWith('M') => int.Parse(description[..^1]) switch
            {
                var month when month > meetingStart.Month => meetingStart.NthMonth(month).FirstWorkDay().AtHour(8),
                var month => meetingStart.AddYears(1).NthMonth(month).FirstWorkDay().AtHour(8)   
            },
            _  when description.StartsWith('Q') => int.Parse(description[1..]) switch 
            {
                var quarter when quarter * 3 > meetingStart.Month => meetingStart.NthQuarter(quarter).LastWorkDay().AtHour(8),
                var quarter => meetingStart.AddYears(1).NthQuarter(quarter).LastWorkDay().AtHour(8)
            },
            _ => throw new ArgumentException("Invalid date"),
        };
    
    private static DateTime NthMonth(this DateTime date, int n) => new(date.Year, n, 1);
    
    private static DateTime NthQuarter(this DateTime date, int n) => new(date.Year, n * 3, 1);
    
    private static IEnumerable<DateTime> WorkDays(this DateTime date) =>
        Enumerable.Range(1, DateTime.DaysInMonth(date.Year, date.Month))
            .Select(day => new DateTime(date.Year, date.Month, day))
            .Where(d => d.DayOfWeek is not DayOfWeek.Saturday and not DayOfWeek.Sunday);
    
    private static DateTime FirstWorkDay(this DateTime date) => date.WorkDays().First();
    
    private static DateTime LastWorkDay(this DateTime date) => date.WorkDays().Last();
    
    private static DateTime AtHour(this DateTime date, int hour) => date.Date.AddHours(hour);
}
