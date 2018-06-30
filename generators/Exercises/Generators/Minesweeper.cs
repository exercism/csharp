using System;
using System.Collections.Generic;
using Exercism.CSharp.Output;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Minesweeper : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.UseVariablesForInput = true;
            data.UseVariableForExpected = true;
            
            if (data.Input["minefield"] is JArray)
                data.Input["minefield"] = Array.Empty<string>();
        }

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Array).Namespace);
        }
    }
}
