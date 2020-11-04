## General

- This [article][time-overview] is an overview of dates, times and time zones on .NET.
- The `DateTime` struct is documented [here][date-time].

## 1. Provide local time equivalents of UTC (Universal Coordinated Time) appointments for the administrators

Look for a suitable `DateTime` member converting from UTC to local time.

## 2. Schedule appointments in New York, London and Paris

Use the [`TimeZoneInfo`][time-zone-info] class and select the appropriate time zone ids from the task instructions. Remember that Windows and OSX/Linux have different ids.

The method [`RuntimeInformation.IsOSPlatform()`] is central to having code paths that target different operating systems.

## 3. Provide alerts to clients at intervals before the appointment

One approach is to use [`TimeSpan`][time-span] to perform arithmetic on times.

## 4. If daylight savings has recently changed we send a message to clients reminding them.

`TimeZoneInfo` has appropriate methods for this.

## 5. Use the local date time format to enter appointments

Have a look at `DateTime.Parse()` and [`CultureInfo`][culture-info].

[time-overview]: https://docs.microsoft.com/en-us/dotnet/standard/datetime/
[date-time]: https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=netcore-3.1
[time-span]: https://docs.microsoft.com/en-us/dotnet/api/system.timespan?view=netcore-2.0
[culture-info]: https://docs.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo?view=netcore-2.0
[time-zone-info]: https://docs.microsoft.com/en-us/dotnet/api/system.timezoneinfo?view=netcore-2.0
