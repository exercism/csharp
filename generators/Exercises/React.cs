﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Generators.Output;
using Humanizer;
using Newtonsoft.Json.Linq;

namespace Generators.Exercises
{
    public class React : GeneratorExercise
    {
        protected override string RenderTestMethodBodyArrange(TestMethodBody testMethodBody)
        {
            var arrange = new StringBuilder();
            arrange.AppendLine("var sut = new Reactor();");

            var cells = RenderCells(testMethodBody.CanonicalDataCase.Input["cells"]);
            arrange.AppendLine(cells);

            var operations = RenderOperations(testMethodBody.CanonicalDataCase.Input["operations"]);
            arrange.AppendLine(operations);

            return arrange.ToString();
        }

        private static string RenderCells(dynamic cells)
        {
            if (cells.Length == 0)
            {
                return "";
            }

            var renderedCells = ((object[])cells).Select(RenderCell);
            return string.Join("\n", renderedCells);
        }

        private static string RenderCell(dynamic cell)
        {
            var cellType = (string)cell["type"];
            var cellName = ToVariableName(cell["name"]);

            switch (cellType)
            {
                case "input":
                    return $"var {cellName} = sut.CreateInputCell({cell["initial_value"]});";
                case "compute":
                    var inputs = string.Join(", ", ((string[])cell["inputs"]).Select(ToVariableName));
                    var computeFunction = RenderComputeFunction(cell["compute_function"]);
                    return $"var {cellName} = sut.CreateComputeCell(new[] {{ {inputs} }}, inputs => {computeFunction});";
                default:
                    throw new InvalidOperationException($"Unknown cell type: {cellType}");
            }
        }

        private static string RenderComputeFunction(dynamic computeFunction)
        {
            var match = Regex.Match((string)computeFunction, "if (.+) then (.+) else (.+)");

            if (match.Success)
            {
                return $"{match.Groups[1]} ? {match.Groups[2]} : {match.Groups[3]}";
            }

            return computeFunction;
        }

        private static string RenderOperations(dynamic operations)
        {
            if (operations.Length == 0)
            {
                return "";
            }

            var renderedOperations = ((object[])operations).Select(RenderOperation);
            return string.Join("\n", renderedOperations);
        }

        private static string RenderOperation(dynamic operation)
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
                    return $"var {addCallbackName} = A.Fake<EventHandler<int>>();\n" +
                           $"{ToVariableName(operation["cell"])}.Changed += {addCallbackName};";
                case "remove_callback":
                    var removeCallbackName = ToVariableName(operation["name"]);
                    return $"{ToVariableName(operation["cell"])}.Changed -= {removeCallbackName};";
                default:
                    return $"qweqwe";
            }
        }

        protected override string RenderTestMethodBodyAssert(TestMethodBody testMethodBody) => "";

        protected override HashSet<string> AddAdditionalNamespaces() => new HashSet<string>
        {
            typeof(EventHandler).Namespace,
            "FakeItEasy"
        };

        private static string ToVariableName(dynamic value) => ((string)value).Camelize();
    }
}