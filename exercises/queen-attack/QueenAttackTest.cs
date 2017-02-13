using System;
using Xunit;

public class QueenAttackTest
{
    [Fact]
    public void Cannot_occupy_same_space()
    {
        var white = new Queen(2, 4);
        var black = new Queen(2, 4);
        Assert.Throws<ArgumentException>(() => Queens.CanAttack(white, black));
    }

    [Fact(Skip = "Remove to run test")]
    public void Cannot_attack()
    {
        Assert.False(Queens.CanAttack(new Queen(2, 3), new Queen(4, 7)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Can_attack_on_same_row()
    {
        Assert.True(Queens.CanAttack(new Queen(2, 4), new Queen(2, 7)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Can_attack_on_same_column()
    {
        Assert.True(Queens.CanAttack(new Queen(5, 4), new Queen(2, 4)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Can_attack_on_diagonal()
    {
        Assert.True(Queens.CanAttack(new Queen(1, 1), new Queen(6, 6)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Can_attack_on_other_diagonal()
    {
        Assert.True(Queens.CanAttack(new Queen(0, 6), new Queen(1, 7)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Can_attack_on_yet_another_diagonal()
    {
        Assert.True(Queens.CanAttack(new Queen(4, 1), new Queen(6, 3)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Can_attack_on_a_diagonal_slanted_the_other_way()
    {
        Assert.True(Queens.CanAttack(new Queen(6, 1), new Queen(1, 6)));
    }
}