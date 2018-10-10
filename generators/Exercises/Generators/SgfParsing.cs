using System;
using System.Collections.Generic;
using System.Linq;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Exercises.Generators
{
    public class SgfParsing : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            if (testMethod.Expected is Dictionary<string, object> &&
                (testMethod.Expected as Dictionary<string, object>).ContainsKey("error"))
                testMethod.ExceptionThrown = typeof(ArgumentException);
            else
                testMethod.Expected = RenderTree(testMethod.Expected);

            testMethod.TestedClass = "SgfParser";
            testMethod.TestedMethod = "ParseTree";
            testMethod.UseVariablesForInput = true;
            testMethod.UseVariableForExpected = true;
            testMethod.Input["encoded"] = testMethod.Input.FirstOrDefault().Value.Replace("\\","\\\\");
        }

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(ArgumentException).Namespace);
            namespaces.Add(typeof(Dictionary<string, string[]>).Namespace);
        }

        private UnescapedValue RenderTree(dynamic tree)
        {
            if (tree == null)
            {
                return null;
            }

            var label = Render.Object(tree["properties"]);
            label = (label as string).Replace("object", "string[]");
            if (tree.ContainsKey("children"))
            {
                var children = string.Empty;

                if(tree["children"] is JArray)
                    children = string.Join(",", ((JArray)tree["children"]).Select(RenderTree));

                if (tree["children"] is object[])
                    children = string.Join(", ", ((object[])tree["children"]).Select(RenderTree));

                if (!string.IsNullOrEmpty(children))
                    children = "," + children;

                return new UnescapedValue($"new SgfTree({label} {children})");
            }

            return new UnescapedValue($"new SgfTree({label})");
        }
    }
}