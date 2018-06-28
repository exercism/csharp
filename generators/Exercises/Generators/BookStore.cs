using System;
using System.Collections.Generic;
using Exercism.CSharp.Output;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Exercises.Generators
{
    public class BookStore : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            if (data.Input["basket"] is JArray)
                data.Input["basket"] = Array.Empty<int>();
            
            data.Expected = data.Expected / 100.0f;
            data.SetInputParameters("basket");
            data.UseVariablesForInput = true;
        }

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Array).Namespace);
        }
    }
}