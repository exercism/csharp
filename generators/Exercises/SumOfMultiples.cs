using System;
using System.Collections.Generic;
using Generators.Input;

namespace Generators.Exercises
{
    public class SumOfMultiples : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            canonicalDataCase.Input["factors"] = ConvertHelper.ToArray<int>(canonicalDataCase.Input["factors"]);
        }

        protected override IEnumerable<string> AdditionalNamespaces => new[] { typeof(Array).Namespace };
    }
}