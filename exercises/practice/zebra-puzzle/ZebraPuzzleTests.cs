using Xunit;

public class ZebraPuzzleTests
{
    [Fact]
    public void ResidentWhoDrinksWater()
    {
        Assert.Equal(Nationality.Norwegian, ZebraPuzzle.DrinksWater());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void ResidentWhoOwnsZebra()
    {
        Assert.Equal(Nationality.Japanese, ZebraPuzzle.OwnsZebra());
    }
}
