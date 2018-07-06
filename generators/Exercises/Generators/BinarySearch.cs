using System;
using System.Collections.Generic;
using Exercism.CSharp.Output;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Exercises.Generators
{
    public class BinarySearch : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            if (testMethod.Input["array"] is JArray)
                testMethod.Input["array"] = Array.Empty<int>();
            
            testMethod.SetConstructorInputParameters("array");
            testMethod.UseVariablesForConstructorParameters = true;
        }

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Array).Namespace);
        }
    }
}