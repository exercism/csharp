using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Exercises.Generators
{
    public class GoCounting : GeneratorExercise
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
            {
                testMethod.Input["coordinate"] = (testMethod.Input["x"], testMethod.Input["y"]);
                testMethod.InputParameters = new[] {"coordinate"};

                if (testMethod.Expected.ContainsKey("error"))
                {
                    testMethod.ExceptionThrown = typeof(ArgumentException);
                }
                else
                {
                    var owner = RenderOwner(testMethod.Expected["owner"]);
                    var territory = RenderTerritory(testMethod.Expected["territory"]);
                    testMethod.Expected = (owner, territory);
                }
            }
            else
            {
                var expected = new[]
                    {
                        "new Dictionary<Owner, (int, int)[]>",
                        "{",
                        $"    [Owner.Black] = {RenderTerritory(testMethod.Expected["territoryBlack"])},",
                        $"    [Owner.White] = {RenderTerritory(testMethod.Expected["territoryWhite"])},",
                        $"    [Owner.None] = {RenderTerritory(testMethod.Expected["territoryNone"])}",
                        "}"
                    };

                testMethod.Expected = new UnescapedValue(string.Join(Environment.NewLine, expected));
            }

            testMethod.Assert = RenderAssert(testMethod);
        }

        private string RenderAssert(TestMethod testMethod)
        {
            if (testMethod.ExceptionThrown != null)
            {
                return testMethod.Assert;
            }

            if (testMethod.Property == "territories")
            {
                var territoriesAssert = new StringBuilder();
                territoriesAssert.AppendLine(Render.AssertEqual("expected.Keys", "actual.Keys"));
                territoriesAssert.AppendLine(Render.AssertEqual("expected[Owner.Black]", "actual[Owner.Black]"));
                territoriesAssert.AppendLine(Render.AssertEqual("expected[Owner.White]", "actual[Owner.White]"));
                territoriesAssert.AppendLine(Render.AssertEqual("expected[Owner.None]", "actual[Owner.None]"));
                return territoriesAssert.ToString();
            }

            var assert = new StringBuilder();
            assert.AppendLine(Render.AssertEqual("expected.Item1", "actual.Item1"));
            assert.AppendLine(Render.AssertEqual("expected.Item2", "actual.Item2"));
            return assert.ToString();
        }

        private UnescapedValue RenderOwner(dynamic owner) => Render.Enum("Owner", owner);

        private string RenderTerritory(dynamic territory)
            => Render.Object(((JArray)territory).Select(coordinate => (coordinate[0].ToObject<int>(), coordinate[1].ToObject<int>())).ToArray());

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Dictionary<int, int>).Namespace);
        }
    }
}