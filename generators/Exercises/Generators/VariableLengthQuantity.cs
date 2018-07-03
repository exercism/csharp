using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class VariableLengthQuantity : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.UseVariableForExpected = true;
            data.UseVariablesForInput = true;
            data.Input["integers"] = ConvertToUInt32Array(data.Input["integers"]);

            if (data.Expected == null)
                data.ExceptionThrown = typeof(InvalidOperationException);
            else
                data.Expected = ConvertToUInt32Array(data.Expected);
        }

        private static uint[] ConvertToUInt32Array(IEnumerable input) 
            => input.Cast<object>().Select(number => Convert.ToUInt32(number.ToString())).ToArray();

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Array).Namespace);
        }
    }
}