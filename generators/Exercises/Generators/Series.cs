using System;
using System.Collections.Generic;
using System.Linq;

using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators;

internal class Series : ExerciseGenerator
{
    protected override void UpdateTestMethod(TestMethod testMethod)
    {
            testMethod.UseVariableForExpected = true;

            if (!(testMethod.Expected is string[]))
                testMethod.ExceptionThrown = typeof(ArgumentException);
            
            testMethod.ForceEvaluation = true;
        }

    protected override void UpdateNamespaces(ISet<string> namespaces) => 
        namespaces.Add(typeof(Enumerable).Namespace!);
}