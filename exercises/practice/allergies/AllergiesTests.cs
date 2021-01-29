// This file was auto-generated based on version 2.0.0 of the canonical data.

using Xunit;

public class AllergiesTests
{
    [Fact]
    public void Testing_for_eggs_allergy_not_allergic_to_anything()
    {
        var sut = new Allergies(0);
        Assert.False(sut.IsAllergicTo(Allergen.Eggs));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Testing_for_eggs_allergy_allergic_only_to_eggs()
    {
        var sut = new Allergies(1);
        Assert.True(sut.IsAllergicTo(Allergen.Eggs));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Testing_for_eggs_allergy_allergic_to_eggs_and_something_else()
    {
        var sut = new Allergies(3);
        Assert.True(sut.IsAllergicTo(Allergen.Eggs));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Testing_for_eggs_allergy_allergic_to_something_but_not_eggs()
    {
        var sut = new Allergies(2);
        Assert.False(sut.IsAllergicTo(Allergen.Eggs));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Testing_for_eggs_allergy_allergic_to_everything()
    {
        var sut = new Allergies(255);
        Assert.True(sut.IsAllergicTo(Allergen.Eggs));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Testing_for_peanuts_allergy_not_allergic_to_anything()
    {
        var sut = new Allergies(0);
        Assert.False(sut.IsAllergicTo(Allergen.Peanuts));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Testing_for_peanuts_allergy_allergic_only_to_peanuts()
    {
        var sut = new Allergies(2);
        Assert.True(sut.IsAllergicTo(Allergen.Peanuts));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Testing_for_peanuts_allergy_allergic_to_peanuts_and_something_else()
    {
        var sut = new Allergies(7);
        Assert.True(sut.IsAllergicTo(Allergen.Peanuts));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Testing_for_peanuts_allergy_allergic_to_something_but_not_peanuts()
    {
        var sut = new Allergies(5);
        Assert.False(sut.IsAllergicTo(Allergen.Peanuts));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Testing_for_peanuts_allergy_allergic_to_everything()
    {
        var sut = new Allergies(255);
        Assert.True(sut.IsAllergicTo(Allergen.Peanuts));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Testing_for_shellfish_allergy_not_allergic_to_anything()
    {
        var sut = new Allergies(0);
        Assert.False(sut.IsAllergicTo(Allergen.Shellfish));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Testing_for_shellfish_allergy_allergic_only_to_shellfish()
    {
        var sut = new Allergies(4);
        Assert.True(sut.IsAllergicTo(Allergen.Shellfish));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Testing_for_shellfish_allergy_allergic_to_shellfish_and_something_else()
    {
        var sut = new Allergies(14);
        Assert.True(sut.IsAllergicTo(Allergen.Shellfish));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Testing_for_shellfish_allergy_allergic_to_something_but_not_shellfish()
    {
        var sut = new Allergies(10);
        Assert.False(sut.IsAllergicTo(Allergen.Shellfish));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Testing_for_shellfish_allergy_allergic_to_everything()
    {
        var sut = new Allergies(255);
        Assert.True(sut.IsAllergicTo(Allergen.Shellfish));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Testing_for_strawberries_allergy_not_allergic_to_anything()
    {
        var sut = new Allergies(0);
        Assert.False(sut.IsAllergicTo(Allergen.Strawberries));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Testing_for_strawberries_allergy_allergic_only_to_strawberries()
    {
        var sut = new Allergies(8);
        Assert.True(sut.IsAllergicTo(Allergen.Strawberries));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Testing_for_strawberries_allergy_allergic_to_strawberries_and_something_else()
    {
        var sut = new Allergies(28);
        Assert.True(sut.IsAllergicTo(Allergen.Strawberries));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Testing_for_strawberries_allergy_allergic_to_something_but_not_strawberries()
    {
        var sut = new Allergies(20);
        Assert.False(sut.IsAllergicTo(Allergen.Strawberries));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Testing_for_strawberries_allergy_allergic_to_everything()
    {
        var sut = new Allergies(255);
        Assert.True(sut.IsAllergicTo(Allergen.Strawberries));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Testing_for_tomatoes_allergy_not_allergic_to_anything()
    {
        var sut = new Allergies(0);
        Assert.False(sut.IsAllergicTo(Allergen.Tomatoes));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Testing_for_tomatoes_allergy_allergic_only_to_tomatoes()
    {
        var sut = new Allergies(16);
        Assert.True(sut.IsAllergicTo(Allergen.Tomatoes));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Testing_for_tomatoes_allergy_allergic_to_tomatoes_and_something_else()
    {
        var sut = new Allergies(56);
        Assert.True(sut.IsAllergicTo(Allergen.Tomatoes));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Testing_for_tomatoes_allergy_allergic_to_something_but_not_tomatoes()
    {
        var sut = new Allergies(40);
        Assert.False(sut.IsAllergicTo(Allergen.Tomatoes));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Testing_for_tomatoes_allergy_allergic_to_everything()
    {
        var sut = new Allergies(255);
        Assert.True(sut.IsAllergicTo(Allergen.Tomatoes));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Testing_for_chocolate_allergy_not_allergic_to_anything()
    {
        var sut = new Allergies(0);
        Assert.False(sut.IsAllergicTo(Allergen.Chocolate));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Testing_for_chocolate_allergy_allergic_only_to_chocolate()
    {
        var sut = new Allergies(32);
        Assert.True(sut.IsAllergicTo(Allergen.Chocolate));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Testing_for_chocolate_allergy_allergic_to_chocolate_and_something_else()
    {
        var sut = new Allergies(112);
        Assert.True(sut.IsAllergicTo(Allergen.Chocolate));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Testing_for_chocolate_allergy_allergic_to_something_but_not_chocolate()
    {
        var sut = new Allergies(80);
        Assert.False(sut.IsAllergicTo(Allergen.Chocolate));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Testing_for_chocolate_allergy_allergic_to_everything()
    {
        var sut = new Allergies(255);
        Assert.True(sut.IsAllergicTo(Allergen.Chocolate));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Testing_for_pollen_allergy_not_allergic_to_anything()
    {
        var sut = new Allergies(0);
        Assert.False(sut.IsAllergicTo(Allergen.Pollen));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Testing_for_pollen_allergy_allergic_only_to_pollen()
    {
        var sut = new Allergies(64);
        Assert.True(sut.IsAllergicTo(Allergen.Pollen));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Testing_for_pollen_allergy_allergic_to_pollen_and_something_else()
    {
        var sut = new Allergies(224);
        Assert.True(sut.IsAllergicTo(Allergen.Pollen));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Testing_for_pollen_allergy_allergic_to_something_but_not_pollen()
    {
        var sut = new Allergies(160);
        Assert.False(sut.IsAllergicTo(Allergen.Pollen));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Testing_for_pollen_allergy_allergic_to_everything()
    {
        var sut = new Allergies(255);
        Assert.True(sut.IsAllergicTo(Allergen.Pollen));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Testing_for_cats_allergy_not_allergic_to_anything()
    {
        var sut = new Allergies(0);
        Assert.False(sut.IsAllergicTo(Allergen.Cats));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Testing_for_cats_allergy_allergic_only_to_cats()
    {
        var sut = new Allergies(128);
        Assert.True(sut.IsAllergicTo(Allergen.Cats));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Testing_for_cats_allergy_allergic_to_cats_and_something_else()
    {
        var sut = new Allergies(192);
        Assert.True(sut.IsAllergicTo(Allergen.Cats));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Testing_for_cats_allergy_allergic_to_something_but_not_cats()
    {
        var sut = new Allergies(64);
        Assert.False(sut.IsAllergicTo(Allergen.Cats));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Testing_for_cats_allergy_allergic_to_everything()
    {
        var sut = new Allergies(255);
        Assert.True(sut.IsAllergicTo(Allergen.Cats));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void No_allergies()
    {
        var sut = new Allergies(0);
        Assert.Empty(sut.List());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Just_eggs()
    {
        var sut = new Allergies(1);
        var expected = new[] { Allergen.Eggs };
        Assert.Equal(expected, sut.List());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Just_peanuts()
    {
        var sut = new Allergies(2);
        var expected = new[] { Allergen.Peanuts };
        Assert.Equal(expected, sut.List());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Just_strawberries()
    {
        var sut = new Allergies(8);
        var expected = new[] { Allergen.Strawberries };
        Assert.Equal(expected, sut.List());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Eggs_and_peanuts()
    {
        var sut = new Allergies(3);
        var expected = new[] { Allergen.Eggs, Allergen.Peanuts };
        Assert.Equal(expected, sut.List());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void More_than_eggs_but_not_peanuts()
    {
        var sut = new Allergies(5);
        var expected = new[] { Allergen.Eggs, Allergen.Shellfish };
        Assert.Equal(expected, sut.List());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Lots_of_stuff()
    {
        var sut = new Allergies(248);
        var expected = new[] { Allergen.Strawberries, Allergen.Tomatoes, Allergen.Chocolate, Allergen.Pollen, Allergen.Cats };
        Assert.Equal(expected, sut.List());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Everything()
    {
        var sut = new Allergies(255);
        var expected = new[] { Allergen.Eggs, Allergen.Peanuts, Allergen.Shellfish, Allergen.Strawberries, Allergen.Tomatoes, Allergen.Chocolate, Allergen.Pollen, Allergen.Cats };
        Assert.Equal(expected, sut.List());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void No_allergen_score_parts()
    {
        var sut = new Allergies(509);
        var expected = new[] { Allergen.Eggs, Allergen.Shellfish, Allergen.Strawberries, Allergen.Tomatoes, Allergen.Chocolate, Allergen.Pollen, Allergen.Cats };
        Assert.Equal(expected, sut.List());
    }
}