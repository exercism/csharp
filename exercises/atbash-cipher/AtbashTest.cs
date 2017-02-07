using Xunit;

public class AtbashTest
{
    [InlineData("no", "ml")]
    [InlineData("yes", "bvh")]
    [InlineData("OMG", "lnt")]
    [InlineData("mindblowingly", "nrmwy oldrm tob")]
    [InlineData("Testing, 1 2 3, testing.", "gvhgr mt123 gvhgr mt")]
    [InlineData("Truth is fiction.", "gifgs rhurx grlm")]
    [InlineData("The quick brown fox jumps over the lazy dog.", "gsvjf rxpyi ldmul cqfnk hlevi gsvoz abwlt")]
    public void Encodes_words_using_atbash_cipher(string words, string expected)
    {
        Assert.Equal(expected, Atbash.Encode(words));
    }
}