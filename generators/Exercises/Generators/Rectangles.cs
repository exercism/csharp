using System;
using System.Collections.Generic;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Rectangles : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.UseVariablesForInput = true;
            data.TestedMethod = "Count";
            
            if (data.Input["strings"] is JArray)
                data.Input["strings"] = Array.Empty<string>();
            
            data.Input["strings"] = new UnescapedValue(Render.ArrayMultiLine(data.Input["strings"]));
        }

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Array).Namespace);
        }
    }
}