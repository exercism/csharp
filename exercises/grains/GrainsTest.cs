using Xunit;

public class GrainsTest
{
    [Fact]
    public void Test_square_1()
    {
        Assert.Equal(1ul, Grains.Square(1));
    }

    [Fact(Skip = "Remove to run test")]
    public void Test_square_2()
    {
        Assert.Equal(2ul, Grains.Square(2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Test_square_3()
    {
        Assert.Equal(4ul, Grains.Square(3));
    }

    [Fact(Skip = "Remove to run test")]
    public void Test_square_4()
    {
        Assert.Equal(8ul, Grains.Square(4));
    }

    [Fact(Skip = "Remove to run test")]
    public void Test_square_16()
    {
        Assert.Equal(32768ul, Grains.Square(16));
    }

    [Fact(Skip = "Remove to run test")]
    public void Test_square_32()
    {
        Assert.Equal(2147483648ul, Grains.Square(32));
    }

    [Fact(Skip = "Remove to run test")]
    public void Test_square_64()
    {
        Assert.Equal(9223372036854775808ul, Grains.Square(64));
    }

    [Fact(Skip = "Remove to run test")]
    public void Test_total_grains()
    {
        Assert.Equal(18446744073709551615ul, Grains.Total());
    }
}