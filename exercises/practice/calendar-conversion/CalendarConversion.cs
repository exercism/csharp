using System.Globalization;

public static class CalendarConversion
{
    

    public static string ToGregorianDate(DateOnly date) => date.ToString("R");

    public static string ToHijriDate(DateOnly date) => date.ToString(HijriCulture);
    private static readonly CultureInfo HijriCulture = new("ar-SA") { DateTimeFormat = { Calendar = new HijriCalendar() } };
}
