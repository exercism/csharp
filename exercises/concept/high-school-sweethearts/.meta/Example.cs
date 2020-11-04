using System;
using System.Globalization;

public static class HighSchoolSweetheart
{
    private const string banner =
        @"
     ******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
**     {0} +  {1}    **
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *
";

    public static string DisplaySingleLine(string studentA, string studentB)
    {
        const int lineLength = 61;
        const int linePartLength = (lineLength - 1) / 2 - 1;
        return $"{studentA,linePartLength} ♡ {studentB,-linePartLength}";
    }

    public static string DisplayBanner(string studentA, string studentB)
    {
        return string.Format(banner, studentA, studentB);
    }

    public static string DisplayGermanExchangeStudents(string studentA
        , string studentB, DateTime start, float hours)
    {
        FormattableString fs =
            $"{studentA} and {studentB} have been dating since {start:d} - that's {hours:n2} hours";
        return fs.ToString(CultureInfo.CreateSpecificCulture("de-DE"));
    }
}
