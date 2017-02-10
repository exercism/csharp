using Xunit;

public class ZebraPuzzleTest
{
    [Fact]
    public void Who_drinks_water()
    {
        Assert.Equal(Nationality.Norwegian, ZebraPuzzle.WhoDrinks(Drink.Water));
    }

    [Fact]
    public void Who_owns_the_zebra()
    {
        Assert.Equal(Nationality.Japanese, ZebraPuzzle.WhoOwns(Pet.Zebra));
    }
}