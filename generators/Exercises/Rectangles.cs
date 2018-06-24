using System;
using System.Collections.Generic;
using Generators.Output;

namespace Generators.Exercises
{
    public class Rectangles : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.TestedMethod = "Count";
            data.Input["strings"] = data.Input["strings"] as string[] ?? Array.Empty<string>();
            data.UseVariablesForInput = true;
        }

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Array).Namespace);
        }
    }
}