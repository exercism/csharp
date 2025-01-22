using Xunit;

public class SquareRootTests
{
    [Fact]
    public void Root_of_1()
    {
        Assert.Equal(1, SquareRoot.Root(1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Root_of_4()
    {
        Assert.Equal(2, SquareRoot.Root(4));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Root_of_25()
    {
        Assert.Equal(5, SquareRoot.Root(25));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Root_of_81()
    {
        Assert.Equal(9, SquareRoot.Root(81));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Root_of_196()
    {
        Assert.Equal(14, SquareRoot.Root(196));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Root_of_65025()
    {
        Assert.Equal(255, SquareRoot.Root(65025));
    }
}