// This file was auto-generated based on version 2.1.0 of the canonical data.

using System;
using Xunit;

public class QueenAttackTest
{
    [Fact]
    public void Queen_with_a_valid_position()
    {
        var actual = QueenAttack.Create(2, 2);
    }

    [Fact(Skip = "Remove to run test")]
    public void Queen_must_have_positive_row()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => QueenAttack.Create(-2, 2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Queen_must_have_row_on_board()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => QueenAttack.Create(8, 4));
    }

    [Fact(Skip = "Remove to run test")]
    public void Queen_must_have_positive_column()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => QueenAttack.Create(2, -2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Queen_must_have_column_on_board()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => QueenAttack.Create(4, 8));
    }

    [Fact(Skip = "Remove to run test")]
    public void Can_not_attack()
    {
        var whiteQueen = QueenAttack.Create(2,4);
        var blackQueen = QueenAttack.Create(6,6);
        Assert.False(QueenAttack.CanAttack(whiteQueen, blackQueen));
    }

    [Fact(Skip = "Remove to run test")]
    public void Can_attack_on_same_row()
    {
        var whiteQueen = QueenAttack.Create(2,4);
        var blackQueen = QueenAttack.Create(2,6);
        Assert.True(QueenAttack.CanAttack(whiteQueen, blackQueen));
    }

    [Fact(Skip = "Remove to run test")]
    public void Can_attack_on_same_column()
    {
        var whiteQueen = QueenAttack.Create(4,5);
        var blackQueen = QueenAttack.Create(2,5);
        Assert.True(QueenAttack.CanAttack(whiteQueen, blackQueen));
    }

    [Fact(Skip = "Remove to run test")]
    public void Can_attack_on_first_diagonal()
    {
        var whiteQueen = QueenAttack.Create(2,2);
        var blackQueen = QueenAttack.Create(0,4);
        Assert.True(QueenAttack.CanAttack(whiteQueen, blackQueen));
    }

    [Fact(Skip = "Remove to run test")]
    public void Can_attack_on_second_diagonal()
    {
        var whiteQueen = QueenAttack.Create(2,2);
        var blackQueen = QueenAttack.Create(3,1);
        Assert.True(QueenAttack.CanAttack(whiteQueen, blackQueen));
    }

    [Fact(Skip = "Remove to run test")]
    public void Can_attack_on_third_diagonal()
    {
        var whiteQueen = QueenAttack.Create(2,2);
        var blackQueen = QueenAttack.Create(1,1);
        Assert.True(QueenAttack.CanAttack(whiteQueen, blackQueen));
    }

    [Fact(Skip = "Remove to run test")]
    public void Can_attack_on_fourth_diagonal()
    {
        var whiteQueen = QueenAttack.Create(2,2);
        var blackQueen = QueenAttack.Create(5,5);
        Assert.True(QueenAttack.CanAttack(whiteQueen, blackQueen));
    }
}