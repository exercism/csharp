using System;
using System.Collections.Generic;
using System.Text;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class CircularBuffer : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.Assert = RenderAssert(testMethod);
        }

        private string RenderAssert(TestMethod testMethod)
        {
            var assert = new StringBuilder();
            assert.AppendLine(RenderSut(testMethod));

            foreach (var operation in testMethod.Input["operations"])
                assert.AppendLine(RenderOperation(operation));

            return assert.ToString();
        }

        private string RenderSut(TestMethod testMethod)
            => Render.Variable("buffer", $"new CircularBuffer<int>(capacity: {testMethod.Input["capacity"]})");

        private string RenderOperation(dynamic operation)
        {
            switch (operation["operation"])
            {
                case "read":
                    return RenderReadOperation(operation);
                case "write":
                    return RenderWriteOperation(operation);
                case "overwrite":
                    return RenderOverwriteOperation(operation);
                case "clear":
                    return RenderClearOperation();
                default:
                    throw new ArgumentOutOfRangeException($"Unknown operation type: {operation["operation"]}");
            }
        }

        private string RenderReadOperation(dynamic operation) 
            => operation["should_succeed"]
                ? Render.AssertEqual(operation["expected"].ToString(), "buffer.Read()")
                : Render.AssertThrows<InvalidOperationException>("buffer.Read()");

        private string RenderWriteOperation(dynamic operation) 
            => operation["should_succeed"]
                ? $"buffer.Write({operation["item"]});"
                : Render.AssertThrows<InvalidOperationException>($"buffer.Write({operation["item"]})");

        private static string RenderOverwriteOperation(dynamic operation)
            => $"buffer.Overwrite({operation["item"]});";

        private static string RenderClearOperation()
            => "buffer.Clear();";

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(InvalidOperationException).Namespace);
        }
    }
}