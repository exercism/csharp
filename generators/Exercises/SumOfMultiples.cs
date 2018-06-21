using System;
using System.Collections.Generic;
using Generators.Input;
using Generators.Output;

namespace Generators.Exercises
{
    public class SumOfMultiples : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.Input["factors"] = ConvertHelper.ToArray<int>(data.Input["factors"]);
        }

        protected override IEnumerable<string> AdditionalNamespaces => new[] { typeof(Array).Namespace };
    }
}