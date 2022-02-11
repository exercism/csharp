using System;
using Xunit;
using Exercism.Tests;

public class HighSchoolSweetheartsTests
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
    [Task(1)]
    public void DisplaySingleLine()
    {
        const string expected = "                  Lance Green ♡ Pat Riley                    ";
        Assert.Equal(expected, HighSchoolSweethearts.DisplaySingleLine("Lance Green", "Pat Riley"));
    }

    [Fact]
    [Task(2)]
    public void DisplayBanner()
    {
        string actualBanner = HighSchoolSweethearts.DisplayBanner("L. G. ", "P. R. ");
        Assert.Equal(expectedBanner.Trim(), actualBanner.Trim());
    }

    [Fact]
    [Task(3)]
    public void DisplayGermanExchangeStudents()
    {
        string actual = HighSchoolSweethearts.DisplayGermanExchangeStudents("Norbert", "Heidi",
            new DateTime(2019, 1, 22), 1535.22f);
        Assert.Equal("Norbert and Heidi have been dating since 22.01.2019 - that's 1.535,22 hours"
            , actual);
    }
}
