using System;
using System.Collections.Generic;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class Sieve : ExerciseGenerator
    {
        protected override void UpdateNamespaces(ISet<string> namespaces) =>
            namespaces.Add(typeof(ArgumentOutOfRangeException).Namespace);

        protected override void UpdateTestClass(TestClass testClass) =>
            AddTestCase(testClass);

        private static readonly string throwExceptionTestCase = @"
[Fact(Skip = ""Remove this Skip property to run this test"")]
public void No_negative_numbers()
{
    Assert.Throws<ArgumentOutOfRangeException>(() => Sieve.Primes(-1));
}";

        private static void AddTestCase(TestClass testClass) =>
            testClass.AdditionalMethods.Add(throwExceptionTestCase);
    }
}