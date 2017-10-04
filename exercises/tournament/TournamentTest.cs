// This file was auto-generated based on version 1.3.0 of the canonical data.

using Xunit;
using System;
using System.IO;
using System.Text;

public class TournamentTest
{
    [Fact]
    public void Just_the_header_if_no_input()
    {
        var input = string.Empty;
        var expected = "Team                           | MP |  W |  D |  L |  P".Trim();
        Assert.Equal(expected, RunTally(input).Trim());
    }

    [Fact(Skip = "Remove to run test")]
    public void A_win_is_three_points_a_loss_is_zero_points()
    {
        var input = "Allegoric Alaskans;Blithering Badgers;win".Trim();
        var expected = "Team                           | MP |  W |  D |  L |  P" + Environment.NewLine +
                       "Allegoric Alaskans             |  1 |  1 |  0 |  0 |  3" + Environment.NewLine +
                       "Blithering Badgers             |  1 |  0 |  0 |  1 |  0"
                       .Trim();
        Assert.Equal(expected, RunTally(input).Trim());
    }

    [Fact(Skip = "Remove to run test")]
    public void A_win_can_also_be_expressed_as_a_loss()
    {
        var input = "Blithering Badgers;Allegoric Alaskans;loss".Trim();
        var expected = "Team                           | MP |  W |  D |  L |  P" + Environment.NewLine +
                       "Allegoric Alaskans             |  1 |  1 |  0 |  0 |  3" + Environment.NewLine +
                       "Blithering Badgers             |  1 |  0 |  0 |  1 |  0"
                       .Trim();
        Assert.Equal(expected, RunTally(input).Trim());
    }

    [Fact(Skip = "Remove to run test")]
    public void A_different_team_can_win()
    {
        var input = "Blithering Badgers;Allegoric Alaskans;win".Trim();
        var expected = "Team                           | MP |  W |  D |  L |  P" + Environment.NewLine +
                       "Blithering Badgers             |  1 |  1 |  0 |  0 |  3" + Environment.NewLine +
                       "Allegoric Alaskans             |  1 |  0 |  0 |  1 |  0"
                       .Trim();
        Assert.Equal(expected, RunTally(input).Trim());
    }

    [Fact(Skip = "Remove to run test")]
    public void A_draw_is_one_point_each()
    {
        var input = "Allegoric Alaskans;Blithering Badgers;draw".Trim();
        var expected = "Team                           | MP |  W |  D |  L |  P" + Environment.NewLine +
                       "Allegoric Alaskans             |  1 |  0 |  1 |  0 |  1" + Environment.NewLine +
                       "Blithering Badgers             |  1 |  0 |  1 |  0 |  1"
                       .Trim();
        Assert.Equal(expected, RunTally(input).Trim());
    }

    [Fact(Skip = "Remove to run test")]
    public void There_can_be_more_than_one_match()
    {
        var input = "Allegoric Alaskans;Blithering Badgers;win" + Environment.NewLine +
                       "Allegoric Alaskans;Blithering Badgers;win"
                       .Trim();
        var expected = "Team                           | MP |  W |  D |  L |  P" + Environment.NewLine +
                       "Allegoric Alaskans             |  2 |  2 |  0 |  0 |  6" + Environment.NewLine +
                       "Blithering Badgers             |  2 |  0 |  0 |  2 |  0"
                       .Trim();
        Assert.Equal(expected, RunTally(input).Trim());
    }

    [Fact(Skip = "Remove to run test")]
    public void There_can_be_more_than_one_winner()
    {
        var input = "Allegoric Alaskans;Blithering Badgers;loss" + Environment.NewLine +
                       "Allegoric Alaskans;Blithering Badgers;win"
                       .Trim();
        var expected = "Team                           | MP |  W |  D |  L |  P" + Environment.NewLine +
                       "Allegoric Alaskans             |  2 |  1 |  0 |  1 |  3" + Environment.NewLine +
                       "Blithering Badgers             |  2 |  1 |  0 |  1 |  3"
                       .Trim();
        Assert.Equal(expected, RunTally(input).Trim());
    }

