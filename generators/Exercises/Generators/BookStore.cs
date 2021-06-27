using System;
using System.Collections.Generic;
using Exercism.CSharp.Output;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class BookStore : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            if (testMethod.Input["basket"] is JArray)
                testMethod.Input["basket"] = Array.Empty<int>();
            
            testMethod.Expected = testMethod.Expected / 100.0m;
            testMethod.InputParameters = new[] { "basket" };
            testMethod.UseVariablesForInput = true;
        }

        protected override void UpdateNamespaces(ISet<string> namespaces) => namespaces.Add(typeof(Array).Namespace!);
    }
}