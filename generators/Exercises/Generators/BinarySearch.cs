using System;
using System.Collections.Generic;
using Exercism.CSharp.Helpers;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class BinarySearch : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.Input["array"] = ConvertHelper.ToArray<int>(data.Input["array"]);
            data.UseVariablesForConstructorParameters = true;
            data.SetConstructorInputParameters("array");
        }

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Array).Namespace);
        }
    }
}