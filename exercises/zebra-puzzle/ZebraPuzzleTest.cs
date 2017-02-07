using Xunit;

public class ZebraPuzzleTest
{
    [Fact]
    public void Who_drinks_water()
    {
        Assert.That(ZebraPuzzle.WhoDrinks(Drink.Water), Is.EqualTo(Nationality.Norwegian));
    }

    [Fact(Skip="Remove to run test")]
    public void Who_owns_the_zebra()
    {
        Assert.That(ZebraPuzzle.WhoOwns(Pet.Zebra), Is.EqualTo(Nationality.Japanese));
    }
}