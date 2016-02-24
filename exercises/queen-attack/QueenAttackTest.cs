using System;
using NUnit.Framework;

public class QueenAttackTest
{
    [Test]
    public void Cannot_occupy_same_space()
    {
        var white = new Queen(2, 4);
        var black = new Queen(2, 4);
        Assert.Throws<ArgumentException>(() => new Queens(white, black));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Cannot_attack()
    {
        var queens = new Queens(new Queen(2, 3), new Queen(4, 7));
        Assert.False(queens.CanAttack());
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Can_attack_on_same_row()
    {
        var queens = new Queens(new Queen(2, 4), new Queen(2, 7));
        Assert.True(queens.CanAttack());
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Can_attack_on_same_column()
    {
        var queens = new Queens(new Queen(5, 4), new Queen(2, 4));
        Assert.True(queens.CanAttack());
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Can_attack_on_diagonal()
    {
        var queens = new Queens(new Queen(1, 1), new Queen(6, 6));
        Assert.True(queens.CanAttack());
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Can_attack_on_other_diagonal()
    {
        var queens = new Queens(new Queen(0, 6), new Queen(1, 7));
        Assert.True(queens.CanAttack());
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Can_attack_on_yet_another_diagonal()
    {
        var queens = new Queens(new Queen(4, 1), new Queen(6, 3));
        Assert.True(queens.CanAttack());
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Can_attack_on_a_diagonal_slanted_the_other_way()
    {
        var queens = new Queens(new Queen(6, 1), new Queen(1, 6));
        Assert.True(queens.CanAttack());
    }
}