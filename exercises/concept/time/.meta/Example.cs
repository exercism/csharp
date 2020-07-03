using System;
using System.Globalization;
using System.Runtime.InteropServices;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc)
    {
        return dtUtc.ToLocalTime();
    }

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        TimeZoneInfo tziLocation = TimeZoneInfo.FindSystemTimeZoneById(GetTimeZoneId(location));
        DateTime dtl = DateTime.Parse(appointmentDateDescription);
        DateTime dtu = TimeZoneInfo.ConvertTimeToUtc(dtl, tziLocation);
        return dtu;
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        TimeSpan noticePeriod = new TimeSpan();

        switch (alertLevel)
        {
            case AlertLevel.Early:
                noticePeriod = new TimeSpan(1, 0, 0, 0);
                break;
            case AlertLevel.Standard:
                noticePeriod = new TimeSpan(1, 45, 0);
                break;
            case AlertLevel.Late:
                noticePeriod = new TimeSpan(0, 30, 0);
                break;
        }

        return appointment - noticePeriod;
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        DateTime dtPrevious = dt.AddDays(-7);
        string tzid = string.Empty;
        TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById(GetTimeZoneId(location));
        return tzi.IsDaylightSavingTime(dtPrevious) != tzi.IsDaylightSavingTime(dt);
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        try
        {
            return DateTime.Parse(dtStr, LocationToCulture(location));
        }
        catch (Exception)
        {
            return DateTime.MinValue;
        }
    }

    private static CultureInfo LocationToCulture(Location location)
    {
        string cultureId = string.Empty;
        switch (location)
        {
            case Location.NewYork:
                cultureId = "en-US";
                break;
            case Location.London:
                cultureId = "en-GB";
                break;
            case Location.Paris:
                cultureId = "fr-FR";
                break;
        }
        return new CultureInfo(cultureId);
    }

    private static string GetTimeZoneId(Location location)
    {
        if (IsWindows())
        {
            return GetTimeZoneIdForWindows(location);
        }
        else
        {
            return GetTimeZoneIdForPosix(location);
        }
    }

    private static string GetTimeZoneIdForWindows(Location location)
    {
        string timeZoneId = string.Empty;
        switch (location)
        {
            case Location.NewYork:
                timeZoneId = "Eastern Standard Time";
                break;
            case Location.London:
                timeZoneId = "GMT Standard Time";
                break;
            case Location.Paris:
                timeZoneId = "W. Europe Standard Time";
                break;
        }
        return timeZoneId;
    }

    private static string GetTimeZoneIdForPosix(Location location)
    {
        string timeZoneId = string.Empty;
        switch (location)
        {
            case Location.NewYork:
                timeZoneId = "America/New_York";
                break;
            case Location.London:
                timeZoneId = "Europe/London";
                break;
            case Location.Paris:
                timeZoneId = "Europe/Paris";
                break;
        }
        return timeZoneId;
    }

    private static bool IsWindows()
    {
        return RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
    }
}
