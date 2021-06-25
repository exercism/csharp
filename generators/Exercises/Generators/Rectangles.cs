using System;
using System.Collections.Generic;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Rectangles : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.UseVariablesForInput = true;
            testMethod.TestedMethod = "Count";
            
            if (testMethod.Input["strings"] is JArray)
                testMethod.Input["strings"] = Array.Empty<string>();
            
            testMethod.Input["strings"] = new UnescapedValue(Render.ArrayMultiLine(testMethod.Input["strings"]));
        }

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Array).Namespace);
        }
    }
}