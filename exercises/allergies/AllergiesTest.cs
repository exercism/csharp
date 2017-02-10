using System.Collections.Generic;
using Xunit;

public class AllergiesTest
{
    [Fact]
    public void No_allergies_means_not_allergic()
    {
        var allergies = new Allergies(0);
        Assert.False(allergies.AllergicTo("peanuts"));
        Assert.False(allergies.AllergicTo("cats"));
        Assert.False(allergies.AllergicTo("strawberries"));
    }

    [Fact]
    public void Allergic_to_eggs()
    {
        var allergies = new Allergies(1);
        Assert.True(allergies.AllergicTo("eggs"));
    }

    [Fact]
    public void Allergic_to_eggs_in_addition_to_other_stuff()
    {
        var allergies = new Allergies(5);
        Assert.True(allergies.AllergicTo("eggs"));
        Assert.True(allergies.AllergicTo("shellfish"));
        Assert.False(allergies.AllergicTo("strawberries"));
    }

    [Fact]
    public void No_allergies_at_all()
    {
        var allergies = new Allergies(0);
        Assert.Empty(allergies.List());
    }

    [Fact]
    public void Allergic_to_just_eggs()
    {
        var allergies = new Allergies(1);
        Assert.Equal(new List<string> { "eggs" }, allergies.List());
    }

    [Fact]
    public void Allergic_to_just_peanuts()
    {
        var allergies = new Allergies(2);
        Assert.Equal(new List<string> { "peanuts" }, allergies.List());
    }

    [Fact]
    public void Allergic_to_eggs_and_peanuts()
    {
        var allergies = new Allergies(3);
        Assert.Equal(new List<string> { "eggs", "peanuts" }, allergies.List());
    }

    [Fact]
    public void Allergic_to_lots_of_stuff()
    {
        var allergies = new Allergies(248);
        Assert.Equal(new List<string> { "strawberries", "tomatoes", "chocolate", "pollen", "cats" }, allergies.List());
    }

    [Fact]
    public void Allergic_to_everything()
    {
        var allergies = new Allergies(255);
        Assert.Equal(new List<string>
                {
                    "eggs",
                    "peanuts",
                    "shellfish",
                    "strawberries",
                    "tomatoes",
                    "chocolate",
                    "pollen",
                    "cats"
                },
                allergies.List());
    }

    [Fact]
    public void Ignore_non_allergen_score_parts()
    {
        var allergies = new Allergies(509);
        Assert.Equal(new List<string>
                {
                    "eggs",
                    "shellfish",
                    "strawberries",
                    "tomatoes",
                    "chocolate",
                    "pollen",
                    "cats"
                }, allergies.List());
    }
}