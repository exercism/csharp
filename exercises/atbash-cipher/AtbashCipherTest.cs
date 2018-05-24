// This file was auto-generated based on version 1.1.0 of the canonical data.

using Xunit;

public class AtbashCipherTest
{
    [Fact]
    public void Encode_yes()
    {
        Assert.Equal("bvh", AtbashCipher.Encode("yes"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Encode_no()
    {
        Assert.Equal("ml", AtbashCipher.Encode("no"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Encode_omg()
    {
        Assert.Equal("lnt", AtbashCipher.Encode("OMG"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Encode_spaces()
    {
        Assert.Equal("lnt", AtbashCipher.Encode("O M G"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Encode_mindblowingly()
    {
        Assert.Equal("nrmwy oldrm tob", AtbashCipher.Encode("mindblowingly"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Encode_numbers()
    {
        Assert.Equal("gvhgr mt123 gvhgr mt", AtbashCipher.Encode("Testing,1 2 3, testing."));
    }

    [Fact(Skip = "Remove to run test")]
    public void Encode_deep_thought()
    {
        Assert.Equal("gifgs rhurx grlm", AtbashCipher.Encode("Truth is fiction."));
    }

    [Fact(Skip = "Remove to run test")]
    public void Encode_all_the_letters()
    {
        Assert.Equal("gsvjf rxpyi ldmul cqfnk hlevi gsvoz abwlt", AtbashCipher.Encode("The quick brown fox jumps over the lazy dog."));
    }

    [Fact(Skip = "Remove to run test")]
    public void Decode_exercism()
    {
        Assert.Equal("exercism", AtbashCipher.Decode("vcvix rhn"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Decode_a_sentence()
    {
        Assert.Equal("anobstacleisoftenasteppingstone", AtbashCipher.Decode("zmlyh gzxov rhlug vmzhg vkkrm thglm v"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Decode_numbers()
    {
        Assert.Equal("testing123testing", AtbashCipher.Decode("gvhgr mt123 gvhgr mt"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Decode_all_the_letters()
    {
        Assert.Equal("thequickbrownfoxjumpsoverthelazydog", AtbashCipher.Decode("gsvjf rxpyi ldmul cqfnk hlevi gsvoz abwlt"));
    }
}