using System;
using System.Linq;
using System.Text;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;
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

        private static string RenderArrange(TestMethod method)
        {
            var arrange = new StringBuilder();
            var tree = RenderTree(method.Data.Input["initialTree"]);
            arrange.AppendLine($"var tree = {tree};");
            arrange.AppendLine("var sut = Zipper.FromTree(tree);");

            var operations = RenderOperations(method.Data.Input["operations"]);
            arrange.AppendLine($"var actual = sut{operations};");
            return arrange.ToString();
        }

        private string RenderAssert(TestMethod method)
        {
            var expected = RenderExpected(method.Data.Expected);
            if (expected == null)
            {
                return Render.AssertNull("actual");
            }

            var assert = new StringBuilder();
            assert.AppendLine($"var expected = {expected};");
            assert.AppendLine(Render.AssertEqual("expected", "actual"));
            return assert.ToString();
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