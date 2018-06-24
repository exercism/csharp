using System;
using System.Collections.Generic;
using Exercism.CSharp.Helpers;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class SumOfMultiples : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.Input["factors"] = ConvertHelper.ToArray<int>(data.Input["factors"]);
        }

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Array).Namespace);
        }
    }
}