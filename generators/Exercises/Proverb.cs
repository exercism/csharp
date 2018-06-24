using System;
using System.Collections.Generic;
using Generators.Helpers;
using Generators.Input;
using Generators.Output;

namespace Generators.Exercises
{
    public class Proverb : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.UseVariableForExpected = true;
            data.Input["strings"] = ConvertHelper.ToArray<string>(data.Input["strings"]);
            data.Expected = ConvertHelper.ToArray<string>(data.Expected);
        }

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Array).Namespace);
        }
    }
}