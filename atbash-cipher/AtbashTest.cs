using NUnit.Framework;

[TestFixture]
public class AtbashTest
{
    // change Ignore to false to run test case or just remove 'Ignore = true'
    [TestCase("no", Result = "ml")]
    [TestCase("yes", Result = "bvh", Ignore = true)]
    [TestCase("OMG", Result = "lnt", Ignore = true)]
    [TestCase("mindblowingly", Result = "nrmwy oldrm tob", Ignore = true)]
    [TestCase("Testing, 1 2 3, testing.", Result = "gvhgr mt123 gvhgr mt", Ignore = true)]
    [TestCase("Truth is fiction.", Result = "gifgs rhurx grlm", Ignore = true)]
    [TestCase("The quick brown fox jumps over the lazy dog.", Result = "gsvjf rxpyi ldmul cqfnk hlevi gsvoz abwlt", Ignore = true)]
    public string Encodes_words_using_atbash_cipher(string words)
    {
        return Atbash.Encode(words);
    }
}