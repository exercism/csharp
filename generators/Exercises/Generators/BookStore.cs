using System;
using System.Collections.Generic;
using Exercism.CSharp.Helpers;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class BookStore : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.Expected = data.Expected / 100.0f;
            data.Input["basket"] = ConvertHelper.ToArray<int>(data.Input["basket"]);
            data.SetInputParameters("basket");
            data.UseVariablesForInput = true;
        }

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Array).Namespace);
        }
    }
}