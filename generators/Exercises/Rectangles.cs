using System;
using System.Collections.Generic;
using Generators.Input;

namespace Generators.Exercises
{
    public class Rectangles : GeneratorExercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.Property = "count";
                canonicalDataCase.Input["strings"] = canonicalDataCase.Input["strings"] as string[] ?? Array.Empty<string>();
                canonicalDataCase.UseVariablesForInput = true;
            }
        }

        protected override IEnumerable<string> AdditionalNamespaces => new[] { typeof(Array).Namespace };
    }
}