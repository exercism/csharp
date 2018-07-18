// This file was auto-generated based on version 1.1.0 of the canonical data.

using Xunit;

public class AllergiesTest
{
    [Fact]
    public void No_allergies_means_not_allergic()
    {
        var sut = new Allergies(0);
        Assert.False(sut.IsAllergicTo(Allergen.Peanuts));
        Assert.False(sut.IsAllergicTo(Allergen.Cats));
        Assert.False(sut.IsAllergicTo(Allergen.Strawberries));
    }

    [Fact(Skip = "Remove to run test")]
    public void Is_allergic_to_eggs()
    {
        var sut = new Allergies(1);
        Assert.True(sut.IsAllergicTo(Allergen.Eggs));
    }

    [Fact(Skip = "Remove to run test")]
    public void Allergic_to_eggs_in_addition_to_other_stuff()
    {
        var sut = new Allergies(5);
        Assert.True(sut.IsAllergicTo(Allergen.Eggs));
        Assert.True(sut.IsAllergicTo(Allergen.Shellfish));
        Assert.False(sut.IsAllergicTo(Allergen.Strawberries));
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
        var expected = new[] { Allergen.Eggs };
        Assert.Equal(expected, sut.List());
    }

    [Fact(Skip = "Remove to run test")]
    public void Allergic_to_just_peanuts()
    {
        var sut = new Allergies(2);
        var expected = new[] { Allergen.Peanuts };
        Assert.Equal(expected, sut.List());
    }

    [Fact(Skip = "Remove to run test")]
    public void Allergic_to_just_strawberries()
    {
        var sut = new Allergies(8);
        var expected = new[] { Allergen.Strawberries };
        Assert.Equal(expected, sut.List());
    }

    [Fact(Skip = "Remove to run test")]
    public void Allergic_to_eggs_and_peanuts()
    {
        var sut = new Allergies(3);
        var expected = new[] { Allergen.Eggs, Allergen.Peanuts };
        Assert.Equal(expected, sut.List());
    }

    [Fact(Skip = "Remove to run test")]
    public void Allergic_to_more_than_eggs_but_not_peanuts()
    {
        var sut = new Allergies(5);
        var expected = new[] { Allergen.Eggs, Allergen.Shellfish };
        Assert.Equal(expected, sut.List());
    }

    [Fact(Skip = "Remove to run test")]
    public void Allergic_to_lots_of_stuff()
    {
        var sut = new Allergies(248);
        var expected = new[] { Allergen.Strawberries, Allergen.Tomatoes, Allergen.Chocolate, Allergen.Pollen, Allergen.Cats };
        Assert.Equal(expected, sut.List());
    }

    [Fact(Skip = "Remove to run test")]
    public void Allergic_to_everything()
    {
        var sut = new Allergies(255);
        var expected = new[] { Allergen.Eggs, Allergen.Peanuts, Allergen.Shellfish, Allergen.Strawberries, Allergen.Tomatoes, Allergen.Chocolate, Allergen.Pollen, Allergen.Cats };
        Assert.Equal(expected, sut.List());
    }

    [Fact(Skip = "Remove to run test")]
    public void Ignore_non_allergen_score_parts()
    {
        var sut = new Allergies(509);
        var expected = new[] { Allergen.Eggs, Allergen.Shellfish, Allergen.Strawberries, Allergen.Tomatoes, Allergen.Chocolate, Allergen.Pollen, Allergen.Cats };
        Assert.Equal(expected, sut.List());
    }
}