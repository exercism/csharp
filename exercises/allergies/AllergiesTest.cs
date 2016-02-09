using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class AllergiesTest
{
    [Test]
    public void No_allergies_means_not_allergic()
    {
        var allergies = new Allergies(0);
        Assert.That(allergies.AllergicTo("peanuts"), Is.False);
        Assert.That(allergies.AllergicTo("cats"), Is.False);
        Assert.That(allergies.AllergicTo("strawberries"), Is.False);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Allergic_to_eggs()
    {
        var allergies = new Allergies(1);
        Assert.That(allergies.AllergicTo("eggs"), Is.True);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Allergic_to_eggs_in_addition_to_other_stuff()
    {
        var allergies = new Allergies(5);
        Assert.That(allergies.AllergicTo("eggs"), Is.True);
        Assert.That(allergies.AllergicTo("shellfish"), Is.True);
        Assert.That(allergies.AllergicTo("strawberries"), Is.False);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void No_allergies_at_all()
    {
        var allergies = new Allergies(0);
        Assert.That(allergies.List(), Is.Empty);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Allergic_to_just_eggs()
    {
        var allergies = new Allergies(1);
        Assert.That(allergies.List(), Is.EqualTo(new List<string> { "eggs" }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Allergic_to_just_peanuts()
    {
        var allergies = new Allergies(2);
        Assert.That(allergies.List(), Is.EqualTo(new List<string> { "peanuts" }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Allergic_to_eggs_and_peanuts()
    {
        var allergies = new Allergies(3);
        Assert.That(allergies.List(), Is.EqualTo(new List<string> { "eggs", "peanuts" }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Allergic_to_lots_of_stuff()
    {
        var allergies = new Allergies(248);
        Assert.That(allergies.List(),
            Is.EqualTo(new List<string> { "strawberries", "tomatoes", "chocolate", "pollen", "cats" }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Allergic_to_everything()
    {
        var allergies = new Allergies(255);
        Assert.That(allergies.List(),
            Is.EqualTo(new List<string>
                {
                    "eggs",
                    "peanuts",
                    "shellfish",
                    "strawberries",
                    "tomatoes",
                    "chocolate",
                    "pollen",
                    "cats"
                }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Ignore_non_allergen_score_parts()
    {
        var allergies = new Allergies(509);
        Assert.That(allergies.List(),
            Is.EqualTo(new List<string>
                {
                    "eggs",
                    "shellfish",
                    "strawberries",
                    "tomatoes",
                    "chocolate",
                    "pollen",
                    "cats"
                }));
    }
}