using System.Linq;
using Generators.Input;
using Generators.Output;
using Newtonsoft.Json.Linq;

namespace Generators.Exercises
{
    public class ComplexNumbers : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            canonicalData.Cases = canonicalData.Cases.Where(c => c.Property != "exp").ToArray();

            foreach (var canonicalDataCase in CanonicalData.Cases)
            {
                canonicalDataCase.UseVariablesForInput = true;

                if (IsComplexNumber(canonicalDataCase.Expected))
                {
                    canonicalDataCase.UseVariableForExpected = true;
                    canonicalDataCase.Expected = ConvertToComplexNumber(canonicalDataCase.Expected);
                }

                var keys = canonicalDataCase.Input.Keys.ToArray();

                foreach (var key in keys)
                {
                    if (IsComplexNumber(canonicalDataCase.Input[key]))
                    {
                        canonicalDataCase.Input[key] = ConvertToComplexNumber(canonicalDataCase.Input[key]);
                    }
                }
            }
        }

        private bool IsComplexNumber(object rawValue)
        {
            return rawValue is JArray;
        }

        private UnescapedValue ConvertToComplexNumber(object rawValue)
        {
            var array = rawValue.ConvertToEnumerable<int>().ToArray();
            return new UnescapedValue($"new ComplexNumber {{ Real = {array[0]}, Imaginary = {array[1]} }}");
        }
    }
}