using Xunit;

public class SecretHandshakeTests
{
    [Fact]
    public void Test_1_handshake_to_wink()
    {
        Assert.Equal(new[] { "wink" }, SecretHandshake.Commands(1));
    }

    [Fact(Skip = "Remove to run test")]
    public void Test_10_handshake_to_double_blink()
    {
        Assert.Equal(new[] { "double blink" }, SecretHandshake.Commands(2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Test_100_handshake_to_close_your_eyes()
    {
        Assert.Equal(new[] { "close your eyes" }, SecretHandshake.Commands(4));
    }

    [Fact(Skip = "Remove to run test")]
    public void Test_1000_handshake_to_close_your_eyes()
    {
        Assert.Equal(new[] { "jump" }, SecretHandshake.Commands(8));
    }

    [Fact(Skip = "Remove to run test")]
    public void Test_handshake_11_to_wink_and_double_blink()
    {
        Assert.Equal(new[] { "wink", "double blink" }, SecretHandshake.Commands(3));
    }

    [Fact(Skip = "Remove to run test")]
    public void Test_handshake_10011_to_double_blink_and_wink()
    {
        Assert.Equal(new[] { "double blink", "wink" }, SecretHandshake.Commands(19));
    }

    [Fact(Skip = "Remove to run test")]
    public void Test_handshake_11111_to_all_commands_reversed()
    {
        Assert.Equal(new[] { "jump", "close your eyes", "double blink", "wink" }, SecretHandshake.Commands(31));
    }
}
