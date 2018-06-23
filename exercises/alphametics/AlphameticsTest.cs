// This file was auto-generated based on version 1.2.0 of the canonical data.

using System;
using System.Collections.Generic;
using Xunit;

public class AlphameticsTest
{
    [Fact]
    public void Puzzle_with_three_letters()
    {
        var actual = Alphametics.Solve("I + BB == ILL");
        var expected = new Dictionary<char, int>
        {
            ['I'] = 1,
            ['B'] = 9,
            ['L'] = 0
        };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Solution_must_have_unique_value_for_each_letter()
    {
        Assert.Throws<ArgumentException>(() => Alphametics.Solve("A == B"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Leading_zero_solution_is_invalid()
    {
        Assert.Throws<ArgumentException>(() => Alphametics.Solve("ACA + DD == BD"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Puzzle_with_four_letters()
    {
        var actual = Alphametics.Solve("AS + A == MOM");
        var expected = new Dictionary<char, int>
        {
            ['A'] = 9,
            ['S'] = 2,
            ['M'] = 1,
            ['O'] = 0
        };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Puzzle_with_six_letters()
    {
        var actual = Alphametics.Solve("NO + NO + TOO == LATE");
        var expected = new Dictionary<char, int>
        {
            ['N'] = 7,
            ['O'] = 4,
            ['T'] = 9,
            ['L'] = 1,
            ['A'] = 0,
            ['E'] = 2
        };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Puzzle_with_seven_letters()
    {
        var actual = Alphametics.Solve("HE + SEES + THE == LIGHT");
        var expected = new Dictionary<char, int>
        {
            ['E'] = 4,
            ['G'] = 2,
            ['H'] = 5,
            ['I'] = 0,
            ['L'] = 1,
            ['S'] = 9,
            ['T'] = 7
        };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Puzzle_with_eight_letters()
    {
        var actual = Alphametics.Solve("SEND + MORE == MONEY");
        var expected = new Dictionary<char, int>
        {
            ['S'] = 9,
            ['E'] = 5,
            ['N'] = 6,
            ['D'] = 7,
            ['M'] = 1,
            ['O'] = 0,
            ['R'] = 8,
            ['Y'] = 2
        };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Puzzle_with_ten_letters()
    {
        var actual = Alphametics.Solve("AND + A + STRONG + OFFENSE + AS + A + GOOD == DEFENSE");
        var expected = new Dictionary<char, int>
        {
            ['A'] = 5,
            ['D'] = 3,
            ['E'] = 4,
            ['F'] = 7,
            ['G'] = 8,
            ['N'] = 0,
            ['O'] = 2,
            ['R'] = 1,
            ['S'] = 6,
            ['T'] = 9
        };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Puzzle_with_ten_letters_and_199_addends()
    {
        var actual = Alphametics.Solve("THIS + A + FIRE + THEREFORE + FOR + ALL + HISTORIES + I + TELL + A + TALE + THAT + FALSIFIES + ITS + TITLE + TIS + A + LIE + THE + TALE + OF + THE + LAST + FIRE + HORSES + LATE + AFTER + THE + FIRST + FATHERS + FORESEE + THE + HORRORS + THE + LAST + FREE + TROLL + TERRIFIES + THE + HORSES + OF + FIRE + THE + TROLL + RESTS + AT + THE + HOLE + OF + LOSSES + IT + IS + THERE + THAT + SHE + STORES + ROLES + OF + LEATHERS + AFTER + SHE + SATISFIES + HER + HATE + OFF + THOSE + FEARS + A + TASTE + RISES + AS + SHE + HEARS + THE + LEAST + FAR + HORSE + THOSE + FAST + HORSES + THAT + FIRST + HEAR + THE + TROLL + FLEE + OFF + TO + THE + FOREST + THE + HORSES + THAT + ALERTS + RAISE + THE + STARES + OF + THE + OTHERS + AS + THE + TROLL + ASSAILS + AT + THE + TOTAL + SHIFT + HER + TEETH + TEAR + HOOF + OFF + TORSO + AS + THE + LAST + HORSE + FORFEITS + ITS + LIFE + THE + FIRST + FATHERS + HEAR + OF + THE + HORRORS + THEIR + FEARS + THAT + THE + FIRES + FOR + THEIR + FEASTS + ARREST + AS + THE + FIRST + FATHERS + RESETTLE + THE + LAST + OF + THE + FIRE + HORSES + THE + LAST + TROLL + HARASSES + THE + FOREST + HEART + FREE + AT + LAST + OF + THE + LAST + TROLL + ALL + OFFER + THEIR + FIRE + HEAT + TO + THE + ASSISTERS + FAR + OFF + THE + TROLL + FASTS + ITS + LIFE + SHORTER + AS + STARS + RISE + THE + HORSES + REST + SAFE + AFTER + ALL + SHARE + HOT + FISH + AS + THEIR + AFFILIATES + TAILOR + A + ROOFS + FOR + THEIR + SAFE == FORTRESSES");
        var expected = new Dictionary<char, int>
        {
            ['A'] = 1,
            ['E'] = 0,
            ['F'] = 5,
            ['H'] = 8,
            ['I'] = 7,
            ['L'] = 2,
            ['O'] = 6,
            ['R'] = 3,
            ['S'] = 4,
            ['T'] = 9
        };
        Assert.Equal(expected, actual);
    }
}