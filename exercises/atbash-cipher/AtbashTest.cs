using NUnit.Framework;

[TestFixture]
public class AtbashTest
{
    [TestCase("no", ExpectedResult = "ml")]
    [TestCase("yes", ExpectedResult = "bvh", Ignore = "Remove to run test case")]
    [TestCase("OMG", ExpectedResult = "lnt", Ignore = "Remove to run test case")]
    [TestCase("mindblowingly", ExpectedResult = "nrmwy oldrm tob", Ignore = "Remove to run test case")]
    [TestCase("Testing, 1 2 3, testing.", ExpectedResult = "gvhgr mt123 gvhgr mt", Ignore = "Remove to run test case")]
    [TestCase("Truth is fiction.", ExpectedResult = "gifgs rhurx grlm", Ignore = "Remove to run test case")]
    [TestCase("The quick brown fox jumps over the lazy dog.", ExpectedResult = "gsvjf rxpyi ldmul cqfnk hlevi gsvoz abwlt", Ignore = "Remove to run test case")]
    public string Encodes_words_using_atbash_cipher(string words)
    {
        return Atbash.Encode(words);
    }
}