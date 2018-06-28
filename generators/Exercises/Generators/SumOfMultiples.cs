using System;
using System.Collections.Generic;
using Exercism.CSharp.Output;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Exercises.Generators
{
    public class SumOfMultiples : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            if (data.Input["factors"] is JArray)
                data.Input["factors"] = Array.Empty<int>();
        }

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Array).Namespace);
        }
    }
}