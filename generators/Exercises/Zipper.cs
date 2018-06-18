using System;
using System.Linq;
using System.Text;
using Generators.Output;
using Humanizer;

namespace Generators.Exercises
{
    public class Zipper : GeneratorExercise
    {
        protected override string RenderTestMethodBodyArrange(TestMethodBody testMethodBody)
        {
            var arrange = new StringBuilder();

            var tree = RenderTree(testMethodBody.CanonicalDataCase.Input["initialTree"]);
            arrange.AppendLine($"var tree = {tree};");
            arrange.AppendLine("var sut = Zipper.FromTree(tree);");

            var operations = RenderOperations(testMethodBody.CanonicalDataCase.Input["operations"]);
            arrange.AppendLine($"var actual = sut{operations};");

            return arrange.ToString();
        }

        protected override string RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            var assert = new StringBuilder();

            var expected = RenderExpected(testMethodBody.CanonicalDataCase.Expected);
            if (expected == null)
            {
                assert.AppendLine("Assert.Null(actual);");
            }
            else
            {
                assert.AppendLine($"var expected = {expected};");
                assert.AppendLine("Assert.Equal(expected, actual);");
            }

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