// This file was auto-generated based on version 1.1.0 of the canonical data.

using System.Linq;
using Xunit;

public class DndCharacterTest
{
    [Fact]
    public void Ability_modifier_for_score_3_is_minus_4()
    {
        Assert.Equal(-4, DndCharacter.Modifier(3));
    }

    [Fact(Skip = "Remove to run test")]
    public void Ability_modifier_for_score_4_is_minus_3()
    {
        Assert.Equal(-3, DndCharacter.Modifier(4));
    }

    [Fact(Skip = "Remove to run test")]
    public void Ability_modifier_for_score_5_is_minus_3()
    {
        Assert.Equal(-3, DndCharacter.Modifier(5));
    }

    [Fact(Skip = "Remove to run test")]
    public void Ability_modifier_for_score_6_is_minus_2()
    {
        Assert.Equal(-2, DndCharacter.Modifier(6));
    }

    [Fact(Skip = "Remove to run test")]
    public void Ability_modifier_for_score_7_is_minus_2()
    {
        Assert.Equal(-2, DndCharacter.Modifier(7));
    }

    [Fact(Skip = "Remove to run test")]
    public void Ability_modifier_for_score_8_is_minus_1()
    {
        Assert.Equal(-1, DndCharacter.Modifier(8));
    }

    [Fact(Skip = "Remove to run test")]
    public void Ability_modifier_for_score_9_is_minus_1()
    {
        Assert.Equal(-1, DndCharacter.Modifier(9));
    }

    [Fact(Skip = "Remove to run test")]
    public void Ability_modifier_for_score_10_is_0()
    {
        Assert.Equal(0, DndCharacter.Modifier(10));
    }

    [Fact(Skip = "Remove to run test")]
    public void Ability_modifier_for_score_11_is_0()
    {
        Assert.Equal(0, DndCharacter.Modifier(11));
    }

    [Fact(Skip = "Remove to run test")]
    public void Ability_modifier_for_score_12_is_1()
    {
        Assert.Equal(1, DndCharacter.Modifier(12));
    }

    [Fact(Skip = "Remove to run test")]
    public void Ability_modifier_for_score_13_is_1()
    {
        Assert.Equal(1, DndCharacter.Modifier(13));
    }

    [Fact(Skip = "Remove to run test")]
    public void Ability_modifier_for_score_14_is_2()
    {
        Assert.Equal(2, DndCharacter.Modifier(14));
    }

    [Fact(Skip = "Remove to run test")]
    public void Ability_modifier_for_score_15_is_2()
    {
        Assert.Equal(2, DndCharacter.Modifier(15));
    }

    [Fact(Skip = "Remove to run test")]
    public void Ability_modifier_for_score_16_is_3()
    {
        Assert.Equal(3, DndCharacter.Modifier(16));
    }

    [Fact(Skip = "Remove to run test")]
    public void Ability_modifier_for_score_17_is_3()
    {
        Assert.Equal(3, DndCharacter.Modifier(17));
    }

    [Fact(Skip = "Remove to run test")]
    public void Ability_modifier_for_score_18_is_4()
    {
        Assert.Equal(4, DndCharacter.Modifier(18));
    }

    [Fact(Skip = "Remove to run test")]
    public void Random_ability_is_within_range()
    {
        for (var i = 0; i < 10; i++)
        {
            Assert.InRange(DndCharacter.Ability(), 3, 18);
        }
    }

    [Fact(Skip = "Remove to run test")]
    public void Random_character_is_valid()
    {
        for (var i = 0; i < 10; i++)
        {
            var sut = DndCharacter.Generate();
            Assert.InRange(sut.Strength, 3, 18);
            Assert.InRange(sut.Dexterity, 3, 18);
            Assert.InRange(sut.Constitution, 3, 18);
            Assert.InRange(sut.Intelligence, 3, 18);
            Assert.InRange(sut.Wisdom, 3, 18);
            Assert.InRange(sut.Charisma, 3, 18);
            Assert.Equal(sut.Hitpoints, 10 + DndCharacter.Modifier(sut.Constitution));
        }
    }

    [Fact(Skip = "Remove to run test")]
    public void Each_ability_is_only_calculated_once()
    {
        for (var i = 0; i < 10; i++)
        {
            var sut = DndCharacter.Generate();
            Assert.Equal(sut.Strength, sut.Strength);
            Assert.Equal(sut.Dexterity, sut.Dexterity);
            Assert.Equal(sut.Constitution, sut.Constitution);
            Assert.Equal(sut.Intelligence, sut.Intelligence);
            Assert.Equal(sut.Wisdom, sut.Wisdom);
            Assert.Equal(sut.Charisma, sut.Charisma);
        }
    }
}