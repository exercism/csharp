using System;
using System.Collections.Generic;
using System.Text;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    public class CircularBuffer : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod method)
        {
            method.Assert = RenderAssert(method);
        }

        private string RenderAssert(TestMethod method)
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
        {
            return operation["should_succeed"]
                ? Render.AssertEqual(operation["expected"].ToString(), "buffer.Read()")
                : Render.AssertThrows<InvalidOperationException>("buffer.Read()");
        }

        private string RenderWriteOperation(dynamic operation)
        {
            return operation["should_succeed"]
                ? $"buffer.Write({operation["item"]});"
                : Render.AssertThrows<InvalidOperationException>($"buffer.Write({operation["item"]})");
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