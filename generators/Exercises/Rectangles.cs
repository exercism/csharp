using System;
using System.Collections.Generic;
using Generators.Output;

namespace Generators.Exercises
{
    public class Rectangles : GeneratorExercise
    {
        protected override void UpdateTestMethodBodyData(TestMethodBodyData data)
        {
            data.Property = "count";
            data.Input["strings"] = data.Input["strings"] as string[] ?? Array.Empty<string>();
            data.UseVariablesForInput = true;
        }

        protected override IEnumerable<string> AdditionalNamespaces => new[] { typeof(Array).Namespace };
    }
}