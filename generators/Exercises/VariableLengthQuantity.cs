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
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.UseVariableForExpected = true;
                canonicalDataCase.UseVariablesForInput = true;
                canonicalDataCase.Input["integers"] = FormatUInt32Array(canonicalDataCase.Input["integers"]);

                if (canonicalDataCase.Expected == null)
                    canonicalDataCase.ExceptionThrown = typeof(InvalidOperationException);
                else
                    canonicalDataCase.Expected = FormatUInt32Array(canonicalDataCase.Expected);
            }
        }

        private dynamic FormatUInt32Array(dynamic input)
        {
            var numbers = ToUInt32Array(input as IEnumerable);
            if (!numbers.Any())
            {
                return new UnescapedValue("new uint[0]");
            }

            return numbers.Select(number => new UnescapedValue(string.Format("0x{0:X}u", number))).ToArray();
        }

        private IEnumerable<uint> ToUInt32Array(IEnumerable input)
        {
            foreach (var number in input)
                yield return Convert.ToUInt32(number.ToString());
        }
    }
}