    [Fact(Skip = "Remove to run test")]
    public void There_can_be_more_than_two_teams()
    {
        var input = "Allegoric Alaskans;Blithering Badgers;win" + Environment.NewLine +
                       "Blithering Badgers;Courageous Californians;win" + Environment.NewLine +
                       "Courageous Californians;Allegoric Alaskans;loss"
                       .Trim();
        var expected = "Team                           | MP |  W |  D |  L |  P" + Environment.NewLine +
                       "Allegoric Alaskans             |  2 |  2 |  0 |  0 |  6" + Environment.NewLine +
                       "Blithering Badgers             |  2 |  1 |  0 |  1 |  3" + Environment.NewLine +
                       "Courageous Californians        |  2 |  0 |  0 |  2 |  0"
                       .Trim();
        Assert.Equal(expected, RunTally(input).Trim());
    }

    [Fact(Skip = "Remove to run test")]
    public void Typical_input()
    {
        var input = "Allegoric Alaskans;Blithering Badgers;win" + Environment.NewLine +
                       "Devastating Donkeys;Courageous Californians;draw" + Environment.NewLine +
                       "Devastating Donkeys;Allegoric Alaskans;win" + Environment.NewLine +
                       "Courageous Californians;Blithering Badgers;loss" + Environment.NewLine +
                       "Blithering Badgers;Devastating Donkeys;loss" + Environment.NewLine +
                       "Allegoric Alaskans;Courageous Californians;win"
                       .Trim();
        var expected = "Team                           | MP |  W |  D |  L |  P" + Environment.NewLine +
                       "Devastating Donkeys            |  3 |  2 |  1 |  0 |  7" + Environment.NewLine +
                       "Allegoric Alaskans             |  3 |  2 |  0 |  1 |  6" + Environment.NewLine +
                       "Blithering Badgers             |  3 |  1 |  0 |  2 |  3" + Environment.NewLine +
                       "Courageous Californians        |  3 |  0 |  1 |  2 |  1"
                       .Trim();
        Assert.Equal(expected, RunTally(input).Trim());
    }

    [Fact(Skip = "Remove to run test")]
    public void Incomplete_competition_not_all_pairs_have_played_()
    {
        var input = "Allegoric Alaskans;Blithering Badgers;loss" + Environment.NewLine +
                       "Devastating Donkeys;Allegoric Alaskans;loss" + Environment.NewLine +
                       "Courageous Californians;Blithering Badgers;draw" + Environment.NewLine +
                       "Allegoric Alaskans;Courageous Californians;win"
                       .Trim();
        var expected = "Team                           | MP |  W |  D |  L |  P" + Environment.NewLine +
                       "Allegoric Alaskans             |  3 |  2 |  0 |  1 |  6" + Environment.NewLine +
                       "Blithering Badgers             |  2 |  1 |  1 |  0 |  4" + Environment.NewLine +
                       "Courageous Californians        |  2 |  0 |  1 |  1 |  1" + Environment.NewLine +
                       "Devastating Donkeys            |  1 |  0 |  0 |  1 |  0"
                       .Trim();
        Assert.Equal(expected, RunTally(input).Trim());
    }

    [Fact(Skip = "Remove to run test")]
    public void Ties_broken_alphabetically()
    {
        var input = "Courageous Californians;Devastating Donkeys;win" + Environment.NewLine +
                       "Allegoric Alaskans;Blithering Badgers;win" + Environment.NewLine +
                       "Devastating Donkeys;Allegoric Alaskans;loss" + Environment.NewLine +
                       "Courageous Californians;Blithering Badgers;win" + Environment.NewLine +
                       "Blithering Badgers;Devastating Donkeys;draw" + Environment.NewLine +
                       "Allegoric Alaskans;Courageous Californians;draw"
                       .Trim();
        var expected = "Team                           | MP |  W |  D |  L |  P" + Environment.NewLine +
                       "Allegoric Alaskans             |  3 |  2 |  1 |  0 |  7" + Environment.NewLine +
                       "Courageous Californians        |  3 |  2 |  1 |  0 |  7" + Environment.NewLine +
                       "Blithering Badgers             |  3 |  0 |  1 |  2 |  1" + Environment.NewLine +
                       "Devastating Donkeys            |  3 |  0 |  1 |  2 |  1"
                       .Trim();
        Assert.Equal(expected, RunTally(input).Trim());
    }

    private string RunTally(string input)
    {
        var encoding = new UTF8Encoding();
        using (var inStream = new MemoryStream(encoding.GetBytes(input)))
        {
            using (var outStream = new MemoryStream())
            {
                Tournament.Tally(inStream, outStream);
                return encoding.GetString(outStream.ToArray());
            }
        }
    }
}