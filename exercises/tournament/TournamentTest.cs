// This file was auto-generated based on version 1.4.0 of the canonical data.

using System;
using System.IO;
using System.Text;
using Xunit;

public class TournamentTest
{
    [Fact]
    public void Just_the_header_if_no_input()
    {
        var rows = "";
        var expected = "Team                           | MP |  W |  D |  L |  P";
        Assert.Equal(expected, RunTally(rows));
    }

    [Fact(Skip = "Remove to run test")]
    public void A_win_is_three_points_a_loss_is_zero_points()
    {
        var rows = "Allegoric Alaskans;Blithering Badgers;win";
        var expected = 
            "Team                           | MP |  W |  D |  L |  P\n" +
            "Allegoric Alaskans             |  1 |  1 |  0 |  0 |  3\n" +
            "Blithering Badgers             |  1 |  0 |  0 |  1 |  0";
        Assert.Equal(expected, RunTally(rows));
    }

    [Fact(Skip = "Remove to run test")]
    public void A_win_can_also_be_expressed_as_a_loss()
    {
        var rows = "Blithering Badgers;Allegoric Alaskans;loss";
        var expected = 
            "Team                           | MP |  W |  D |  L |  P\n" +
            "Allegoric Alaskans             |  1 |  1 |  0 |  0 |  3\n" +
            "Blithering Badgers             |  1 |  0 |  0 |  1 |  0";
        Assert.Equal(expected, RunTally(rows));
    }

    [Fact(Skip = "Remove to run test")]
    public void A_different_team_can_win()
    {
        var rows = "Blithering Badgers;Allegoric Alaskans;win";
        var expected = 
            "Team                           | MP |  W |  D |  L |  P\n" +
            "Blithering Badgers             |  1 |  1 |  0 |  0 |  3\n" +
            "Allegoric Alaskans             |  1 |  0 |  0 |  1 |  0";
        Assert.Equal(expected, RunTally(rows));
    }

    [Fact(Skip = "Remove to run test")]
    public void A_draw_is_one_point_each()
    {
        var rows = "Allegoric Alaskans;Blithering Badgers;draw";
        var expected = 
            "Team                           | MP |  W |  D |  L |  P\n" +
            "Allegoric Alaskans             |  1 |  0 |  1 |  0 |  1\n" +
            "Blithering Badgers             |  1 |  0 |  1 |  0 |  1";
        Assert.Equal(expected, RunTally(rows));
    }

    [Fact(Skip = "Remove to run test")]
    public void There_can_be_more_than_one_match()
    {
        var rows = 
            "Allegoric Alaskans;Blithering Badgers;win\n" +
            "Allegoric Alaskans;Blithering Badgers;win";
        var expected = 
            "Team                           | MP |  W |  D |  L |  P\n" +
            "Allegoric Alaskans             |  2 |  2 |  0 |  0 |  6\n" +
            "Blithering Badgers             |  2 |  0 |  0 |  2 |  0";
        Assert.Equal(expected, RunTally(rows));
    }

    [Fact(Skip = "Remove to run test")]
    public void There_can_be_more_than_one_winner()
    {
        var rows = 
            "Allegoric Alaskans;Blithering Badgers;loss\n" +
            "Allegoric Alaskans;Blithering Badgers;win";
        var expected = 
            "Team                           | MP |  W |  D |  L |  P\n" +
            "Allegoric Alaskans             |  2 |  1 |  0 |  1 |  3\n" +
            "Blithering Badgers             |  2 |  1 |  0 |  1 |  3";
        Assert.Equal(expected, RunTally(rows));
    }

    [Fact(Skip = "Remove to run test")]
    public void There_can_be_more_than_two_teams()
    {
        var rows = 
            "Allegoric Alaskans;Blithering Badgers;win\n" +
            "Blithering Badgers;Courageous Californians;win\n" +
            "Courageous Californians;Allegoric Alaskans;loss";
        var expected = 
            "Team                           | MP |  W |  D |  L |  P\n" +
            "Allegoric Alaskans             |  2 |  2 |  0 |  0 |  6\n" +
            "Blithering Badgers             |  2 |  1 |  0 |  1 |  3\n" +
            "Courageous Californians        |  2 |  0 |  0 |  2 |  0";
        Assert.Equal(expected, RunTally(rows));
    }

    [Fact(Skip = "Remove to run test")]
    public void Typical_input()
    {
        var rows = 
            "Allegoric Alaskans;Blithering Badgers;win\n" +
            "Devastating Donkeys;Courageous Californians;draw\n" +
            "Devastating Donkeys;Allegoric Alaskans;win\n" +
            "Courageous Californians;Blithering Badgers;loss\n" +
            "Blithering Badgers;Devastating Donkeys;loss\n" +
            "Allegoric Alaskans;Courageous Californians;win";
        var expected = 
            "Team                           | MP |  W |  D |  L |  P\n" +
            "Devastating Donkeys            |  3 |  2 |  1 |  0 |  7\n" +
            "Allegoric Alaskans             |  3 |  2 |  0 |  1 |  6\n" +
            "Blithering Badgers             |  3 |  1 |  0 |  2 |  3\n" +
            "Courageous Californians        |  3 |  0 |  1 |  2 |  1";
        Assert.Equal(expected, RunTally(rows));
    }

    [Fact(Skip = "Remove to run test")]
    public void Incomplete_competition_not_all_pairs_have_played_()
    {
        var rows = 
            "Allegoric Alaskans;Blithering Badgers;loss\n" +
            "Devastating Donkeys;Allegoric Alaskans;loss\n" +
            "Courageous Californians;Blithering Badgers;draw\n" +
            "Allegoric Alaskans;Courageous Californians;win";
        var expected = 
            "Team                           | MP |  W |  D |  L |  P\n" +
            "Allegoric Alaskans             |  3 |  2 |  0 |  1 |  6\n" +
            "Blithering Badgers             |  2 |  1 |  1 |  0 |  4\n" +
            "Courageous Californians        |  2 |  0 |  1 |  1 |  1\n" +
            "Devastating Donkeys            |  1 |  0 |  0 |  1 |  0";
        Assert.Equal(expected, RunTally(rows));
    }

    [Fact(Skip = "Remove to run test")]
    public void Ties_broken_alphabetically()
    {
        var rows = 
            "Courageous Californians;Devastating Donkeys;win\n" +
            "Allegoric Alaskans;Blithering Badgers;win\n" +
            "Devastating Donkeys;Allegoric Alaskans;loss\n" +
            "Courageous Californians;Blithering Badgers;win\n" +
            "Blithering Badgers;Devastating Donkeys;draw\n" +
            "Allegoric Alaskans;Courageous Californians;draw";
        var expected = 
            "Team                           | MP |  W |  D |  L |  P\n" +
            "Allegoric Alaskans             |  3 |  2 |  1 |  0 |  7\n" +
            "Courageous Californians        |  3 |  2 |  1 |  0 |  7\n" +
            "Blithering Badgers             |  3 |  0 |  1 |  2 |  1\n" +
            "Devastating Donkeys            |  3 |  0 |  1 |  2 |  1";
        Assert.Equal(expected, RunTally(rows));
    }

    private string RunTally(string input)
    {
        var encoding = new UTF8Encoding();
        using (var inStream = new MemoryStream(encoding.GetBytes(input)))
        using (var outStream = new MemoryStream())
        {
            Tournament.Tally(inStream, outStream);
            return encoding.GetString(outStream.ToArray());
        }
    }
}