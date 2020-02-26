In this exercise you'll be working on an appointment scheduler for a beauty salon in New York.

You have four tasks, which will all involve appointment dates. The dates and times will use one of the following four formats:

- `"7/25/2019 13:45:00"`
- `"July 25, 2019 13:45:00"`
- `"Thursday, July 25, 2019 13:45:00:00"`
- `"July 25, 2019 13:45:00"`

The tests will automatically set the culture to `en-US` - you don't have to set or specify the culture yourselves.

### 1. Parse appointment date

Implement a method that can parse a textual representation of an appointment date into the corresponding `DateTime` format:

```csharp
Appointment.Schedule("7/25/2019 13:45:00")
// Returns: new DateTime(2019, 7, 25, 13, 45, 0)
```

### 2. Check if an appointment has already passed

Implement a method that takes an appointment date and checks if the appointment was somewhere in the past:

```csharp
Appointment.HasPassed(new DateTime(1999, 12, 31, 9, 0, 0))
// Returns: true
```

### 3. Check if appointment is in the afternoon

Implement a method that takes an appointment date and checks if the appointment is in the afternoon (>= 12:00 and < 18:00):

```csharp
Appointment.IsAfternoonAppointment(new DateTime(2019, 03, 29, 15, 0, 0))
// Returns: true
```

### 4. Describe the time and date of the appointment

Implement a method that takes an appointment date and returns a description of that date and time:

```csharp
Appointment.Description(new DateTime(2019, 03, 29, 15, 0, 0))
// Returns: "You have an appointment on Friday 29 March 2019 at 15:00."
```
