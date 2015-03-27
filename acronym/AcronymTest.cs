namespace Exercism
{
    using NUnit.Framework;

    [TestFixture]
    public class AcronymTest
    {
        [Test]
        public void Empty_string_abbreviated_to_empty_string()
        {
            Assert.That(Acronym.Abbreviate(string.Empty), Is.EqualTo(string.Empty));
        }

        [TestCase("Portable Network Graphics", Result = "PNG", Ignore = true)]
        [TestCase("Ruby on Rails", Result = "ROR", Ignore = true)]
        [TestCase("HyperText Markup Language", Result = "HTML", Ignore = true)]
        [TestCase("First In, First Out", Result = "FIFO", Ignore = true)]
        [TestCase("PHP: Hypertext Preprocessor", Result = "PHP", Ignore = true)]
        [TestCase("Complementary metal-oxide semiconductor", Result = "CMOS", Ignore = true)]
        public string Phrase_abbreviated_to_acronym(string phrase)
        {
            return Acronym.Abbreviate(phrase);
        }
    }
}