using NUnit.Framework;

public class ZebraPuzzleTest
{
    [Test]
    public void Who_drinks_water()
    {
        Assert.That(ZebraPuzzle.WhoDrinks(Drink.Water), Is.EqualTo(Nationality.Norwegian));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Who_owns_the_zebra()
    {
        Assert.That(ZebraPuzzle.WhoOwns(Pet.Zebra), Is.EqualTo(Nationality.Japanese));
    }
}