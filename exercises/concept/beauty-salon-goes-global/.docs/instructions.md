In this exercise you are back in the world of salons (first introduced in the `datetimes` exercise). As with a number of your projects another of your clients has had great success and opened outlets in London and Paris in addition to their New York base.

## 1. Provide local time equivalents of UTC (Universal Coordinated Time) appointments for the administrators

Implement the static `Appointment.ShowLocalTime()` method that takes a UTC time and returns it as a local time

```csharp
// For a student in NY
Appointment.ShowLocalTime(new DateTime(2030, 7, 25, 13, 45, 0));
// => {2030, 7, 25, 8, 45, 0}
```

## 2. Schedule appointments in New York, London and Paris

Salons are responsible for taking their own bookings. The time input is local to the location of the salon. For instance, if someone enters a time of 13:45 for the New York salon for an appointment, they would expect the client to turn up just after lunch. Similarly, if someone entered a time of 13:45 for the London salon they would also expect the client arrive just after lunch.

It will help you to know the time zone id for New York, London and Paris.

On Mac (OSX) and Linux these are:

- New York - America/New_York
- London - Europe/London
- Paris - Europe/Paris

On Windows, they are:

- New York - Eastern Standard Time
- London - GMT Standard Time
- Paris - W. Europe Standard Time

Implement the static `Appointment.Schedule()` overload which takes a location and time string and returns the UTC time of the appointment.

The implementation of `Schedule()` will need to allow the code, once built, to be run on Linux, Windows and Mac. This is the first exercise where you need to be concerned about the operating system. It will be necessary to have separate code paths to accommodate the difference in the time zone ids as described above.

The date-time strings input are guaranteed to be valid.

```csharp
Appointment.Schedule("7/25/2030 13:45:00", Location.Paris);
// => {2030, 7, 25, 11, 45, 0}
```

## 3. Provide alerts to clients at intervals before the appointment

Implement the static `Appointment.GetAlertTime()` to provide alerts at 1 day (early), 1 hour 45 minutes (standard) and 30 minutes (late) before the appointment.

```csharp
Appointment.GetAlertTime(new DateTime(2030, 7, 25, 14, 45, 0), AlertLevel.Early);
// => {2030, 7, 24, 14, 45, 0}
```

## 4. If daylight savings has recently changed we send a message to clients reminding them.

Implement the static `Appointment.HasDaylightSavingChanged()` to return `true` if the daylight savings has become active or inactive in the last 7 days.

```csharp
Appointment.HasDaylightSavingChanged(new DateTime(2020, 3, 30, 14, 45, 0), Location.London);
// => true
```

## 5. Use the local date time format to enter appointments

In order that appointments can be made in a format familiar to the local staff you have been tasked with creating an experimental routine to allow dates and times to be entered in the default format for the location of the salon.

Implement the `Appointment.NormalizeDateTime()` method that takes a well-formed date-time string in an format appropriate to the location and converts it into a `DateTime` object. No attempt is made to convert the date-time to UTC.

If a bad format is entered then a `DateTime` with a value of 1/1/1 should be returned.

```csharp
Appointment.NormalizeDateTime("25/11/2019 13:45:00", Location.London);
// => {2019, 11, 25, 13, 45, 0}
Appointment.NormalizeDateTime("25/11/2019 13:45:00", Location.NewYork);
// => {1, 1, 1, 0, 0, 0}
```
