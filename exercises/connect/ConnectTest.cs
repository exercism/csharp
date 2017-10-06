// This file was auto-generated based on version 1.0.0 of the canonical data.

using Xunit;

public class ConnectTest
{
    [Fact]
    public void An_empty_board_has_no_winner()
    {
        var board = new[] { ".....", ".....", ".....", ".....", "....." };
        var sut = new Connect(board);
        Assert.Equal(ConnectWinner.None, sut.Result());
    }

    [Fact(Skip = "Remove to run test")]
    public void X_can_win_on_a_1x1_board()
    {
        var board = new[] { "X" };
        var sut = new Connect(board);
        Assert.Equal(ConnectWinner.Black, sut.Result());
    }

    [Fact(Skip = "Remove to run test")]
    public void O_can_win_on_a_1x1_board()
    {
        var board = new[] { "O" };
        var sut = new Connect(board);
        Assert.Equal(ConnectWinner.White, sut.Result());
    }

    [Fact(Skip = "Remove to run test")]
    public void Only_edges_does_not_make_a_winner()
    {
        var board = new[] { "OOOX", "X..X", "X..X", "XOOO" };
        var sut = new Connect(board);
        Assert.Equal(ConnectWinner.None, sut.Result());
    }

    [Fact(Skip = "Remove to run test")]
    public void Illegal_diagonal_does_not_make_a_winner()
    {
        var board = new[] { "XO..", "OXXX", "OXO.", ".OX.", "XXOO" };
        var sut = new Connect(board);
        Assert.Equal(ConnectWinner.None, sut.Result());
    }

    [Fact(Skip = "Remove to run test")]
    public void Nobody_wins_crossing_adjacent_angles()
    {
        var board = new[] { "X...", ".XO.", "O.XO", ".O.X", "..O." };
        var sut = new Connect(board);
        Assert.Equal(ConnectWinner.None, sut.Result());
    }

    [Fact(Skip = "Remove to run test")]
    public void X_wins_crossing_from_left_to_right()
    {
        var board = new[] { ".O..", "OXXX", "OXO.", "XXOX", ".OX." };
        var sut = new Connect(board);
        Assert.Equal(ConnectWinner.Black, sut.Result());
    }

    [Fact(Skip = "Remove to run test")]
    public void O_wins_crossing_from_top_to_bottom()
    {
        var board = new[] { ".O..", "OXXX", "OOO.", "XXOX", ".OX." };
        var sut = new Connect(board);
        Assert.Equal(ConnectWinner.White, sut.Result());
    }

    [Fact(Skip = "Remove to run test")]
    public void X_wins_using_a_convoluted_path()
    {
        var board = new[] { ".XX..", "X.X.X", ".X.X.", ".XX..", "OOOOO" };
        var sut = new Connect(board);
        Assert.Equal(ConnectWinner.Black, sut.Result());
    }

    [Fact(Skip = "Remove to run test")]
    public void X_wins_using_a_spiral_path()
    {
        var board = new[] { "OXXXXXXXX", "OXOOOOOOO", "OXOXXXXXO", "OXOXOOOXO", "OXOXXXOXO", "OXOOOXOXO", "OXXXXXOXO", "OOOOOOOXO", "XXXXXXXXO" };
        var sut = new Connect(board);
        Assert.Equal(ConnectWinner.Black, sut.Result());
    }
}