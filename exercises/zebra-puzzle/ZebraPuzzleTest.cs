// This file was auto-generated based on version 1.1.0 of the canonical data.

using Xunit;

public class ZebraPuzzleTest
{
    [Fact]
    public void Resident_who_drinks_water()
    {
        Assert.Equal(Nationality.Norwegian, ZebraPuzzle.DrinksWater());
    }

    [Fact(Skip = "Remove to run test")]
    public void Resident_who_owns_zebra()
    {
        Assert.Equal(Nationality.Japanese, ZebraPuzzle.OwnsZebra());
    }
}