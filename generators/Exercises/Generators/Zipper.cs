using System;
using System.Linq;
using System.Text;
using Exercism.CSharp.Helpers;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Zipper : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.Arrange = RenderArrange(testMethod);
            testMethod.Assert = RenderAssert(testMethod);
        }

        private string RenderArrange(TestMethod testMethod)
        {
            var arrange = new StringBuilder();
            var tree = RenderTree(testMethod.Input["initialTree"]);
            arrange.AppendLine(Render.Variable("tree", tree));
            arrange.AppendLine(Render.Variable("sut", "Zipper.FromTree(tree)"));

            var operations = RenderOperations(testMethod.Input["operations"]);
            arrange.AppendLine(Render.Variable("actual", $"sut{operations}"));
            return arrange.ToString();
        }

        private string RenderAssert(TestMethod testMethod)
        {
            var expected = RenderExpected(testMethod.Expected);
            if (expected == null)
            {
                return Render.AssertNull("actual");
            }

            var assert = new StringBuilder();
            assert.AppendLine(Render.Variable("expected", expected));
            assert.AppendLine(Render.AssertEqual("expected", "actual"));
            return assert.ToString();
        }

        private static string RenderTree(dynamic tree)
        {
            if (tree == null)
                return "null";

            return $"new BinTree({tree["value"]}, {RenderTree(tree["left"])}, {RenderTree(tree["right"])})";
        }

        private static string RenderOperations(dynamic operations)
        {
            if (operations.Length == 0)
                return "";

            return "." + string.Join(".", ((object[])operations).Select(RenderOperation));
        }

        private static string RenderOperation(dynamic operation)
        {
            var operationType = (string)operation["operation"];
            var operationMethod = operationType.ToMethodName();

            switch (operationType)
            {
                case "set_value":
                    return $"{operationMethod}({operation["item"]})";
                case "set_left":
                case "set_right":
                    return $"{operationMethod}({RenderTree(operation["item"])})";
                default:
                    return $"{operationMethod}()";
            }
        }

        private string RenderExpected(dynamic expected)
        {
            switch (expected["type"])
            {
                case "int":
                    return Render.Object(expected["value"]);
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