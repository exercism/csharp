using System;
using System.Collections.Generic;
using Exercism.CSharp.Helpers;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class AllYourBase : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.Input["digits"] = ConvertHelper.ToArray<int>(data.Input["digits"]);
            data.ExceptionThrown = data.Expected is Dictionary<string, object> ? typeof(ArgumentException) : null;
            data.UseVariablesForInput = true;
            data.UseVariableForExpected = true;
        }

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Array).Namespace);
        }
    }
}