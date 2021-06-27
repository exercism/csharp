using System;
using System.Collections.Generic;
using System.Linq;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class WordCount : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.UseVariableForExpected = true;
            testMethod.UseVariableForTested = true;
            testMethod.Expected = ConvertExpected(testMethod.Expected);
        }

        private static dynamic ConvertExpected(dynamic expected)
            => ((Dictionary<string, object>)expected).ToDictionary(kv => kv.Key, kv => Convert.ToInt32(kv.Value));

        protected override void UpdateNamespaces(ISet<string> namespaces) => namespaces.Add(typeof(Dictionary<string, int>).Namespace!);
    }
}
