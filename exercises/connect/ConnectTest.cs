// This file was auto-generated based on version 1.1.0 of the canonical data.

using Xunit;

public class ConnectTest
{
    [Fact]
    public void An_empty_board_has_no_winner()
    {
        var board = new[]
        {
            ". . . . .",
            " . . . . .",
            "  . . . . .",
            "   . . . . .",
            "    . . . . ."
        };
        var sut = new Connect(board);
        Assert.Equal(ConnectWinner.None, sut.Result());
    }

    [Fact(Skip = "Remove to run test")]
    public void X_can_win_on_a_1x1_board()
    {
        var board = new[]
        {
            "X"
        };
        var sut = new Connect(board);
        Assert.Equal(ConnectWinner.Black, sut.Result());
    }

    [Fact(Skip = "Remove to run test")]
    public void O_can_win_on_a_1x1_board()
    {
        var board = new[]
        {
            "O"
        };
        var sut = new Connect(board);
        Assert.Equal(ConnectWinner.White, sut.Result());
    }

    [Fact(Skip = "Remove to run test")]
    public void Only_edges_does_not_make_a_winner()
    {
        var board = new[]
        {
            "O O O X",
            " X . . X",
            "  X . . X",
            "   X O O O"
        };
        var sut = new Connect(board);
        Assert.Equal(ConnectWinner.None, sut.Result());
    }

    [Fact(Skip = "Remove to run test")]
    public void Illegal_diagonal_does_not_make_a_winner()
    {
        var board = new[]
        {
            "X O . .",
            " O X X X",
            "  O X O .",
            "   . O X .",
            "    X X O O"
        };
        var sut = new Connect(board);
        Assert.Equal(ConnectWinner.None, sut.Result());
    }

    [Fact(Skip = "Remove to run test")]
    public void Nobody_wins_crossing_adjacent_angles()
    {
        var board = new[]
        {
            "X . . .",
            " . X O .",
            "  O . X O",
            "   . O . X",
            "    . . O ."
        };
        var sut = new Connect(board);
        Assert.Equal(ConnectWinner.None, sut.Result());
    }

    [Fact(Skip = "Remove to run test")]
    public void X_wins_crossing_from_left_to_right()
    {
        var board = new[]
        {
            ". O . .",
            " O X X X",
            "  O X O .",
            "   X X O X",
            "    . O X ."
        };
        var sut = new Connect(board);
        Assert.Equal(ConnectWinner.Black, sut.Result());
    }

    [Fact(Skip = "Remove to run test")]
    public void O_wins_crossing_from_top_to_bottom()
    {
        var board = new[]
        {
            ". O . .",
            " O X X X",
            "  O O O .",
            "   X X O X",
            "    . O X ."
        };
        var sut = new Connect(board);
        Assert.Equal(ConnectWinner.White, sut.Result());
    }

    [Fact(Skip = "Remove to run test")]
    public void X_wins_using_a_convoluted_path()
    {
        var board = new[]
        {
            ". X X . .",
            " X . X . X",
            "  . X . X .",
            "   . X X . .",
            "    O O O O O"
        };
        var sut = new Connect(board);
        Assert.Equal(ConnectWinner.Black, sut.Result());
    }

    [Fact(Skip = "Remove to run test")]
    public void X_wins_using_a_spiral_path()
    {
        var board = new[]
        {
            "O X X X X X X X X",
            " O X O O O O O O O",
            "  O X O X X X X X O",
            "   O X O X O O O X O",
            "    O X O X X X O X O",
            "     O X O O O X O X O",
            "      O X X X X X O X O",
            "       O O O O O O O X O",
            "        X X X X X X X X O"
        };
        var sut = new Connect(board);
        Assert.Equal(ConnectWinner.Black, sut.Result());
    }
}