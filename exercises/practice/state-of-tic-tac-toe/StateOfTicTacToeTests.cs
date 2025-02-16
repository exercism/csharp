using Xunit;

public class StateOfTicTacToeTests
{
    [Fact]
    public void Won_games_finished_game_where_x_won_via_left_column_victory()
    {
        string[] board = [
            "XOO",
            "X  ",
            "X  "
        ];
        var game = new TicTacToe(board);
        Assert.Equal(State.Win, game.State);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Won_games_finished_game_where_x_won_via_middle_column_victory()
    {
        string[] board = [
            "OXO",
            " X ",
            " X "
        ];
        var game = new TicTacToe(board);
        Assert.Equal(State.Win, game.State);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Won_games_finished_game_where_x_won_via_right_column_victory()
    {
        string[] board = [
            "OOX",
            "  X",
            "  X"
        ];
        var game = new TicTacToe(board);
        Assert.Equal(State.Win, game.State);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Won_games_finished_game_where_o_won_via_left_column_victory()
    {
        string[] board = [
            "OXX",
            "OX ",
            "O  "
        ];
        var game = new TicTacToe(board);
        Assert.Equal(State.Win, game.State);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Won_games_finished_game_where_o_won_via_middle_column_victory()
    {
        string[] board = [
            "XOX",
            " OX",
            " O "
        ];
        var game = new TicTacToe(board);
        Assert.Equal(State.Win, game.State);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Won_games_finished_game_where_o_won_via_right_column_victory()
    {
        string[] board = [
            "XXO",
            " XO",
            "  O"
        ];
        var game = new TicTacToe(board);
        Assert.Equal(State.Win, game.State);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Won_games_finished_game_where_x_won_via_top_row_victory()
    {
        string[] board = [
            "XXX",
            "XOO",
            "O  "
        ];
        var game = new TicTacToe(board);
        Assert.Equal(State.Win, game.State);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Won_games_finished_game_where_x_won_via_middle_row_victory()
    {
        string[] board = [
            "O  ",
            "XXX",
            " O "
        ];
        var game = new TicTacToe(board);
        Assert.Equal(State.Win, game.State);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Won_games_finished_game_where_x_won_via_bottom_row_victory()
    {
        string[] board = [
            " OO",
            "O X",
            "XXX"
        ];
        var game = new TicTacToe(board);
        Assert.Equal(State.Win, game.State);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Won_games_finished_game_where_o_won_via_top_row_victory()
    {
        string[] board = [
            "OOO",
            "XXO",
            "XX "
        ];
        var game = new TicTacToe(board);
        Assert.Equal(State.Win, game.State);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Won_games_finished_game_where_o_won_via_middle_row_victory()
    {
        string[] board = [
            "XX ",
            "OOO",
            "X  "
        ];
        var game = new TicTacToe(board);
        Assert.Equal(State.Win, game.State);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Won_games_finished_game_where_o_won_via_bottom_row_victory()
    {
        string[] board = [
            "XOX",
            " XX",
            "OOO"
        ];
        var game = new TicTacToe(board);
        Assert.Equal(State.Win, game.State);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Won_games_finished_game_where_x_won_via_falling_diagonal_victory()
    {
        string[] board = [
            "XOO",
            " X ",
            "  X"
        ];
        var game = new TicTacToe(board);
        Assert.Equal(State.Win, game.State);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Won_games_finished_game_where_x_won_via_rising_diagonal_victory()
    {
        string[] board = [
            "O X",
            "OX ",
            "X  "
        ];
        var game = new TicTacToe(board);
        Assert.Equal(State.Win, game.State);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Won_games_finished_game_where_o_won_via_falling_diagonal_victory()
    {
        string[] board = [
            "OXX",
            "OOX",
            "X O"
        ];
        var game = new TicTacToe(board);
        Assert.Equal(State.Win, game.State);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Won_games_finished_game_where_o_won_via_rising_diagonal_victory()
    {
        string[] board = [
            "  O",
            " OX",
            "OXX"
        ];
        var game = new TicTacToe(board);
        Assert.Equal(State.Win, game.State);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Won_games_finished_game_where_x_won_via_a_row_and_a_column_victory()
    {
        string[] board = [
            "XXX",
            "XOO",
            "XOO"
        ];
        var game = new TicTacToe(board);
        Assert.Equal(State.Win, game.State);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Won_games_finished_game_where_x_won_via_two_diagonal_victories()
    {
        string[] board = [
            "XOX",
            "OXO",
            "XOX"
        ];
        var game = new TicTacToe(board);
        Assert.Equal(State.Win, game.State);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Drawn_games_draw()
    {
        string[] board = [
            "XOX",
            "XXO",
            "OXO"
        ];
        var game = new TicTacToe(board);
        Assert.Equal(State.Draw, game.State);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Drawn_games_another_draw()
    {
        string[] board = [
            "XXO",
            "OXX",
            "XOO"
        ];
        var game = new TicTacToe(board);
        Assert.Equal(State.Draw, game.State);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Ongoing_games_ongoing_game_one_move_in()
    {
        string[] board = [
            "   ",
            "X  ",
            "   "
        ];
        var game = new TicTacToe(board);
        Assert.Equal(State.Ongoing, game.State);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Ongoing_games_ongoing_game_two_moves_in()
    {
        string[] board = [
            "O  ",
            " X ",
            "   "
        ];
        var game = new TicTacToe(board);
        Assert.Equal(State.Ongoing, game.State);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Ongoing_games_ongoing_game_five_moves_in()
    {
        string[] board = [
            "X  ",
            " XO",
            "OX "
        ];
        var game = new TicTacToe(board);
        Assert.Equal(State.Ongoing, game.State);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Invalid_boards_invalid_board_x_went_twice()
    {
        string[] board = [
            "XX ",
            "   ",
            "   "
        ];
        var game = new TicTacToe(board);
        Assert.Equal(State.Invalid, game.State);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Invalid_boards_invalid_board_o_started()
    {
        string[] board = [
            "OOX",
            "   ",
            "   "
        ];
        var game = new TicTacToe(board);
        Assert.Equal(State.Invalid, game.State);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Invalid_boards_invalid_board_x_won_and_o_kept_playing()
    {
        string[] board = [
            "XXX",
            "OOO",
            "   "
        ];
        var game = new TicTacToe(board);
        Assert.Equal(State.Invalid, game.State);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Invalid_boards_invalid_board_players_kept_playing_after_a_win()
    {
        string[] board = [
            "XXX",
            "OOO",
            "XOX"
        ];
        var game = new TicTacToe(board);
        Assert.Equal(State.Invalid, game.State);
    }
}
