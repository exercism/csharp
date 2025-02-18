public class SecretHandshakeTests
{
    [Fact]
    public void Wink_for_1()
    {
        string[] expected = ["wink"];
        Assert.Equal(expected, SecretHandshake.Commands(1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Double_blink_for_10()
    {
        string[] expected = ["double blink"];
        Assert.Equal(expected, SecretHandshake.Commands(2));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Close_your_eyes_for_100()
    {
        string[] expected = ["close your eyes"];
        Assert.Equal(expected, SecretHandshake.Commands(4));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Jump_for_1000()
    {
        string[] expected = ["jump"];
        Assert.Equal(expected, SecretHandshake.Commands(8));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Combine_two_actions()
    {
        string[] expected = ["wink", "double blink"];
        Assert.Equal(expected, SecretHandshake.Commands(3));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Reverse_two_actions()
    {
        string[] expected = ["double blink", "wink"];
        Assert.Equal(expected, SecretHandshake.Commands(19));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Reversing_one_action_gives_the_same_action()
    {
        string[] expected = ["jump"];
        Assert.Equal(expected, SecretHandshake.Commands(24));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Reversing_no_actions_still_gives_no_actions()
    {
        string[] expected = [];
        Assert.Equal(expected, SecretHandshake.Commands(16));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void All_possible_actions()
    {
        string[] expected = ["wink", "double blink", "close your eyes", "jump"];
        Assert.Equal(expected, SecretHandshake.Commands(15));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Reverse_all_possible_actions()
    {
        string[] expected = ["jump", "close your eyes", "double blink", "wink"];
        Assert.Equal(expected, SecretHandshake.Commands(31));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Do_nothing_for_zero()
    {
        string[] expected = [];
        Assert.Equal(expected, SecretHandshake.Commands(0));
    }
}
