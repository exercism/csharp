using System;
using System.Collections.Generic;
using System.Linq;
using Generators.Output;

namespace Generators.Exercises
{
    public class Alphametics : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.UseVariableForExpected = true;
            data.UseVariableForTested = true;

            if (data.Expected == null)
                data.ExceptionThrown = typeof(ArgumentException);
            else
                data.Expected = ConvertExpected(data);
        }

        private static dynamic ConvertExpected(TestData canonicalDataCase)
        {
            Dictionary<string, object> expected = canonicalDataCase.Expected;
            return expected.ToDictionary(kv => kv.Key[0], kv => int.Parse(kv.Value.ToString()));
        }

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Dictionary<char, int>).Namespace);
        }
}
}