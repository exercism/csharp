using Xunit;
using Exercism.Tests;
using System;
using System.Globalization;
using System.Threading;

public class AppointmentTests
{
    public AppointmentTests()
    {
        var enUsCulture = new CultureInfo("en-US");
        Thread.CurrentThread.CurrentCulture = enUsCulture;
        Thread.CurrentThread.CurrentUICulture = enUsCulture;
    }

    [Fact]
    public void Schedule_date_using_only_numbers()
    {
        Assert.Equal(new DateTime(2019, 07, 25, 13, 45, 0), Appointment.Schedule("7/25/2019 13:45:00"));
    }

    [Fact]
    public void Schedule_date_with_textual_month()
    {
        Assert.Equal(new DateTime(2019, 6, 3, 11, 30, 0), Appointment.Schedule("June 3, 2019 11:30:00"));
    }

    [Fact]
    public void Schedule_date_with_textual_month_and_weekday()
    {
        Assert.Equal(new DateTime(2019, 12, 5, 9, 0, 0), Appointment.Schedule("Thursday, December 5, 2019 09:00:00"));
    }

    [Fact]
    public void Has_passed_with_appointment_one_year_ago()
    {
        Assert.True(Appointment.HasPassed(DateTime.Now.AddYears(-1).AddHours(2)));
    }

    [Fact]
    public void Has_passed_with_appointment_months_ago()
    {
        Assert.True(Appointment.HasPassed(DateTime.Now.AddMonths(-8)));
    }

    [Fact]
    public void Has_passed_with_appointment_days_ago()
    {
        Assert.True(Appointment.HasPassed(DateTime.Now.AddDays(-23)));
    }

    [Fact]
    public void Has_passed_with_appointment_hours_ago()
    {
        Assert.True(Appointment.HasPassed(DateTime.Now.AddHours(-12)));
    }

    [Fact]
    public void Has_passed_with_appointment_minutes_ago()
    {
        Assert.True(Appointment.HasPassed(DateTime.Now.AddMinutes(-55)));
    }

    [Fact]
    public void Has_passed_with_appointment_one_minute_ago()
    {
        Assert.True(Appointment.HasPassed(DateTime.Now.AddMinutes(-1)));
    }

    [Fact]
    public void Has_passed_with_appointment_in_one_minute()
    {
        Assert.False(Appointment.HasPassed(DateTime.Now.AddMinutes(1)));
    }

    [Fact]
    public void Has_passed_with_appointment_in_minutes()
    {
        Assert.False(Appointment.HasPassed(DateTime.Now.AddMinutes(5)));
    }

    [Fact]
    public void Has_passed_with_appointment_in_days()
    {
        Assert.False(Appointment.HasPassed(DateTime.Now.AddDays(19)));
    }

    [Fact]
    public void Has_passed_with_appointment_in_months()
    {
        Assert.False(Appointment.HasPassed(DateTime.Now.AddMonths(10)));
    }

    [Fact]
    public void Has_passed_with_appointment_in_years()
    {
        Assert.False(Appointment.HasPassed(DateTime.Now.AddYears(2).AddMonths(3).AddDays(6)));
    }

    [Fact]
    public void Is_afternoon_appointment_for_early_morning_appointment()
    {
        Assert.False(Appointment.IsAfternoonAppointment(new DateTime(2019, 6, 17, 8, 15, 0)));
    }

    [Fact]
    public void Is_afternoon_appointment_for_late_morning_appointment()
    {
        Assert.False(Appointment.IsAfternoonAppointment(new DateTime(2019, 2, 23, 11, 59, 59)));
    }

    [Fact]
    public void Is_afternoon_appointment_for_noon_appointment()
    {
        Assert.True(Appointment.IsAfternoonAppointment(new DateTime(2019, 8, 9, 12, 0, 0)));
    }

    [Fact]
    public void Is_afternoon_appointment_for_early_afternoon_appointment()
    {
        Assert.True(Appointment.IsAfternoonAppointment(new DateTime(2019, 8, 9, 12, 0, 1)));
    }

    [Fact]
    public void Is_afternoon_appointment_for_late_afternoon_appointment()
    {
        Assert.True(Appointment.IsAfternoonAppointment(new DateTime(2019, 9, 1, 17, 59, 59)));
    }

    [Fact]
    public void Is_afternoon_appointment_for_early_evening_appointment()
    {
        Assert.False(Appointment.IsAfternoonAppointment(new DateTime(2019, 9, 1, 18, 0, 0)));
    }

    [Fact]
    public void Is_afternoon_appointment_for_late_evening_appointment()
    {
        Assert.False(Appointment.IsAfternoonAppointment(new DateTime(2019, 9, 1, 23, 59, 59)));
    }

    [Fact]
    public void Description_on_friday_afternoon()
    {
        Assert.Equal("You have an appointment on 3/29/2019 3:00:00 PM.", Appointment.Description(new DateTime(2019, 03, 29, 15, 0, 0)));
    }

    [Fact]
    public void Description_on_thursday_afternoon()
    {
        Assert.Equal("You have an appointment on 7/25/2019 1:45:00 PM.", Appointment.Description(new DateTime(2019, 07, 25, 13, 45, 0)));
    }

    [Fact]
    public void Description_on_wednesday_morning()
    {
        Assert.Equal("You have an appointment on 9/9/2020 9:09:09 AM.", Appointment.Description(new DateTime(2020, 9, 9, 9, 9, 9)));
    }

    [Fact]
    public void Anniversary_date()
    {
        Assert.Equal(new DateTime(DateTime.Now.Year, 9, 15), Appointment.AnniversaryDate());
    }
}
