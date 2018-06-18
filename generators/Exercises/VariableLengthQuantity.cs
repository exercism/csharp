using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Generators.Input;
using Generators.Output;

namespace Generators.Exercises
{
    public class VariableLengthQuantity : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            canonicalDataCase.UseVariableForExpected = true;
            canonicalDataCase.UseVariablesForInput = true;
            canonicalDataCase.Input["integers"] = FormatUInt32Array(canonicalDataCase.Input["integers"]);

            if (canonicalDataCase.Expected == null)
                canonicalDataCase.ExceptionThrown = typeof(InvalidOperationException);
            else
                canonicalDataCase.Expected = FormatUInt32Array(canonicalDataCase.Expected);
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