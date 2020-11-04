using Combined;
using Xunit;

public class NamespacesTests
{
    [Fact]
    public void BuildRed()
    {
        Assert.NotNull(CarBuilder.BuildRed());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void BuildBlue()
    {
        Assert.NotNull(CarBuilder.BuildBlue());
    }
}
