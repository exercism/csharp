using System;
using System.Collections.Generic;
using System.Linq;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Etl : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.UseVariablesForInput = true;
            testMethod.UseVariableForExpected = true;
            
            var input = ConvertInput(testMethod.Input["legacy"]);
            testMethod.Input.Clear();
            testMethod.Input["input"] = input;
            testMethod.Expected = ConvertExpected(testMethod.Expected);
            testMethod.InputParameters = new[] { "input" };
        }

        private static dynamic ConvertExpected(dynamic expected)
            => ((Dictionary<string, object>)expected).ToDictionary(kv => kv.Key, kv => Convert.ToInt32(kv.Value));

        private static IDictionary<int, string[]> ConvertInput(IDictionary<string, dynamic> input)
            => input.ToDictionary(kv => Convert.ToInt32(kv.Key), kv => (string[]) kv.Value);

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Dictionary<string, int>).Namespace);
        }
    }
}
