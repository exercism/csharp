using System;
using System.Collections.Generic;
using System.Text;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class CircularBuffer : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod method)
        {
            method.Assert = RenderAssert(method);
        }

        private static string RenderAssert(TestMethod method)
        {
            var assert = new StringBuilder();
            assert.AppendLine(RenderSut(method.Data));

            foreach (var operation in method.Data.Input["operations"])
                assert.AppendLine(RenderOperation(operation));

            return assert.ToString();
        }

        private static string RenderSut(TestData canonicalDataCase)
        {
            var capacity = canonicalDataCase.Input["capacity"];
            return $"var buffer = new CircularBuffer<int>(capacity: {capacity});";
        }

        private static string RenderOperation(dynamic operation)
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

        private static string RenderReadOperation(dynamic operation)
        {
            return operation["should_succeed"]
                ? Assertion.Equal(operation["expected"].ToString(), "buffer.Read()")
                : Assertion.Throws("InvalidOperationException", "buffer.Read()");
        }

        private static string RenderWriteOperation(dynamic operation)
        {
            return operation["should_succeed"]
                ? $"buffer.Write({operation["item"]});"
                : Assertion.Throws("InvalidOperationException", $"buffer.Write({operation["item"]})");
        }

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