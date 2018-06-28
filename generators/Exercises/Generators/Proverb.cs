using System;
using System.Collections.Generic;
using Exercism.CSharp.Output;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Proverb : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.UseVariableForExpected = true;
            
            if (data.Input["strings"] is JArray)
                data.Input["strings"] = Array.Empty<string>();
            
            if (data.Expected is JArray)
                data.Expected = Array.Empty<string>();
        }

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Array).Namespace);
        }
    }
}