using Xunit;
using System;
using System.Globalization;
using System.Reflection;
using System.Threading;
using Xunit.Sdk;

[UseCulture("en-US")]
public class AppointmentTest
{
    [Fact]
    public void ScheduleDateUsingOnlyNumbers() =>
        Assert.Equal(new DateTime(2019, 07, 25, 13, 45, 0), Appointment.Schedule("7/25/2019 13:45:00"));

    [Fact]
    public void ScheduleDateWithTextualMonth() =>
        Assert.Equal(new DateTime(2019, 6, 3, 11, 30, 0), Appointment.Schedule("June 3, 2019 11:30:00"));

    [Fact]
    public void ScheduleDateWithTextualMonthAndWeekday() =>
        Assert.Equal(new DateTime(2019, 12, 5, 9, 0, 0), Appointment.Schedule("Thursday, December 5, 2019 09:00:00"));

    [Fact]
    public void HasPassedWithAppointmentOneYearAgo() =>
        Assert.True(Appointment.HasPassed(DateTime.Now.AddYears(-1).AddHours(2)));

    [Fact]
    public void HasPassedWithAppointmentMonthsAgo() =>
        Assert.True(Appointment.HasPassed(DateTime.Now.AddMonths(-8)));

    [Fact]
    public void HasPassedWithAppointmentDaysAgo() =>
        Assert.True(Appointment.HasPassed(DateTime.Now.AddDays(-23)));

    [Fact]
    public void HasPassedWithAppointmentHoursAgo() =>
        Assert.True(Appointment.HasPassed(DateTime.Now.AddHours(-12)));

    [Fact]
    public void HasPassedWithAppointmentMinutesAgo() =>
        Assert.True(Appointment.HasPassed(DateTime.Now.AddMinutes(-55)));

    [Fact]
    public void HasPassedWithAppointmentOneMinuteAgo() =>
        Assert.True(Appointment.HasPassed(DateTime.Now.AddMinutes(-1)));

    [Fact]
    public void HasPassedWithAppointmentInOneMinute() =>
        Assert.False(Appointment.HasPassed(DateTime.Now.AddMinutes(1)));

    [Fact]
    public void HasPassedWithAppointmentInMinutes() =>
        Assert.False(Appointment.HasPassed(DateTime.Now.AddMinutes(5)));

    [Fact]
    public void HasPassedWithAppointmentInDays() =>
        Assert.False(Appointment.HasPassed(DateTime.Now.AddDays(19)));

    [Fact]
    public void HasPassedWithAppointmentInMonths() =>
        Assert.False(Appointment.HasPassed(DateTime.Now.AddMonths(10)));

    [Fact]
    public void HasPassedWithAppointmentInYears() =>
        Assert.False(Appointment.HasPassed(DateTime.Now.AddYears(2).AddMonths(3).AddDays(6)));

    [Fact]
    public void IsAfternoonAppointmentForEarlyMorningAppointment() =>
        Assert.False(Appointment.IsAfternoonAppointment(new DateTime(2019, 6, 17, 8, 15, 0)));

    [Fact]
    public void IsAfternoonAppointmentForLateMorningAppointment() =>
        Assert.False(Appointment.IsAfternoonAppointment(new DateTime(2019, 2, 23, 11, 59, 59)));

    [Fact]
    public void IsAfternoonAppointmentForNoonAppointment() =>
        Assert.True(Appointment.IsAfternoonAppointment(new DateTime(2019, 8, 9, 12, 0, 0)));

    [Fact]
    public void IsAfternoonAppointmentForEarlyAfternoonAppointment() =>
        Assert.True(Appointment.IsAfternoonAppointment(new DateTime(2019, 8, 9, 12, 0, 1)));

    [Fact]
    public void IsAfternoonAppointmentForLateAfternoonAppointment() =>
        Assert.True(Appointment.IsAfternoonAppointment(new DateTime(2019, 9, 1, 17, 59, 59)));

    [Fact]
    public void IsAfternoonAppointmentForEarlyEveningAppointment() =>
        Assert.False(Appointment.IsAfternoonAppointment(new DateTime(2019, 9, 1, 18, 0, 0)));

    [Fact]
    public void IsAfternoonAppointmentForLateEveningAppointment() =>
        Assert.False(Appointment.IsAfternoonAppointment(new DateTime(2019, 9, 1, 23, 59, 59)));

    [Fact]
    public void DescriptionOnFridayAfternoon() =>
        Assert.Equal("You have an appointment on Friday 29 March 2019 at 15:00.", Appointment.Description(new DateTime(2019, 03, 29, 15, 0, 0)));

    [Fact]
    public void DescriptionOnThursdayAfternoon() =>
        Assert.Equal("You have an appointment on Thursday 25 July 2019 at 13:45.", Appointment.Description(new DateTime(2019, 07, 25, 13, 45, 0)));

    [Fact]
    public void DescriptionOnWednesdayMorning() =>
        Assert.Equal("You have an appointment on Wednesday 9 September 2020 at 09:09.", Appointment.Description(new DateTime(2020, 9, 9, 9, 9, 9)));

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    private class UseCultureAttribute : BeforeAfterTestAttribute
    {
        private readonly CultureInfo _culture;
        private readonly CultureInfo _uiCulture;
        private CultureInfo _originalCulture;
        private CultureInfo _originalUiCulture;

        public UseCultureAttribute(string culture)
            : this(culture, culture) { }

        public UseCultureAttribute(string culture, string uiCulture)
        {
            _culture = new CultureInfo(culture, false);
            _uiCulture = new CultureInfo(uiCulture, false);
        }

        public override void Before(MethodInfo methodUnderTest)
        {
            _originalCulture = Thread.CurrentThread.CurrentCulture;
            _originalUiCulture = Thread.CurrentThread.CurrentUICulture;

            Thread.CurrentThread.CurrentCulture = _culture;
            Thread.CurrentThread.CurrentUICulture = _uiCulture;

            CultureInfo.CurrentCulture.ClearCachedData();
            CultureInfo.CurrentUICulture.ClearCachedData();
        }

        public override void After(MethodInfo methodUnderTest)
        {
            Thread.CurrentThread.CurrentCulture = _originalCulture;
            Thread.CurrentThread.CurrentUICulture = _originalUiCulture;

            CultureInfo.CurrentCulture.ClearCachedData();
            CultureInfo.CurrentUICulture.ClearCachedData();
        }
    }
}