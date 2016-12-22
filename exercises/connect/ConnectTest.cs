﻿using NUnit.Framework;
using System.Linq;

public class ConnectTest
{
    private static string MakeBoard(string[] board)
    {
        return string.Join("\n", board.Select(x => x.Replace(" ", "")));
    }

    [Test]
    public void Empty_board_has_no_winner()
    {
        var lines = new[] 
            {
                ". . . . .    ",
                " . . . . .   ",
                "  . . . . .  ",
                "   . . . . . ",
                "    . . . . ."
            };
        var board = new Connect(MakeBoard(lines));
        Assert.That(board.Result(), Is.EqualTo(Connect.Winner.None));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void One_by_one_board_with_black_stone()
    {
        var lines = new[] { "X" };
        var board = new Connect(MakeBoard(lines));
        Assert.That(board.Result(), Is.EqualTo(Connect.Winner.Black));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void One_by_one_board_with_white_stone()
    {
        var lines = new[] { "O" };
        var board = new Connect(MakeBoard(lines));
        Assert.That(board.Result(), Is.EqualTo(Connect.Winner.White));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Convoluted_path()
    {
        var lines = new[] 
            {
                ". X X . .    ",
                " X . X . X   ",
                "  . X . X .  ",
                "   . X X . . ",
                "    O O O O O"
            };
        var board = new Connect(MakeBoard(lines));
        Assert.That(board.Result(), Is.EqualTo(Connect.Winner.Black));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Rectangle_black_wins()
    {
        var lines = new[] 
            {
                ". O . .    ",
                " O X X X   ",
                "  O X O .  ",
                "   X X O X ",
                "    . O X ."
            };
        var board = new Connect(MakeBoard(lines));
        Assert.That(board.Result(), Is.EqualTo(Connect.Winner.Black));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Rectangle_white_wins()
    {
        var lines = new[] 
            {
                ". O . .    ",
                " O X X X   ",
                "  O O O .  ",
                "   X X O X ",
                "    . O X ."
            };
        var board = new Connect(MakeBoard(lines));
        Assert.That(board.Result(), Is.EqualTo(Connect.Winner.White));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Spiral_black_wins()
    {
        var lines = new[]
            {
            "OXXXXXXXX",
            "OXOOOOOOO",
            "OXOXXXXXO",
            "OXOXOOOXO",
            "OXOXXXOXO",
            "OXOOOXOXO",
            "OXXXXXOXO",
            "OOOOOOOXO",
            "XXXXXXXXO"
        };
        var board = new Connect(MakeBoard(lines));
        Assert.That(board.Result(), Is.EqualTo(Connect.Winner.Black));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Spiral_nobody_wins()
    {
        var lines = new[]
            {
            "OXXXXXXXX",
            "OXOOOOOOO",
            "OXOXXXXXO",
            "OXOXOOOXO",
            "OXOX.XOXO",
            "OXOOOXOXO",
            "OXXXXXOXO",
            "OOOOOOOXO",
            "XXXXXXXXO"
        };
        var board = new Connect(MakeBoard(lines));
        Assert.That(board.Result(), Is.EqualTo(Connect.Winner.None));
    }
}