using System;
using System.Collections.Generic;
using System.Linq;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class SgfParsing : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            if (testMethod.ExpectedIsError)
                testMethod.ExceptionThrown = typeof(ArgumentException);
            else
            {
                testMethod.Expected = RenderTree(testMethod.Expected);
                testMethod.Assert = "AssertEqual(expected, SgfParser.ParseTree(encoded));";
            }

            testMethod.TestedClass = "SgfParser";
            testMethod.TestedMethod = "ParseTree";
            testMethod.UseVariablesForInput = true;
            testMethod.UseVariableForExpected = true;
            testMethod.Input["encoded"] = testMethod.Input.FirstOrDefault().Value.Replace("\\", "\\\\");
        }

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(ArgumentException).Namespace!);
            namespaces.Add(typeof(Dictionary<string, string[]>).Namespace!);
        }

        protected override void UpdateTestClass(TestClass testClass) => AddAssertEqualMethod(testClass);

        private void AddAssertEqualMethod(TestClass testClass) =>
            testClass.AdditionalMethods.Add(@"
    private void AssertEqual(SgfTree expected, SgfTree actual)
    {
        Assert.Equal(expected.Data, actual.Data);
        Assert.Equal(expected.Children.Length, actual.Children.Length);
        for (var i = 0; i < expected.Children.Length; i++)
        {
            AssertEqual(expected.Children[i], actual.Children[i]);
        }
    }");

        private UnescapedValue? RenderTree(dynamic tree)
        {
            if (tree == null)
            {
                return null;
            }

            var label = Render.Object(tree["properties"]).Replace("object", "string[]");
            if (tree.ContainsKey("children"))
            {
                var children = string.Empty;

                if (tree["children"] is JArray)
                    children = string.Join(", ", ((JArray)tree["children"]).Select(RenderTree));
                else if (tree["children"] is object[])
                    children = string.Join(", ", ((object[])tree["children"]).Select(RenderTree));

                if (!string.IsNullOrEmpty(children))
                    return new UnescapedValue($"new SgfTree({label}, {children})");
            }

            return new UnescapedValue($"new SgfTree({label})");
        }
    }
}