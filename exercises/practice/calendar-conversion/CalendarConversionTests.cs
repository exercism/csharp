using System.Globalization;

public class CalendarConversionTests
{
    [Fact]
    public void ToGregorianDate()
    {
        var date = new DateOnly(1453, 5, 29);
        Assert.Equal("Sun, 29 May 1453", CalendarConversion.ToGregorianDate(date));
    }
    
    // [Fact(Skip = "Remove this Skip property to run this test")]
    [Fact]
    public void ToHijiriDate()
    {
        var date = new DateOnly(1453, 5, 29);
        Assert.Equal("12 جما١، 0857 بعد الهجرة", CalendarConversion.ToHijriDate(date));
    }
}