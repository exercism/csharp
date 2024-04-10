using System;
using System.Collections.Generic;
using System.Linq;
using Exercism.CSharp.Output;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class GameOfLife : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.UseVariablesForInput = true;
            testMethod.UseVariableForExpected = true;

            testMethod.Input["matrix"] = ToMultiDimensionalArray(testMethod.Input["matrix"]);
            testMethod.Expected = ToMultiDimensionalArray(testMethod.Expected);
        }

        protected override void UpdateNamespaces(ISet<string> namespaces) => namespaces.Add(typeof(Array).Namespace!);

        private static dynamic ToMultiDimensionalArray(JToken jArray) => jArray.ToObject<int[,]>()!;
    }
}
