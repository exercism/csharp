using System;
using System.Collections.Generic;
using Generators.Input;

namespace Generators.Exercises
{
    public class BinarySearch : GeneratorExercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.Input["array"] = ConvertHelper.ToArray<int>(canonicalDataCase.Input["array"]);
                canonicalDataCase.UseVariablesForConstructorParameters = true;
                canonicalDataCase.SetConstructorInputParameters("array");
            }
        }

        protected override IEnumerable<string> AdditionalNamespaces => new[] { typeof(Array).Namespace };
    }
}