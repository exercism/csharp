using NUnit.Framework;

public class BowlingTest
{
    [Test]
    public void Gutter_game()
    {
        var game = new BowlingGame();
        RollMany(0, 20, game);
        Assert.That(game.Score(), Is.EqualTo(0));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void All_ones_game()
    {
        var game = new BowlingGame();
        RollMany(1, 20, game);
        Assert.That(game.Score(), Is.EqualTo(20));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void One_spare_game()
    {
        var game = new BowlingGame();
        RollSpare(game);
        game.Roll(3);
        RollMany(0, 17, game);

        Assert.That(game.Score(), Is.EqualTo(16));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void One_strike_game()
    {
        var game = new BowlingGame();
        RollStrike(game);
        game.Roll(3);
        game.Roll(4);
        RollMany(0, 16, game);

        Assert.That(game.Score(), Is.EqualTo(24));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Perfect_game()
    {
        var game = new BowlingGame();
        RollMany(10, 12, game);

        Assert.That(game.Score(), Is.EqualTo(300));
    }

    private static void RollMany(int pins, int count, BowlingGame game)
    {
        for (var i = 0; i < count; i++)
        {
            game.Roll(pins);
        }
    }

    private static void RollSpare(BowlingGame game)
    {
        game.Roll(5);
        game.Roll(5);
    }

    private static void RollStrike(BowlingGame game)
    {
        game.Roll(10);
    }
}