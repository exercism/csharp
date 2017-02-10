using Xunit;

public class RailFenceCipherTest
{
    [Fact]
    public void Encode_with_two_rails()
    {
        var railFenceCipher = new RailFenceCipher(2);
        var actual = railFenceCipher.Encode("XOXOXOXOXOXOXOXOXO");
        var expected = "XXXXXXXXXOOOOOOOOO";
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Encode_with_three_rails()
    {
        var railFenceCipher = new RailFenceCipher(3);
        var actual = railFenceCipher.Encode("WEAREDISCOVEREDFLEEATONCE");
        var expected = "WECRLTEERDSOEEFEAOCAIVDEN";
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Encode_with_ending_in_the_middle()
    {
        var railFenceCipher = new RailFenceCipher(4);
        var actual = railFenceCipher.Encode("EXERCISES");
        var expected = "ESXIEECSR";
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Decode_with_three_rails()
    {
        var railFenceCipher = new RailFenceCipher(3);
        var actual = railFenceCipher.Decode("TEITELHDVLSNHDTISEIIEA");
        var expected = "THEDEVILISINTHEDETAILS";
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Decode_with_five_rails()
    {
        var railFenceCipher = new RailFenceCipher(5);
        var actual = railFenceCipher.Decode("EIEXMSMESAORIWSCE");
        var expected = "EXERCISMISAWESOME";
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Decode_with_six_rails()
    {
        var railFenceCipher = new RailFenceCipher(6);
        var actual = railFenceCipher.Decode("133714114238148966225439541018335470986172518171757571896261");
        var expected = "112358132134558914423337761098715972584418167651094617711286";
        Assert.Equal(expected, actual);
    }
}