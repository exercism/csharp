using System;
using System.Collections.Generic;
using System.Text;
using Generators.Input;
using Generators.Output;

namespace Generators.Exercises
{
    public class CircularBuffer : GeneratorExercise
    {
        protected override string RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            var lines = new StringBuilder();
            lines.AppendLine(RenderSut(testMethodBody.CanonicalDataCase));

            foreach (var operation in testMethodBody.CanonicalDataCase.Input["operations"])
                lines.AppendLine(RenderOperation(operation));

            return lines.ToString();
        }

        private static string RenderSut(CanonicalDataCase canonicalDataCase)
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
                    return RenderClearOperation(operation);
                default:
                    throw new ArgumentOutOfRangeException($"Unknown operation type: {operation["operation"]}");
            }
        }

        private static string RenderReadOperation(dynamic operation)
        {
            if (operation["should_succeed"])
            {
                return $"Assert.Equal({operation["expected"]}, buffer.Read());";
            }

            return "Assert.Throws<InvalidOperationException>(() => buffer.Read());";
        }

        private static string RenderWriteOperation(dynamic operation)
        {
            if (operation["should_succeed"])
            {
                return $"buffer.Write({operation["item"]});";
            }

            return $"Assert.Throws<InvalidOperationException>(() => buffer.Write({operation["item"]}));";
        }

        private static string RenderOverwriteOperation(dynamic operation)
            => $"buffer.Overwrite({operation["item"]});";

        private static string RenderClearOperation(dynamic operation)
            => "buffer.Clear();";

        protected override IEnumerable<string> AdditionalNamespaces() => new[] { typeof(InvalidOperationException).Namespace };
    }
}