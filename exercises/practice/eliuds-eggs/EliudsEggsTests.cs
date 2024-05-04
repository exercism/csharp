using Xunit;

public class EliudsEggsTests
{
    [Fact]
    public void Number_0_eggs()
    {
        Assert.Equal(0, EliudsEggs.EggCount(0));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Number_1_egg()
    {
        Assert.Equal(1, EliudsEggs.EggCount(16));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Number_4_eggs()
    {
        Assert.Equal(4, EliudsEggs.EggCount(89));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Number_13_eggs()
    {
        Assert.Equal(13, EliudsEggs.EggCount(2000000000));
    }
}
