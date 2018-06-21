using System;
using System.Collections.Generic;
using Generators.Input;
using Generators.Output;

namespace Generators.Exercises
{
    public class AllYourBase : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.Input["digits"] = ConvertHelper.ToArray<int>(data.Input["digits"]);
            data.ExceptionThrown = data.Expected is Dictionary<string, object> ? typeof(ArgumentException) : null;
            data.UseVariablesForInput = true;
            data.UseVariableForExpected = true;
        }

        protected override IEnumerable<string> AdditionalNamespaces => new[] { typeof(Array).Namespace };
    }
}