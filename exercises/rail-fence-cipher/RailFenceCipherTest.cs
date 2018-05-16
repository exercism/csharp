// This file was auto-generated based on version 1.1.0 of the canonical data.

using Xunit;

public class RailFenceCipherTest
{
    [Fact]
    public void Encode_with_two_rails()
    {
        var msg = "XOXOXOXOXOXOXOXOXO";
        var sut = new RailFenceCipher(2);
        var expected = "XXXXXXXXXOOOOOOOOO";
        Assert.Equal(expected, sut.Encode(msg));
    }

    [Fact(Skip = "Remove to run test")]
    public void Encode_with_three_rails()
    {
        var msg = "WEAREDISCOVEREDFLEEATONCE";
        var sut = new RailFenceCipher(3);
        var expected = "WECRLTEERDSOEEFEAOCAIVDEN";
        Assert.Equal(expected, sut.Encode(msg));
    }

    [Fact(Skip = "Remove to run test")]
    public void Encode_with_ending_in_the_middle()
    {
        var msg = "EXERCISES";
        var sut = new RailFenceCipher(4);
        var expected = "ESXIEECSR";
        Assert.Equal(expected, sut.Encode(msg));
    }

    [Fact(Skip = "Remove to run test")]
    public void Decode_with_three_rails()
    {
        var msg = "TEITELHDVLSNHDTISEIIEA";
        var sut = new RailFenceCipher(3);
        var expected = "THEDEVILISINTHEDETAILS";
        Assert.Equal(expected, sut.Decode(msg));
    }

    [Fact(Skip = "Remove to run test")]
    public void Decode_with_five_rails()
    {
        var msg = "EIEXMSMESAORIWSCE";
        var sut = new RailFenceCipher(5);
        var expected = "EXERCISMISAWESOME";
        Assert.Equal(expected, sut.Decode(msg));
    }

    [Fact(Skip = "Remove to run test")]
    public void Decode_with_six_rails()
    {
        var msg = "133714114238148966225439541018335470986172518171757571896261";
        var sut = new RailFenceCipher(6);
        var expected = "112358132134558914423337761098715972584418167651094617711286";
        Assert.Equal(expected, sut.Decode(msg));
    }
}