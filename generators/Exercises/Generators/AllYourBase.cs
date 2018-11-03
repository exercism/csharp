using System;
using System.Collections.Generic;
using Exercism.CSharp.Output;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Exercises.Generators
{
    public class AllYourBase : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            if (testMethod.Input["digits"] is JArray)
                testMethod.Input["digits"] = Array.Empty<int>();

            if (testMethod.ExpectedIsError)
                testMethod.ExceptionThrown = typeof(ArgumentException);

            testMethod.UseVariablesForInput = true;
            testMethod.UseVariableForExpected = true;
        }

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Array).Namespace);
        }
    }
}