using Xunit;

public class EliudsEggsTests
{
    [Fact]
    public void ZeroEggs()
    {
        Assert.Equal(0, EliudsEggs.EggCount(0));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void OneEgg()
    {
        Assert.Equal(1, EliudsEggs.EggCount(16));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void FourEggs()
    {
        Assert.Equal(4, EliudsEggs.EggCount(89));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void ThirteenEggs()
    {
        Assert.Equal(13, EliudsEggs.EggCount(2000000000));
    }
}
