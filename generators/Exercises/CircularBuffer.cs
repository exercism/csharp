using System;
using System.Collections.Generic;
using Generators.Output;

namespace Generators.Exercises
{
    public class CircularBuffer : GeneratorExercise
    {
        protected override IEnumerable<string> RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            yield return RenderSut(testMethodBody.Data);

            foreach (var operation in testMethodBody.Data.Input["operations"])
                yield return RenderOperation(operation);
        }

        private static string RenderSut(TestMethodBodyData canonicalDataCase)
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
                ? $"Assert.Equal({operation["expected"]}, buffer.Read());"
                : "Assert.Throws<InvalidOperationException>(() => buffer.Read());";
        }

        private static string RenderWriteOperation(dynamic operation)
        {
            return operation["should_succeed"]
                ? $"buffer.Write({operation["item"]});"
                : $"Assert.Throws<InvalidOperationException>(() => buffer.Write({operation["item"]}));";
        }

        private static string RenderOverwriteOperation(dynamic operation)
            => $"buffer.Overwrite({operation["item"]});";

        private static string RenderClearOperation()
            => "buffer.Clear();";

        protected override IEnumerable<string> AdditionalNamespaces => new[] { typeof(InvalidOperationException).Namespace };
    }
}