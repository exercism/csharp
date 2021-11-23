using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class GoCounting : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.UseVariablesForInput = true;
            testMethod.UseVariableForExpected = true;
            testMethod.UseVariablesForConstructorParameters = true;
            testMethod.UseVariableForTested = true;

            testMethod.Input["board"] = new MultiLineString(testMethod.Input["board"]);
            testMethod.ConstructorInputParameters = new[] { "board" };
            testMethod.TestedMethodType = TestedMethodType.InstanceMethod;

            if (testMethod.Property == "territory")
                UpdateTestMethodForTerritoryProperty(testMethod);
            else
                UpdateTestMethodForTerritoriesProperty(testMethod);
        }

        private void UpdateTestMethodForTerritoryProperty(TestMethod testMethod)
        {
            testMethod.Input["coordinate"] = (testMethod.Input["x"], testMethod.Input["y"]);
            testMethod.InputParameters = new[] {"coordinate"};

            if (testMethod.ExpectedIsError)
            {
                testMethod.ExceptionThrown = typeof(ArgumentException);
            }
            else
            {
                var owner = RenderOwner(testMethod.Expected!["owner"]!);
                var territory = RenderTerritory(testMethod.Expected["territory"]);
                testMethod.Expected = (owner, territory);
                testMethod.Assert = RenderTerritoryAssert();
            }
        }

        private void UpdateTestMethodForTerritoriesProperty(TestMethod testMethod)
        {
            var expected = new[]
            {
                "new Dictionary<Owner, HashSet<(int, int)>>",
                "{",
                $"    [Owner.Black] = {RenderTerritory(testMethod.Expected!["territoryBlack"])},",
                $"    [Owner.White] = {RenderTerritory(testMethod.Expected!["territoryWhite"])},",
                $"    [Owner.None] = {RenderTerritory(testMethod.Expected!["territoryNone"])}",
                "}"
            };

            testMethod.Expected = new UnescapedValue(string.Join(Environment.NewLine, expected));
            testMethod.Assert = RenderTerritoriesAssert();
        }

        private string RenderTerritoryAssert()
        {
            var assert = new StringBuilder();
            assert.AppendLine(Render.AssertEqual("expected.Item1", "actual.Item1"));
            assert.AppendLine(Render.AssertEqual("expected.Item2", "actual.Item2"));
            return assert.ToString();
        }

        private string RenderTerritoriesAssert()
        {
            var territoriesAssert = new StringBuilder();
            territoriesAssert.AppendLine(Render.AssertEqual("expected[Owner.Black]", "actual[Owner.Black]"));
            territoriesAssert.AppendLine(Render.AssertEqual("expected[Owner.White]", "actual[Owner.White]"));
            territoriesAssert.AppendLine(Render.AssertEqual("expected[Owner.None]", "actual[Owner.None]"));
            return territoriesAssert.ToString();
        }

        private UnescapedValue RenderOwner(dynamic owner) => Render.Enum("Owner", owner);

        private string RenderTerritory(dynamic territory)
            => Render.Object(((JArray)territory).Select(coordinate => (coordinate[0]!.ToObject<int>(), coordinate[1]!.ToObject<int>())).ToHashSet());

        protected override void UpdateNamespaces(ISet<string> namespaces) => namespaces.Add(typeof(Dictionary<int, int>).Namespace!);
    }
}