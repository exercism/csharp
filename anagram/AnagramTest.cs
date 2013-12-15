using NUnit.Framework;

[TestFixture]
public class AnagramTest
{
    [Test]
    public void NoMatches ()
    {
        Anagram detector = new Anagram("diaper");
        string[] words = new string[] { "hello", "world", "zombies", "pants" };
        string[] results = new string[0];
        Assert.AreEqual(results, detector.Match(words));
    }


    [Test]
    public void DetectSimpleAnagram ()
    {
        Anagram detector = new Anagram("ant");
        string[] words = new string[] { "tan", "stand", "at" };
        string[] results = new string[] { "tan" };
        Assert.AreEqual(results, detector.Match(words));
    }

    [Test]
    public void DetectMultipleAnagrams ()
    {
        Anagram detector = new Anagram("master");
        string[] words = new string[] { "stream", "pigeon", "maters" };
        string[] results = new string[] { "maters", "stream" };
        Assert.AreEqual(results, detector.Match(words));
    }

    [Test]
    public void DoesNotConfuseDifferentDuplicates ()
    {
        Anagram detector = new Anagram("galea");
        string[] words = new string[] { "eagle" };
        string[] results = new string[0];
        Assert.AreEqual(results, detector.Match(words));
    }

    [Test]
    public void IdenticalWordIsNotAnagram ()
    {
        Anagram detector = new Anagram("corn");
        string[] words = new string[] { "corn", "dark", "Corn", "rank", "CORN", "cron", "park" };
        string[] results = new string[] { "cron" };
        Assert.AreEqual(results, detector.Match(words));
    }

    [Test]
    public void EliminateAnagramsWithSameChecksum ()
    {
        Anagram detector = new Anagram("mass");
        string[] words = new string[] { "last" };
        string[] results = new string[0];
        Assert.AreEqual(results, detector.Match(words));
    }

    [Test]
    public void EliminateAnagramSubsets ()
    {
        Anagram detector = new Anagram("good");
        string[] words = new string[] { "dog", "goody" };
        string[] results = new string[0];
        Assert.AreEqual(results, detector.Match(words));
    }

    [Test]
    public void DetectAnagrams ()
    {
        Anagram detector = new Anagram("allergy");
        string[] words = new string[] { "gallery", "ballerina", "regally", "clergy", "largely", "leading" };
        string[] results = new string[] { "gallery", "largely", "regally" };
        Assert.AreEqual(results, detector.Match(words));
    }

    [Test]
    public void AnagramsAreCaseInsensitive ()
    {
        Anagram detector = new Anagram("Orchestra");
        string[] words = new string[] { "cashregister", "Carthorse", "radishes" };
        string[] results = new string[] { "Carthorse" };
        Assert.AreEqual(results, detector.Match(words));
    }

}