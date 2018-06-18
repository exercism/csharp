using System;
using System.Collections.Generic;
using Generators.Input;

namespace Generators.Exercises
{
    public class Proverb : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            canonicalDataCase.UseVariableForExpected = true;
            canonicalDataCase.Input["strings"] = ConvertHelper.ToArray<string>(canonicalDataCase.Input["strings"]);
            canonicalDataCase.Expected = ConvertHelper.ToArray<string>(canonicalDataCase.Expected);
        }

        protected override IEnumerable<string> AdditionalNamespaces => new[] { typeof(Array).Namespace };
    }
}