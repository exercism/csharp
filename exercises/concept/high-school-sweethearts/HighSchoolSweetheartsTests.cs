using System;
using Xunit;

public class StringFormattingTests
{
    private const string expectedBanner =
@"
     ******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
**     L. G.  +  P. R.     **
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *
";
    [Fact]
    public void DisplaySingleLine()
    {
        const string expected = "                  Lance Green ♡ Pat Riley                    ";
        Assert.Equal(expected, HighSchoolSweetheart.DisplaySingleLine("Lance Green", "Pat Riley"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void DisplayBanner()
    {
        string actualBanner = HighSchoolSweetheart.DisplayBanner("L. G. ", "P. R. ");
        Assert.Equal(expectedBanner.Trim(), actualBanner.Trim());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void DisplayGermanExchangeStudents()
    {
        string actual = HighSchoolSweetheart.DisplayGermanExchangeStudents("Norbert", "Heidi",
            new DateTime(2019, 1, 22), 1535.22f);
        Assert.Equal("Norbert and Heidi have been dating since 22.01.2019 - that's 1.535,22 hours"
            , actual);
    }
}
