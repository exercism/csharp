using System;
using System.Collections.Generic;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    public class OcrNumbers : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            if (!(testMethod.Expected is string))
            {
                testMethod.ExceptionThrown = typeof(ArgumentException);
            }

            testMethod.Input["rows"] = new MultiLineString(testMethod.Input["rows"]);
            testMethod.Expected = testMethod.Expected.ToString();
            testMethod.UseVariableForTested = true;
            testMethod.UseVariablesForInput = true;
        }

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Array).Namespace);
        }
    }
}
