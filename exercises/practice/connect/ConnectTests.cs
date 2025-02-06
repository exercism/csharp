using Xunit;

public class ConnectTests
{
    [Fact]
    public void An_empty_board_has_no_winner()
    {
        string[] board = [
            ". . . . .",
            " . . . . .",
            "  . . . . .",
            "   . . . . .",
            "    . . . . ."
        ];
        var sut = new Connect(board);
        Assert.Equal(ConnectWinner.None, sut.Result());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void X_can_win_on_a_1x1_board()
    {
        string[] board = [
            "X"
        ];
        var sut = new Connect(board);
        Assert.Equal(ConnectWinner.Black, sut.Result());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void O_can_win_on_a_1x1_board()
    {
        string[] board = [
            "O"
        ];
        var sut = new Connect(board);
        Assert.Equal(ConnectWinner.White, sut.Result());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Only_edges_does_not_make_a_winner()
    {
        string[] board = [
            "O O O X",
            " X . . X",
            "  X . . X",
            "   X O O O"
        ];
        var sut = new Connect(board);
        Assert.Equal(ConnectWinner.None, sut.Result());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Illegal_diagonal_does_not_make_a_winner()
    {
        string[] board = [
            "X O . .",
            " O X X X",
            "  O X O .",
            "   . O X .",
            "    X X O O"
        ];
        var sut = new Connect(board);
        Assert.Equal(ConnectWinner.None, sut.Result());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Nobody_wins_crossing_adjacent_angles()
    {
        string[] board = [
            "X . . .",
            " . X O .",
            "  O . X O",
            "   . O . X",
            "    . . O ."
        ];
        var sut = new Connect(board);
        Assert.Equal(ConnectWinner.None, sut.Result());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void X_wins_crossing_from_left_to_right()
    {
        string[] board = [
            ". O . .",
            " O X X X",
            "  O X O .",
            "   X X O X",
            "    . O X ."
        ];
        var sut = new Connect(board);
        Assert.Equal(ConnectWinner.Black, sut.Result());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void O_wins_crossing_from_top_to_bottom()
    {
        string[] board = [
            ". O . .",
            " O X X X",
            "  O O O .",
            "   X X O X",
            "    . O X ."
        ];
        var sut = new Connect(board);
        Assert.Equal(ConnectWinner.White, sut.Result());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void X_wins_using_a_convoluted_path()
    {
        string[] board = [
            ". X X . .",
            " X . X . X",
            "  . X . X .",
            "   . X X . .",
            "    O O O O O"
        ];
        var sut = new Connect(board);
        Assert.Equal(ConnectWinner.Black, sut.Result());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void X_wins_using_a_spiral_path()
    {
        string[] board = [
            "O X X X X X X X X",
            " O X O O O O O O O",
            "  O X O X X X X X O",
            "   O X O X O O O X O",
            "    O X O X X X O X O",
            "     O X O O O X O X O",
            "      O X X X X X O X O",
            "       O O O O O O O X O",
            "        X X X X X X X X O"
        ];
        var sut = new Connect(board);
        Assert.Equal(ConnectWinner.Black, sut.Result());
    }
}
