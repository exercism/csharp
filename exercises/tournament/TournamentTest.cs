using System;
using System.IO;
using System.Text;
using NUnit.Framework;

[TestFixture]
public class TournamentTest
{
    readonly string input1 = 
        "Αllegoric Alaskians;Blithering Badgers;win" + Environment.NewLine +
        "Devastating Donkeys;Courageous Californians;draw" + Environment.NewLine +
        "Devastating Donkeys;Αllegoric Alaskians;win" + Environment.NewLine +
        "Courageous Californians;Blithering Badgers;loss" + Environment.NewLine +
        "Blithering Badgers;Devastating Donkeys;loss" + Environment.NewLine +
        "Αllegoric Alaskians;Courageous Californians;win".Trim();
    
    private readonly string input2 = 
        "Allegoric Alaskians;Blithering Badgers;win" + Environment.NewLine +
        "Devastating Donkeys_Courageous Californians;draw" + Environment.NewLine +
        "Devastating Donkeys;Allegoric Alaskians;win" + Environment.NewLine +
        "" + Environment.NewLine +
        "Courageous Californians;Blithering Badgers;loss" + Environment.NewLine +
        "Bla;Bla;Bla" + Environment.NewLine +
        "Blithering Badgers;Devastating Donkeys;loss" + Environment.NewLine +
        "# Yackity yackity yack" + Environment.NewLine +
        "Allegoric Alaskians;Courageous Californians;win" + Environment.NewLine +
        "Devastating Donkeys;Courageous Californians;draw" + Environment.NewLine +
        "Devastating Donkeys@Courageous Californians;draw"; // Trim() omitted by design
    
    private readonly string input3 = 
        "Allegoric Alaskians;Blithering Badgers;win" + Environment.NewLine +
        "Devastating Donkeys;Allegoric Alaskians;win" + Environment.NewLine +
        "Courageous Californians;Blithering Badgers;loss" + Environment.NewLine +
        "Allegoric Alaskians;Courageous Californians;win".Trim();
    
    readonly string expected1 =
        "Team                           | MP |  W |  D |  L |  P" + Environment.NewLine +
        "Devastating Donkeys            |  3 |  2 |  1 |  0 |  7" + Environment.NewLine +
        "Αllegoric Alaskians            |  3 |  2 |  0 |  1 |  6" + Environment.NewLine +
        "Blithering Badgers             |  3 |  1 |  0 |  2 |  3" + Environment.NewLine +
        "Courageous Californians        |  3 |  0 |  1 |  2 |  1".Trim();
    
    private readonly string expected2 =
        "Team                           | MP |  W |  D |  L |  P" + Environment.NewLine +
        "Devastating Donkeys            |  3 |  2 |  1 |  0 |  7" + Environment.NewLine +
        "Allegoric Alaskians            |  3 |  2 |  0 |  1 |  6" + Environment.NewLine +
        "Blithering Badgers             |  3 |  1 |  0 |  2 |  3" + Environment.NewLine +
        "Courageous Californians        |  3 |  0 |  1 |  2 |  1".Trim();
    
    private readonly string expected3 = 
        "Team                           | MP |  W |  D |  L |  P" + Environment.NewLine +
        "Allegoric Alaskians            |  3 |  2 |  0 |  1 |  6" + Environment.NewLine +
        "Blithering Badgers             |  2 |  1 |  0 |  1 |  3" + Environment.NewLine +
        "Devastating Donkeys            |  1 |  1 |  0 |  0 |  3" + Environment.NewLine +
        "Courageous Californians        |  2 |  0 |  0 |  2 |  0".Trim();

    private string RunTally(string input)
    {
        var encoding = new UTF8Encoding();
        
        using (var inStream = new MemoryStream(encoding.GetBytes(input)))
        {
            using (var outStream = new MemoryStream())
            {
                Tournament.Tally(inStream, outStream);
                return encoding.GetString(outStream.GetBuffer());
            }
        }
    }

    [Test]
    public void Test_good()
    {
        Assert.That(RunTally(input1).Trim(), Is.EqualTo(expected1));
    }
    
    [Test]
    [Ignore("Remove to run test")]
    public void Test_ignore_bad_lines()
    {
        Assert.That(RunTally(input2).Trim(), Is.EqualTo(expected2));
    }
    
    [Test]
    [Ignore("Remove to run test")]
    public void Test_incomplete_competition()
    {
        Assert.That(RunTally(input3).Trim(), Is.EqualTo(expected3));
    }
}
