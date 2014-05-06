using NUnit.Framework;
using System.Collections.Generic;

namespace ExercismCSharp.sum_of_multiples
{
    [TestFixture]
    public class SumOfMultiplesTest
    {
        private SumOfMultiples sumOfMultiples;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            sumOfMultiples = new SumOfMultiples();
        }

        [TestFixtureTearDown]
        public void FixtureTearDown()
        {
            sumOfMultiples = null;
        }

        [Test]
        public void TestSumTo1()
        {
            Assert.That(0, Is.EqualTo(sumOfMultiples.To(1)));
        }

        [Test]
        //[Ignore]
        public void TestSumTo3()
        {
            Assert.That(3, Is.EqualTo(sumOfMultiples.To(4)));
        }

        [Test]
        //[Ignore]
        public void TestSumTo10()
        {
            Assert.That(23, Is.EqualTo(sumOfMultiples.To(10)));
        }

        [Test]
        //[Ignore]
        public void TestSumTo1000()
        {
            Assert.That(233168, Is.EqualTo(sumOfMultiples.To(1000)));
        }

        [Test]
        //[Ignore]
        public void TestConfigurable7_13_17To20()
        {
            Assert.That(51, Is.EqualTo(new SumOfMultiples(new List<int> { 7, 13, 17 }).To(20)));
        }

        [Test]
        //[Ignore]
        public void TestConfigurable43_47To10000()
        {
            Assert.That(2203160, Is.EqualTo(new SumOfMultiples(new List<int> { 43, 47 }).To(10000)));
        }
    }
}