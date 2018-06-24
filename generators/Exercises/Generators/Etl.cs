using System.Collections.Generic;
using System.Linq;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Etl : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.UseVariablesForInput = true;
            data.UseVariableForExpected = true;
            data.Input = ConvertInput(data.Input);
            data.Expected = ConvertExpected(data.Expected);
            data.SetInputParameters("input");
        }

        private static dynamic ConvertExpected(dynamic expected)
            => ((Dictionary<string, object>)expected).ToDictionary(kv => kv.Key, kv => int.Parse($"{kv.Value}"));

        private static IDictionary<string, dynamic> ConvertInput(IDictionary<string, dynamic> input)
            => new Dictionary<string, dynamic>
            {
                ["input"] = input.ToDictionary(kv => int.Parse(kv.Key), kv => (string[])kv.Value)
            };

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Dictionary<string, int>).Namespace);
        }
    }
}
