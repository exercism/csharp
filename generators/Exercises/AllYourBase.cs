using System;
using System.Collections.Generic;
using Generators.Input;

namespace Generators.Exercises
{
    public class AllYourBase : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            canonicalDataCase.Input["digits"] = ConvertHelper.ToArray<int>(canonicalDataCase.Input["digits"]);
            canonicalDataCase.ExceptionThrown = canonicalDataCase.Expected is Dictionary<string, object> ? typeof(ArgumentException) : null;
            canonicalDataCase.UseVariablesForInput = true;
            canonicalDataCase.UseVariableForExpected = true;
        }

        protected override IEnumerable<string> AdditionalNamespaces => new[] { typeof(Array).Namespace };
    }
}