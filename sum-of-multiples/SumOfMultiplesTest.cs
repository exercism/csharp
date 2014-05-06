using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ExercismCSharp.sum_of_multiples
{
    [TestClass]
    public class SumOfMultiplesTest
    {
        private SumOfMultiples sumOfMultiples;

        [TestInitialize]
        public void FixtureSetup()
        {
            sumOfMultiples = new SumOfMultiples();
        }

        [TestCleanup]
        public void FixtureTearDown()
        {
            sumOfMultiples = null;
        }

        [TestMethod]
        public void TestSumTo1()
        {
            Assert.AreEqual(0, sumOfMultiples.To(1));
        }

        [TestMethod]
        //[Ignore]
        public void TestSumTo3()
        {
            Assert.AreEqual(3, sumOfMultiples.To(4));
        }

        [TestMethod]
        //[Ignore]
        public void TestSumTo10()
        {
            Assert.AreEqual(23, sumOfMultiples.To(10));
        }

        [TestMethod]
        //[Ignore]
        public void TestSumTo1000()
        {
            Assert.AreEqual(233168, sumOfMultiples.To(1000));
        }

        [TestMethod]
        //[Ignore]
        public void TestConfigurable7_13_17To20()
        {
            Assert.AreEqual(51, new SumOfMultiples(new List<int> { 7, 13, 17 }).To(20));
        }

        [TestMethod]
        //[Ignore]
        public void TestConfigurable43_47To10000()
        {
            Assert.AreEqual(2203160, new SumOfMultiples(new List<int> { 43, 47 }).To(10000));
        }
    }
}