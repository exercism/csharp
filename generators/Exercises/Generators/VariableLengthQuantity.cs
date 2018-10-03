using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class VariableLengthQuantity : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.UseVariableForExpected = true;
            testMethod.UseVariablesForInput = true;
            testMethod.Input["integers"] = ConvertToUInt32Array(testMethod.Input["integers"]);

            if (testMethod.Expected == null || testMethod.Expected is Dictionary<string,object> objError)
                testMethod.ExceptionThrown = typeof(InvalidOperationException);
            else
                testMethod.Expected = ConvertToUInt32Array(testMethod.Expected);
        }

        private static uint[] ConvertToUInt32Array(IEnumerable input) 
            => input.Cast<object>().Select(number => Convert.ToUInt32(number.ToString())).ToArray();

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Array).Namespace);
        }
    }
}