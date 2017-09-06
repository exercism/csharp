// This file was auto-generated based on version 1.0.0 of the canonical data.

using Xunit;

public class AllergiesTest
{
    [Fact]
    public void No_allergies_means_not_allergic()
    {
        var sut = new Allergies(0);
        Assert.False(sut.IsAllergicTo("peanuts"));
        Assert.False(sut.IsAllergicTo("cats"));
        Assert.False(sut.IsAllergicTo("strawberries"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Is_allergic_to_eggs()
    {
        var sut = new Allergies(1);
        Assert.True(sut.IsAllergicTo("eggs"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Allergic_to_eggs_in_addition_to_other_stuff()
    {
        var sut = new Allergies(5);
        Assert.True(sut.IsAllergicTo("eggs"));
        Assert.True(sut.IsAllergicTo("shellfish"));
        Assert.False(sut.IsAllergicTo("strawberries"));
    }

    [Fact(Skip = "Remove to run test")]
    public void No_allergies_at_all()
    {
        var sut = new Allergies(0);
        Assert.Empty(sut.List());
    }

    [Fact(Skip = "Remove to run test")]
    public void Allergic_to_just_eggs()
    {
        var sut = new Allergies(1);
        var expected = new[] { "eggs" };
        Assert.Equal(expected, sut.List());
    }

    [Fact(Skip = "Remove to run test")]
    public void Allergic_to_just_peanuts()
    {
        var sut = new Allergies(2);
        var expected = new[] { "peanuts" };
        Assert.Equal(expected, sut.List());
    }

    [Fact(Skip = "Remove to run test")]
    public void Allergic_to_just_strawberries()
    {
        var sut = new Allergies(8);
        var expected = new[] { "strawberries" };
        Assert.Equal(expected, sut.List());
    }

    [Fact(Skip = "Remove to run test")]
    public void Allergic_to_eggs_and_peanuts()
    {
        var sut = new Allergies(3);
        var expected = new[] { "eggs", "peanuts" };
        Assert.Equal(expected, sut.List());
    }

    [Fact(Skip = "Remove to run test")]
    public void Allergic_to_more_than_eggs_but_not_peanuts()
    {
        var sut = new Allergies(5);
        var expected = new[] { "eggs", "shellfish" };
        Assert.Equal(expected, sut.List());
    }

    [Fact(Skip = "Remove to run test")]
    public void Allergic_to_lots_of_stuff()
    {
        var sut = new Allergies(248);
        var expected = new[] { "strawberries", "tomatoes", "chocolate", "pollen", "cats" };
        Assert.Equal(expected, sut.List());
    }

    [Fact(Skip = "Remove to run test")]
    public void Allergic_to_everything()
    {
        var sut = new Allergies(255);
        var expected = new[] { "eggs", "peanuts", "shellfish", "strawberries", "tomatoes", "chocolate", "pollen", "cats" };
        Assert.Equal(expected, sut.List());
    }

    [Fact(Skip = "Remove to run test")]
    public void Ignore_non_allergen_score_parts()
    {
        var sut = new Allergies(509);
        var expected = new[] { "eggs", "shellfish", "strawberries", "tomatoes", "chocolate", "pollen", "cats" };
        Assert.Equal(expected, sut.List());
    }
}