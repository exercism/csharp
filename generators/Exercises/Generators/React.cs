using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Exercism.CSharp.Helpers;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class React : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod method)
        {
            method.Arrange = RenderArrange(method);
            method.Assert = RenderAssert();
        }

        private string RenderArrange(TestMethod method)
        {
            var arrange = new StringBuilder();
            arrange.AppendLine(Render.Variable("sut", "new Reactor()"));

            var cells = RenderCells(method.Data.Input["cells"]);
            arrange.AppendLine(cells);

            var operations = RenderOperations(method.Data.Input["operations"]);
            arrange.AppendLine(operations);

            return arrange.ToString();
        }

        private string RenderCells(object[] cells) => string.Join(Environment.NewLine, cells.Select(RenderCell));

        private string RenderCell(dynamic cell)
        {
            var cellType = (string)cell["type"];
            var cellName = ToVariableName(cell["name"]);

            switch (cellType)
            {
                case "input":
                    return Render.Variable(cellName, $"sut.CreateInputCell({cell["initial_value"]})");
                case "compute":
                    var inputs = string.Join(", ", ((string[])cell["inputs"]).Select(ToVariableName));
                    var computeFunction = RenderComputeFunction(cell["compute_function"]);
                    return Render.Variable(cellName, $"sut.CreateComputeCell(new[] {{ {inputs} }}, inputs => {computeFunction})");
                default:
                    throw new InvalidOperationException($"Unknown cell type: {cellType}");
            }
        }

        private static string RenderComputeFunction(dynamic computeFunction)
        {
            var match = Regex.Match((string)computeFunction, "if (.+) then (.+) else (.+)");

            return match.Success
                ? $"{match.Groups[1]} ? {match.Groups[2]} : {match.Groups[3]}"
                : (string)computeFunction;
        }

        private string RenderOperations(object[] operations) 
            => string.Join(Environment.NewLine, operations.Select(RenderOperation));

        private string RenderOperation(dynamic operation)
        {
            var operationType = (string)operation["type"];

            switch (operationType)
            {
                case "set_value":
                    var renderedSetValue = new StringBuilder();
                    renderedSetValue.AppendLine($"{ToVariableName(operation["cell"])}.Value = {operation["value"]};");

                    if (operation.ContainsKey("expect_callbacks_not_to_be_called"))
                    {
                        var callbacksNotToBeCalled = ((string[])operation["expect_callbacks_not_to_be_called"]).Select(ToVariableName);

                        foreach (var callbackNotToBeCalled in callbacksNotToBeCalled)
                        {
                            renderedSetValue.AppendLine($"A.CallTo(() => {callbackNotToBeCalled}.Invoke(A<object>._, A<int>._)).MustNotHaveHappened();");
                        }
                    }
                    else if (operation.ContainsKey("expect_callbacks"))
                    {
                        var expectedCallbacks = operation["expect_callbacks"];

                        foreach (var expectedCallback in expectedCallbacks)
                        {
                            var expectedCallbackName = ToVariableName(expectedCallback.Key);
                            renderedSetValue.AppendLine($"A.CallTo(() => {expectedCallbackName}.Invoke(A<object>._, {expectedCallback.Value})).MustHaveHappenedOnceExactly();");
                            renderedSetValue.AppendLine($"Fake.ClearRecordedCalls({expectedCallbackName});");
                        }
                    }

                    return renderedSetValue.ToString();
                case "expect_cell_value":
                    return $"Assert.Equal({operation["value"]}, {ToVariableName(operation["cell"])}.Value);";
                case "add_callback":
                    var addCallbackName = ToVariableName(operation["name"]);
                    return Render.Variable(addCallbackName, "A.Fake<EventHandler<int>>()") + Environment.NewLine +
                           $"{ToVariableName(operation["cell"])}.Changed += {addCallbackName};";
                case "remove_callback":
                    var removeCallbackName = ToVariableName(operation["name"]);
                    return $"{ToVariableName(operation["cell"])}.Changed -= {removeCallbackName};";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static string RenderAssert() => string.Empty;

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(EventHandler).Namespace);
            namespaces.Add("FakeItEasy");
        }

        private static string ToVariableName(dynamic value) => ((string)value).ToVariableName();
    }
}