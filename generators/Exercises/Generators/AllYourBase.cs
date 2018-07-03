using System;
using System.Collections.Generic;
using Exercism.CSharp.Output;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Exercises.Generators
{
    public class AllYourBase : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            if (data.Input["digits"] is JArray)
                data.Input["digits"] = Array.Empty<int>();

            if (data.Expected is Dictionary<string, object>)
                data.ExceptionThrown = typeof(ArgumentException);

            data.UseVariablesForInput = true;
            data.UseVariableForExpected = true;
        }

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Array).Namespace);
        }
    }
}