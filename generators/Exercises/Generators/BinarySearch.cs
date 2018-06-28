using System;
using System.Collections.Generic;
using Exercism.CSharp.Output;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Exercises.Generators
{
    public class BinarySearch : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            if (data.Input["array"] is JArray)
                data.Input["array"] = Array.Empty<int>();
            
            data.UseVariablesForConstructorParameters = true;
            data.SetConstructorInputParameters("array");
        }

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Array).Namespace);
        }
    }
}