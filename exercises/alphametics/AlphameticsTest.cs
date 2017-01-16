﻿using NUnit.Framework;
using System.Collections.Generic;

public class AlphameticsTest
{
    [Test]
    public void Puzzle_with_three_letters()
    {
        var actual = Alphametics.Solve("I + BB == ILL");
        var expected = new Dictionary<char, int>
        {
            ['I'] = 1,
            ['B'] = 9,
            ['L'] = 0
        };
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Solution_must_have_unique_value_for_each_letter()
    {
        Assert.That(() => Alphametics.Solve("A == B"), Throws.Exception);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Leading_zero_solution_is_invalid()
    {
        Assert.That(() => Alphametics.Solve("ACA + DD == BD"), Throws.Exception);
    }

    [Ignore("Remove to run test")]
    [Test]
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
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
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
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
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
            ['T'] = 7,
        };
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
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
            ['Y'] = 2,
        };
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
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
            ['T'] = 9,
        };
        Assert.That(actual, Is.EqualTo(expected));
    }
}
