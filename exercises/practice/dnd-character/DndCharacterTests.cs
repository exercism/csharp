// This file was auto-generated based on version 1.1.0 of the canonical data.

using System.Collections.Generic;
using System.Linq;
using Xunit;

public class DndCharacterTests
{
    [Fact]
    public void Ability_modifier_for_score_3_is_minus_4()
    {
        Assert.Equal(-4, DndCharacter.Modifier(3));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Ability_modifier_for_score_4_is_minus_3()
    {
        Assert.Equal(-3, DndCharacter.Modifier(4));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Ability_modifier_for_score_5_is_minus_3()
    {
        Assert.Equal(-3, DndCharacter.Modifier(5));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Ability_modifier_for_score_6_is_minus_2()
    {
        Assert.Equal(-2, DndCharacter.Modifier(6));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Ability_modifier_for_score_7_is_minus_2()
    {
        Assert.Equal(-2, DndCharacter.Modifier(7));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Ability_modifier_for_score_8_is_minus_1()
    {
        Assert.Equal(-1, DndCharacter.Modifier(8));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Ability_modifier_for_score_9_is_minus_1()
    {
        Assert.Equal(-1, DndCharacter.Modifier(9));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Ability_modifier_for_score_10_is_0()
    {
        Assert.Equal(0, DndCharacter.Modifier(10));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Ability_modifier_for_score_11_is_0()
    {
        Assert.Equal(0, DndCharacter.Modifier(11));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Ability_modifier_for_score_12_is_1()
    {
        Assert.Equal(1, DndCharacter.Modifier(12));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Ability_modifier_for_score_13_is_1()
    {
        Assert.Equal(1, DndCharacter.Modifier(13));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Ability_modifier_for_score_14_is_2()
    {
        Assert.Equal(2, DndCharacter.Modifier(14));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Ability_modifier_for_score_15_is_2()
    {
        Assert.Equal(2, DndCharacter.Modifier(15));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Ability_modifier_for_score_16_is_3()
    {
        Assert.Equal(3, DndCharacter.Modifier(16));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Ability_modifier_for_score_17_is_3()
    {
        Assert.Equal(3, DndCharacter.Modifier(17));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Ability_modifier_for_score_18_is_4()
    {
        Assert.Equal(4, DndCharacter.Modifier(18));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Random_ability_is_within_range()
    {
        for (var i = 0; i < 10; i++)
        {
            Assert.InRange(DndCharacter.Ability(), 3, 18);
        }
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
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

    [Fact(Skip = "Remove this Skip property to run this test")]
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

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Random_ability_is_distributed_correctly()
    {
        var expectedDistribution = new Dictionary<int, int>
        {
            [3] = 1,        [4] = 4,
            [5] = 10,       [6] = 21,
            [7] = 38,       [8] = 62,
            [9] = 91,       [10] = 122,
            [11] = 148,     [12] = 167,
            [13] = 172,     [14] = 160,
            [15] = 131,     [16] = 94,
            [17] = 54,      [18] = 21
        };
        var actualDistribution = new Dictionary<int, int>();
        const int times = 100;
        const int possibleCombinationsCount = 6*6*6*6; // 4d6
        for (var i = 3; i <= 18; i++)
            actualDistribution[i] = 0;
        for (var i = 0; i < times * possibleCombinationsCount; i++)
        {
            var ability = DndCharacter.Ability();
            actualDistribution[ability]++;
        }
        int min(int expected) => (int)(expected * (times * 0.8));
        int max(int expected) => (int)(expected * (times * 1.2));
        foreach (var k in expectedDistribution.Keys)
            Assert.InRange(actualDistribution[k], min(expectedDistribution[k]), max(expectedDistribution[k]));
    }
}