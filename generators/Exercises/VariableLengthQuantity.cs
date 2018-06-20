using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Generators.Output;

namespace Generators.Exercises
{
    public class VariableLengthQuantity : GeneratorExercise
    {
        protected override void UpdateTestMethodBodyData(TestMethodBodyData data)
        {
            data.UseVariableForExpected = true;
            data.UseVariablesForInput = true;
            data.Input["integers"] = FormatUInt32Array(data.Input["integers"]);

            if (data.Expected == null)
                data.ExceptionThrown = typeof(InvalidOperationException);
            else
                data.Expected = FormatUInt32Array(data.Expected);
        }

        protected override IEnumerable<string> AdditionalNamespaces => new[] { typeof(Array).Namespace };

        private static dynamic FormatUInt32Array(dynamic input)
        {
            var numbers = ToUInt32Array(input as IEnumerable);
            return numbers.Select(number => new UnescapedValue(string.Format("0x{0:X}u", number))).ToArray();
        }

        private static IEnumerable<uint> ToUInt32Array(IEnumerable input)
        {
            return input.Cast<object>().Select(number => Convert.ToUInt32(number.ToString()));
        }
    }
}