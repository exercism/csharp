using System.Collections.Generic;
using System.Linq;
using Generators.Output;

namespace Generators.Exercises
{
    public class WordCount : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.UseVariableForExpected = true;
            data.UseVariableForTested = true;
            data.Expected = ConvertExpected(data.Expected);
        }

        private static dynamic ConvertExpected(dynamic expected)
            => ((Dictionary<string, object>)expected).ToDictionary(kv => kv.Key, kv => int.Parse(kv.Value.ToString()));

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Dictionary<string, int>).Namespace);
        }
    }
}
