using System;
using System.Collections.Generic;
using System.Linq;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class Alphametics : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.UseVariableForExpected = true;
            testMethod.UseVariableForTested = true;

            if (testMethod.Expected == null)
                testMethod.ExceptionThrown = typeof(ArgumentException);
            else
                testMethod.Expected = ConvertExpected(testMethod);
        }

        private static dynamic ConvertExpected(TestMethod testMethod)
        {
            Dictionary<string, object> expected = testMethod.Expected!;
            return expected.ToDictionary(kv => kv.Key[0], kv => Convert.ToInt32(kv.Value));
        }

        protected override void UpdateNamespaces(ISet<string> namespaces) => namespaces.Add(typeof(Dictionary<char, int>).Namespace!);
    }
}