﻿using System;
using System.Collections.Generic;
using System.Linq;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class NucleotideCount : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            if (testMethod.Expected.ContainsKey("error"))
            {
                testMethod.ExceptionThrown = typeof(ArgumentException);
                testMethod.TestedMethodType = TestedMethodType.Constructor;
            }
            else
            {
                testMethod.Expected = ConvertExpected(testMethod.Expected);
                testMethod.TestedMethodType = TestedMethodType.Property;
            }

            testMethod.UseVariableForExpected = true;
            testMethod.ConstructorInputParameters = new[] { "strand" };
        }

        private static dynamic ConvertExpected(dynamic expected)
            => ((Dictionary<string, object>)expected).ToDictionary(kv => kv.Key[0], kv => Convert.ToInt32(kv.Value));

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(ArgumentException).Namespace);
            namespaces.Add(typeof(Dictionary<char, int>).Namespace);
        }
    }
}
