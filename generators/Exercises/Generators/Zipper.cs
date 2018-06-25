using System;
using System.Collections.Generic;
using System.Linq;
using Exercism.CSharp.Output;
using Humanizer;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Zipper : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod method)
        {
            method.Arrange = RenderArrange(method);
            method.Assert = RenderAssert(method);
        }

        private static IEnumerable<string> RenderArrange(TestMethod method)
        {
            var tree = RenderTree(method.Data.Input["initialTree"]);
            yield return $"var tree = {tree};";
            yield return "var sut = Zipper.FromTree(tree);";

            var operations = RenderOperations(method.Data.Input["operations"]);
            yield return $"var actual = sut{operations};";
        }

        private static IEnumerable<string> RenderAssert(TestMethod method)
        {
            var expected = RenderExpected(method.Data.Expected);
            if (expected == null)
            {
                yield return "Assert.Null(actual);";
            }
            else
            {
                yield return $"var expected = {expected};";
                yield return "Assert.Equal(expected, actual);";
            }
        }

        private static string RenderTree(dynamic tree)
        {
            if (tree == null)
            {
                return "null";
            }

            var value = tree["value"];
            var left = tree["left"] == null ? "null" : RenderTree(tree["left"]);
            var right = tree["right"] == null ? "null" : RenderTree(tree["right"]);

            return $"new BinTree({value}, {left}, {right})";
        }

        private static string RenderOperations(dynamic operations)
        {
            if (operations.Length == 0)
            {
                return "";
            }

            return "." + string.Join(".", ((object[])operations).Select(RenderOperation));
        }

        private static string RenderOperation(dynamic operation)
        {
            var operationType = (string)operation["operation"];

            switch (operationType)
            {
                case "set_value":
                    return $"SetValue({operation["item"]})";
                case "set_left":
                    return $"SetLeft({RenderTree(operation["item"])})";
                case "set_right":
                    return $"SetRight({RenderTree(operation["item"])})";
                default:
                    return $"{operationType.Pascalize()}()";
            }
        }

        private static string RenderExpected(dynamic expected)
        {
            switch (expected["type"])
            {
                case "int":
                    return expected["value"].ToString();
                case "zipper":
                    if (expected.TryGetValue("value", out dynamic value) && value == null)
                    {
                        return null;
                    }

                    var tree = RenderTree(expected["initialTree"]);
                    var operations = RenderOperations(expected["operations"]);
                    return $"Zipper.FromTree({tree}){operations}";
                case "tree":
                    return RenderTree(expected["value"]);
                default:
                    throw new ArgumentException("Unknown expected type");
            }
        }
    }
}