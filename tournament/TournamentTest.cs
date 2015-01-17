using System;
using System.IO;
using System.Text;
using NUnit.Framework;

[TestFixture]
public class TournamentTest
{
    readonly string input1 = @"
Αllegoric Alaskians;Blithering Badgers;win
Devastating Donkeys;Courageous Californians;draw
Devastating Donkeys;Αllegoric Alaskians;win
Courageous Californians;Blithering Badgers;loss
Blithering Badgers;Devastating Donkeys;loss
Αllegoric Alaskians;Courageous Californians;win
".Trim();
    
    readonly string input2 = @"
Allegoric Alaskians;Blithering Badgers;win
Devastating Donkeys_Courageous Californians;draw
Devastating Donkeys;Allegoric Alaskians;win

Courageous Californians;Blithering Badgers;loss
Bla;Bla;Bla
Blithering Badgers;Devastating Donkeys;loss
# Yackity yackity yack
Allegoric Alaskians;Courageous Californians;win
Devastating Donkeys;Courageous Californians;draw
Devastating Donkeys@Courageous Californians;draw
"; // Trim() omitted by design
    
    readonly string input3 = @"
Allegoric Alaskians;Blithering Badgers;win
Devastating Donkeys;Allegoric Alaskians;win
Courageous Californians;Blithering Badgers;loss
Allegoric Alaskians;Courageous Californians;win
".Trim();
    
    readonly string expected1 = @"
Team                           | MP |  W |  D |  L |  P
Devastating Donkeys            |  3 |  2 |  1 |  0 |  7
Αllegoric Alaskians            |  3 |  2 |  0 |  1 |  6
Blithering Badgers             |  3 |  1 |  0 |  2 |  3
Courageous Californians        |  3 |  0 |  1 |  2 |  1
".Trim();
    
    readonly string expected2 = @"
Team                           | MP |  W |  D |  L |  P
Devastating Donkeys            |  3 |  2 |  1 |  0 |  7
Allegoric Alaskians            |  3 |  2 |  0 |  1 |  6
Blithering Badgers             |  3 |  1 |  0 |  2 |  3
Courageous Californians        |  3 |  0 |  1 |  2 |  1
".Trim();
    
    readonly string expected3 = @"
Team                           | MP |  W |  D |  L |  P
Allegoric Alaskians            |  3 |  2 |  0 |  1 |  6
Blithering Badgers             |  2 |  1 |  0 |  1 |  3
Devastating Donkeys            |  1 |  1 |  0 |  0 |  3
Courageous Californians        |  2 |  0 |  0 |  2 |  0
".Trim();

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
    [Ignore]
    public void Test_ignore_bad_lines()
    {
        Assert.That(RunTally(input2).Trim(), Is.EqualTo(expected2));
    }
    
    [Test]
    [Ignore]
    public void Test_incomplete_competition()
    {
        Assert.That(RunTally(input3).Trim(), Is.EqualTo(expected3));
    }
}
