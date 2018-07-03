using System;
using System.Collections.Generic;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    public class OcrNumbers : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.ExceptionThrown = data.Expected is int i && i <= 0 ? typeof(ArgumentException) : null;
            data.Input["rows"] = new MultiLineString(data.Input["rows"]);
            data.Expected = data.Expected.ToString();
            data.UseVariableForTested = true;
            data.UseVariablesForInput = true;
        }

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Array).Namespace);
        }
    }
}
