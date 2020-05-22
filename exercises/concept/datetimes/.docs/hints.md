## General

- [Tutorial on dates and time by csharp.net][csharp.net-datetimes-working-with-datetimes-time]

## 1. Parse appointment date

- The `DateTime` class has several methods to [parse][docs.microsoft.com_parsing-date] a `string` to a `DateTime`.

## 2. Check if an appointment has already passed

- `DateTime` objects can be compared using the default [comparison operators][docs.microsoft.com_datetime-operators].
- There is a [property][docs.microsoft.com_datetime-properties] to retrieve the current date and time.

## 3. Check if appointment is in the afternoon

- Accessing the time portion of a `DateTime` object can de done through one of its [properties][docs.microsoft.com_datetime-properties].

## 4. Describe the time and date of the appointment

- The tests are running as if running on a machine in the United States, which means that when converting a `DateTime` to a `string` will return dates and time in US format.
- When converting a `DateTime` instance to a `string`, you can use either a [standard format string][docs.microsoft.com_standard-date-and-time-format-strings] or a [custom format string][docs.microsoft.com_custom-date-and-time-format-strings].

## 5. Return the anniversary date

- Use one of the various `DateTime` [constructors][constructors] to create a new `DateTime` instance.
- You can use one of the current date time's [properties][docs.microsoft.com_datetime-properties] to get the current year.

[docs.microsoft.com_parsing-date]: https://docs.microsoft.com/en-us/dotnet/standard/base-types/parsing-datetime
[docs.microsoft.com_datetime-operators]: https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=netframework-4.8#operators
[docs.microsoft.com_datetime-properties]: https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=netcore-3.0#properties
[docs.microsoft.com_standard-date-and-time-format-strings]: https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings
[docs.microsoft.com_custom-date-and-time-format-strings]: https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings
[csharp.net-datetimes-working-with-datetimes-time]: https://csharp.net-tutorials.com/data-types/working-with-datetimes-time/
[constructors]: https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=netcore-3.1#constructors
