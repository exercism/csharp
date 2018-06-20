using System;
using System.Collections.Generic;
using Generators.Input;
using Generators.Output;

namespace Generators.Exercises
{
    public class BookStore : GeneratorExercise
    {
        protected override void UpdateTestMethodBodyData(TestMethodBodyData data)
        {
            data.Expected = data.Expected / 100.0f;
            data.Input["basket"] = ConvertHelper.ToArray<int>(data.Input["basket"]);
            data.SetInputParameters("basket");
            data.UseVariablesForInput = true;
        }

        protected override IEnumerable<string> AdditionalNamespaces => new[] { typeof(Array).Namespace };
    }
}