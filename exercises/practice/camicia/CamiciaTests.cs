using Xunit;

public class CamiciaTests
{
    [Fact]
    public void Two_cards_one_trick()
    {
        string[] playerA = { "2" };
        string[] playerB = { "3" };
        Camicia.GameResult expected = new(Camicia.GameStatus.Finished, 1, 2);
        Assert.Equal(expected, Camicia.SimulateGame(playerA, playerB));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Three_cards_one_trick()
    {
        string[] playerA = { "2", "4" };
        string[] playerB = { "3" };
        Camicia.GameResult expected = new(Camicia.GameStatus.Finished, 1, 3);
        Assert.Equal(expected, Camicia.SimulateGame(playerA, playerB));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Four_cards_one_trick()
    {
        string[] playerA = { "2", "4" };
        string[] playerB = { "3", "5", "6" };
        Camicia.GameResult expected = new(Camicia.GameStatus.Finished, 1, 4);
        Assert.Equal(expected, Camicia.SimulateGame(playerA, playerB));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void The_ace_reigns_supreme()
    {
        string[] playerA = { "2", "A" };
        string[] playerB = { "3", "4", "5", "6", "7" };
        Camicia.GameResult expected = new(Camicia.GameStatus.Finished, 1, 7);
        Assert.Equal(expected, Camicia.SimulateGame(playerA, playerB));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void The_king_beats_ace()
    {
        string[] playerA = { "2", "A" };
        string[] playerB = { "3", "4", "5", "6", "K" };
        Camicia.GameResult expected = new(Camicia.GameStatus.Finished, 1, 7);
        Assert.Equal(expected, Camicia.SimulateGame(playerA, playerB));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void The_queen_seduces_the_king()
    {
        string[] playerA = { "2", "A", "7", "8", "Q" };
        string[] playerB = { "3", "4", "5", "6", "K" };
        Camicia.GameResult expected = new(Camicia.GameStatus.Finished, 1, 10);
        Assert.Equal(expected, Camicia.SimulateGame(playerA, playerB));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void The_jack_betrays_the_queen()
    {
        string[] playerA = { "2", "A", "7", "8", "Q" };
        string[] playerB = { "3", "4", "5", "6", "K", "9", "J" };
        Camicia.GameResult expected = new(Camicia.GameStatus.Finished, 1, 12);
        Assert.Equal(expected, Camicia.SimulateGame(playerA, playerB));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void The_10_just_wants_to_put_on_a_show()
    {
        string[] playerA = { "2", "A", "7", "8", "Q", "10" };
        string[] playerB = { "3", "4", "5", "6", "K", "9", "J" };
        Camicia.GameResult expected = new(Camicia.GameStatus.Finished, 1, 13);
        Assert.Equal(expected, Camicia.SimulateGame(playerA, playerB));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Simple_loop_with_decks_of_3_cards()
    {
        string[] playerA = { "J", "2", "3" };
        string[] playerB = { "4", "J", "5" };
        Camicia.GameResult expected = new(Camicia.GameStatus.Loop, 3, 8);
        Assert.Equal(expected, Camicia.SimulateGame(playerA, playerB));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void The_story_is_starting_to_get_a_bit_complicated()
    {
        string[] playerA = { "2", "6", "6", "J", "4", "K", "Q", "10", "K", "J", "Q", "2", "3", "K", "5", "6", "Q", "Q", "A", "A", "6", "9", "K", "A", "8", "K", "2", "A", "9", "A", "Q", "4", "K", "K", "K", "3", "5", "K", "8", "Q", "3", "Q", "7", "J", "K", "J", "9", "J", "3", "3", "K", "K", "Q", "A", "K", "7", "10", "A", "Q", "7", "10", "J", "4", "5", "J", "9", "10", "Q", "J", "J", "K", "6", "10", "J", "6", "Q", "J", "5", "J", "Q", "Q", "8", "3", "8", "A", "2", "6", "9", "K", "7", "J", "K", "K", "8", "K", "Q", "6", "10", "J", "10", "J", "Q", "J", "10", "3", "8", "K", "A", "6", "9", "K", "2", "A", "A", "10", "J", "6", "A", "4", "J", "A", "J", "J", "6", "2", "J", "3", "K", "2", "5", "9", "J", "9", "6", "K", "A", "5", "Q", "J", "2", "Q", "K", "A", "3", "K", "J", "K", "2", "5", "6", "Q", "J", "Q", "Q", "J", "2", "J", "9", "Q", "7", "7", "A", "Q", "7", "Q", "J", "K", "J", "A", "7", "7", "8", "Q", "10", "J", "10", "J", "J", "9", "2", "A", "2" };
        string[] playerB = { "7", "2", "10", "K", "8", "2", "J", "9", "A", "5", "6", "J", "Q", "6", "K", "6", "5", "A", "4", "Q", "7", "J", "7", "10", "2", "Q", "8", "2", "2", "K", "J", "A", "5", "5", "A", "4", "Q", "6", "Q", "K", "10", "8", "Q", "2", "10", "J", "A", "Q", "8", "Q", "Q", "J", "J", "A", "A", "9", "10", "J", "K", "4", "Q", "10", "10", "J", "K", "10", "2", "J", "7", "A", "K", "K", "J", "A", "J", "10", "8", "K", "A", "7", "Q", "Q", "J", "3", "Q", "4", "A", "3", "A", "Q", "Q", "Q", "5", "4", "K", "J", "10", "A", "Q", "J", "6", "J", "A", "10", "A", "5", "8", "3", "K", "5", "9", "Q", "8", "7", "7", "J", "7", "Q", "Q", "Q", "A", "7", "8", "9", "A", "Q", "A", "K", "8", "A", "A", "J", "8", "4", "8", "K", "J", "A", "10", "Q", "8", "J", "8", "6", "10", "Q", "J", "J", "A", "A", "J", "5", "Q", "6", "J", "K", "Q", "8", "K", "4", "Q", "Q", "6", "J", "K", "4", "7", "J", "J", "9", "9", "A", "Q", "Q", "K", "A", "6", "5", "K" };
        Camicia.GameResult expected = new(Camicia.GameStatus.Finished, 1, 361);
        Assert.Equal(expected, Camicia.SimulateGame(playerA, playerB));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Two_tricks()
    {
        string[] playerA = { "J" };
        string[] playerB = { "3", "J" };
        Camicia.GameResult expected = new(Camicia.GameStatus.Finished, 2, 5);
        Assert.Equal(expected, Camicia.SimulateGame(playerA, playerB));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void More_tricks()
    {
        string[] playerA = { "J", "2", "4" };
        string[] playerB = { "3", "J", "A" };
        Camicia.GameResult expected = new(Camicia.GameStatus.Finished, 4, 12);
        Assert.Equal(expected, Camicia.SimulateGame(playerA, playerB));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Simple_loop_with_decks_of_4_cards()
    {
        string[] playerA = { "2", "3", "J", "6" };
        string[] playerB = { "K", "5", "J", "7" };
        Camicia.GameResult expected = new(Camicia.GameStatus.Loop, 4, 16);
        Assert.Equal(expected, Camicia.SimulateGame(playerA, playerB));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Easy_card_combination()
    {
        string[] playerA = { "4", "8", "7", "5", "4", "10", "3", "9", "7", "3", "10", "10", "6", "8", "2", "8", "5", "4", "5", "9", "6", "5", "2", "8", "10", "9" };
        string[] playerB = { "6", "9", "4", "7", "2", "2", "3", "6", "7", "3", "A", "A", "A", "A", "K", "K", "K", "K", "Q", "Q", "Q", "Q", "J", "J", "J", "J" };
        Camicia.GameResult expected = new(Camicia.GameStatus.Finished, 4, 40);
        Assert.Equal(expected, Camicia.SimulateGame(playerA, playerB));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Easy_card_combination_inverted_decks()
    {
        string[] playerA = { "3", "3", "5", "7", "3", "2", "10", "7", "6", "7", "A", "A", "A", "A", "K", "K", "K", "K", "Q", "Q", "Q", "Q", "J", "J", "J", "J" };
        string[] playerB = { "5", "10", "8", "2", "6", "7", "2", "4", "9", "2", "6", "10", "10", "5", "4", "8", "4", "8", "6", "9", "8", "5", "9", "3", "4", "9" };
        Camicia.GameResult expected = new(Camicia.GameStatus.Finished, 4, 40);
        Assert.Equal(expected, Camicia.SimulateGame(playerA, playerB));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Mirrored_decks()
    {
        string[] playerA = { "2", "A", "3", "A", "3", "K", "4", "K", "2", "Q", "2", "Q", "10", "J", "5", "J", "6", "10", "2", "9", "10", "7", "3", "9", "6", "9" };
        string[] playerB = { "6", "A", "4", "A", "7", "K", "4", "K", "7", "Q", "7", "Q", "5", "J", "8", "J", "4", "5", "8", "9", "10", "6", "8", "3", "8", "5" };
        Camicia.GameResult expected = new(Camicia.GameStatus.Finished, 4, 59);
        Assert.Equal(expected, Camicia.SimulateGame(playerA, playerB));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Opposite_decks()
    {
        string[] playerA = { "4", "A", "9", "A", "4", "K", "9", "K", "6", "Q", "8", "Q", "8", "J", "10", "J", "9", "8", "4", "6", "3", "6", "5", "2", "4", "3" };
        string[] playerB = { "10", "7", "3", "2", "9", "2", "7", "8", "7", "5", "J", "7", "J", "10", "Q", "10", "Q", "3", "K", "5", "K", "6", "A", "2", "A", "5" };
        Camicia.GameResult expected = new(Camicia.GameStatus.Finished, 21, 151);
        Assert.Equal(expected, Camicia.SimulateGame(playerA, playerB));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Random_decks_1()
    {
        string[] playerA = { "K", "10", "9", "8", "J", "8", "6", "9", "7", "A", "K", "5", "4", "4", "J", "5", "J", "4", "3", "5", "8", "6", "7", "7", "4", "9" };
        string[] playerB = { "6", "3", "K", "A", "Q", "10", "A", "2", "Q", "8", "2", "10", "10", "2", "Q", "3", "K", "9", "7", "A", "3", "Q", "5", "J", "2", "6" };
        Camicia.GameResult expected = new(Camicia.GameStatus.Finished, 76, 542);
        Assert.Equal(expected, Camicia.SimulateGame(playerA, playerB));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Random_decks_2()
    {
        string[] playerA = { "8", "A", "4", "8", "5", "Q", "J", "2", "6", "2", "9", "7", "K", "A", "8", "10", "K", "8", "10", "9", "K", "6", "7", "3", "K", "9" };
        string[] playerB = { "10", "5", "2", "6", "Q", "J", "A", "9", "5", "5", "3", "7", "3", "J", "A", "2", "Q", "3", "J", "Q", "4", "10", "4", "7", "4", "6" };
        Camicia.GameResult expected = new(Camicia.GameStatus.Finished, 42, 327);
        Assert.Equal(expected, Camicia.SimulateGame(playerA, playerB));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Kleber_1999()
    {
        string[] playerA = { "4", "8", "9", "J", "Q", "8", "5", "5", "K", "2", "A", "9", "8", "5", "10", "A", "4", "J", "3", "K", "6", "9", "2", "Q", "K", "7" };
        string[] playerB = { "10", "J", "3", "2", "4", "10", "4", "7", "5", "3", "6", "6", "7", "A", "J", "Q", "A", "7", "2", "10", "3", "K", "9", "6", "8", "Q" };
        Camicia.GameResult expected = new(Camicia.GameStatus.Finished, 805, 5790);
        Assert.Equal(expected, Camicia.SimulateGame(playerA, playerB));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Collins_2006()
    {
        string[] playerA = { "A", "8", "Q", "K", "9", "10", "3", "7", "4", "2", "Q", "3", "2", "10", "9", "K", "A", "8", "7", "7", "4", "5", "J", "9", "2", "10" };
        string[] playerB = { "4", "J", "A", "K", "8", "5", "6", "6", "A", "6", "5", "Q", "4", "6", "10", "8", "J", "2", "5", "7", "Q", "J", "3", "3", "K", "9" };
        Camicia.GameResult expected = new(Camicia.GameStatus.Finished, 960, 6913);
        Assert.Equal(expected, Camicia.SimulateGame(playerA, playerB));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Mann_and_wu_2007()
    {
        string[] playerA = { "K", "2", "K", "K", "3", "3", "6", "10", "K", "6", "A", "2", "5", "5", "7", "9", "J", "A", "A", "3", "4", "Q", "4", "8", "J", "6" };
        string[] playerB = { "4", "5", "2", "Q", "7", "9", "9", "Q", "7", "J", "9", "8", "10", "3", "10", "J", "4", "10", "8", "6", "8", "7", "A", "Q", "5", "2" };
        Camicia.GameResult expected = new(Camicia.GameStatus.Finished, 1007, 7157);
        Assert.Equal(expected, Camicia.SimulateGame(playerA, playerB));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Nessler_2012()
    {
        string[] playerA = { "10", "3", "6", "7", "Q", "2", "9", "8", "2", "8", "4", "A", "10", "6", "K", "2", "10", "A", "5", "A", "2", "4", "Q", "J", "K", "4" };
        string[] playerB = { "10", "Q", "4", "6", "J", "9", "3", "J", "9", "3", "3", "Q", "K", "5", "9", "5", "K", "6", "5", "7", "8", "J", "A", "7", "8", "7" };
        Camicia.GameResult expected = new(Camicia.GameStatus.Finished, 1015, 7207);
        Assert.Equal(expected, Camicia.SimulateGame(playerA, playerB));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Anderson_2013()
    {
        string[] playerA = { "6", "7", "A", "3", "Q", "3", "5", "J", "3", "2", "J", "7", "4", "5", "Q", "10", "5", "A", "J", "2", "K", "8", "9", "9", "K", "3" };
        string[] playerB = { "4", "J", "6", "9", "8", "5", "10", "7", "9", "Q", "2", "7", "10", "8", "4", "10", "A", "6", "4", "A", "6", "8", "Q", "K", "K", "2" };
        Camicia.GameResult expected = new(Camicia.GameStatus.Finished, 1016, 7225);
        Assert.Equal(expected, Camicia.SimulateGame(playerA, playerB));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Rucklidge_2014()
    {
        string[] playerA = { "8", "J", "2", "9", "4", "4", "5", "8", "Q", "3", "9", "3", "6", "2", "8", "A", "A", "A", "9", "4", "7", "2", "5", "Q", "Q", "3" };
        string[] playerB = { "K", "7", "10", "6", "3", "J", "A", "7", "6", "5", "5", "8", "10", "9", "10", "4", "2", "7", "K", "Q", "10", "K", "6", "J", "J", "K" };
        Camicia.GameResult expected = new(Camicia.GameStatus.Finished, 1122, 7959);
        Assert.Equal(expected, Camicia.SimulateGame(playerA, playerB));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Nessler_2021()
    {
        string[] playerA = { "7", "2", "3", "4", "K", "9", "6", "10", "A", "8", "9", "Q", "7", "A", "4", "8", "J", "J", "A", "4", "3", "2", "5", "6", "6", "J" };
        string[] playerB = { "3", "10", "8", "9", "8", "K", "K", "2", "5", "5", "7", "6", "4", "3", "5", "7", "A", "9", "J", "K", "2", "Q", "10", "Q", "10", "Q" };
        Camicia.GameResult expected = new(Camicia.GameStatus.Finished, 1106, 7972);
        Assert.Equal(expected, Camicia.SimulateGame(playerA, playerB));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Nessler_2022()
    {
        string[] playerA = { "2", "10", "10", "A", "J", "3", "8", "Q", "2", "5", "5", "5", "9", "2", "4", "3", "10", "Q", "A", "K", "Q", "J", "J", "9", "Q", "K" };
        string[] playerB = { "10", "7", "6", "3", "6", "A", "8", "9", "4", "3", "K", "J", "6", "K", "4", "9", "7", "8", "5", "7", "8", "2", "A", "7", "4", "6" };
        Camicia.GameResult expected = new(Camicia.GameStatus.Finished, 1164, 8344);
        Assert.Equal(expected, Camicia.SimulateGame(playerA, playerB));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Casella_2024_first_infinite_game_found()
    {
        string[] playerA = { "2", "8", "4", "K", "5", "2", "3", "Q", "6", "K", "Q", "A", "J", "3", "5", "9", "8", "3", "A", "A", "J", "4", "4", "J", "7", "5" };
        string[] playerB = { "7", "7", "8", "6", "10", "10", "6", "10", "7", "2", "Q", "6", "3", "2", "4", "K", "Q", "10", "J", "5", "9", "8", "9", "9", "K", "A" };
        Camicia.GameResult expected = new(Camicia.GameStatus.Loop, 66, 474);
        Assert.Equal(expected, Camicia.SimulateGame(playerA, playerB));
    }
}
