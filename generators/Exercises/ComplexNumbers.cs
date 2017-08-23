using System.Collections.Generic;
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
            canonicalData.Exercise = "complex-number";

            canonicalData.Cases = canonicalData.Cases.Where(c => c.Property != "exp").ToArray();
            
            foreach (var canonicalDataCase in CanonicalData.Cases)
            {
                canonicalDataCase.TestedMethodType = TestedMethodType.Instance;

                if (IsComplexNumber(canonicalDataCase.Expected))
                {
                    canonicalDataCase.UseVariableForExpected = true;
                    canonicalDataCase.Expected = ConvertToComplexNumber(canonicalDataCase.Expected);
                }

                var constructorParamName = canonicalDataCase.Input.ContainsKey("input") ? "input" : "z1";

                var value = canonicalDataCase.Input[constructorParamName].ConvertToEnumerable<int>().ToArray();

                canonicalDataCase.ConstructorInput = new Dictionary<string, object>
                {
                    ["real"] = value[0],
                    ["imaginary"] = value[1]
                };

                canonicalDataCase.Input.Remove(constructorParamName);

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
            return new UnescapedValue($"new ComplexNumber({array[0]}, {array[1]})");
        }
    }
}