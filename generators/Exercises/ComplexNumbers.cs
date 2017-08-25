using System;
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
            
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.TestedMethodType = TestedMethodType.Instance;

                // Process expected
                if (IsComplexNumber(canonicalDataCase.Expected))
                {
                    canonicalDataCase.UseVariableForExpected = true;
                }

                canonicalDataCase.Expected = ConvertToType(canonicalDataCase.Expected);

                // Process constructor param
                var constructorParamName = canonicalDataCase.Input.ContainsKey("input") ? "input" : "z1";

                var constructorParamValues = canonicalDataCase.Input[constructorParamName].ConvertToEnumerable<double>().ToArray();

                canonicalDataCase.ConstructorInput = new Dictionary<string, object>
                {
                    ["real"] = constructorParamValues[0],
                    ["imaginary"] = constructorParamValues[1]
                };

                canonicalDataCase.Input.Remove(constructorParamName);

                // Process function param
                var keys = canonicalDataCase.Input.Keys.ToArray();

                foreach (var key in keys)
                {
                    canonicalDataCase.Input[key] = ConvertToType(canonicalDataCase.Input[key]);
                }
            }
        }

        private object ConvertToType(object rawValue)
        {
            if (IsComplexNumber(rawValue))
            {
                var array = rawValue
                    .ConvertToEnumerable<string>()
                    .Select(rv => ConvertToType(rv))
                    .ToArray();

                return new UnescapedValue($"new ComplexNumber({array[0]}, {array[1]})");
            }
            else if (rawValue is string)
            {
                return double.Parse(rawValue as string);
            }
            else
            {
                return rawValue;
            }
        }

        private bool IsComplexNumber(object rawValue)
        {
            return rawValue is JArray;
        }
    }
}