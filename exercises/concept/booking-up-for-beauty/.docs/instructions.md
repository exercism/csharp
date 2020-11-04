In this exercise you'll be working on an appointment scheduler for a beauty salon in New York that opened on September 15th in 2012.

You have four tasks, which will all involve appointment dates. The dates and times will use one of the following three formats:

- `"7/25/2019 13:45:00"`
- `"July 25, 2019 13:45:00"`
- `"Thursday, July 25, 2019 13:45:00:00"`

The tests will automatically set the culture to `en-US` - you don't have to set or specify the culture yourselves.

## 1. Parse appointment date

Implement the (_static_) `Appointment.Schedule()` method to parse a textual representation of an appointment date into the corresponding `DateTime` format:

```csharp
Appointment.Schedule("7/25/2019 13:45:00")
// => new DateTime(2019, 7, 25, 13, 45, 0)
```

## 2. Check if an appointment has already passed

Implement the (_static_) `Appointment.HasPassed()` method that takes an appointment date and checks if the appointment was somewhere in the past:

```csharp
Appointment.HasPassed(new DateTime(1999, 12, 31, 9, 0, 0))
// => true
```

## 3. Check if appointment is in the afternoon

Implement the (_static_) `Appointment.IsAfternoonAppointment()` method that takes an appointment date and checks if the appointment is in the afternoon (>= 12:00 and < 18:00):

```csharp
Appointment.IsAfternoonAppointment(new DateTime(2019, 03, 29, 15, 0, 0))
// => true
```

## 4. Describe the time and date of the appointment

Implement the (_static_) `Appointment.Description()` method that takes an appointment date and returns a description of that date and time:

```csharp
Appointment.Description(new DateTime(2019, 03, 29, 15, 0, 0))
// => "You have an appointment on Friday 29 March 2019 at 15:00."
```

## 5. Return the anniversary date

Implement the (_static_) `Appointment.AnniversaryDate()` method that returns this year's anniversary date, which is September 15th:

```csharp
Appointment.AnniversaryDate()
// => new DateTime(2019, 9, 15, 0, 0, 0)
```
