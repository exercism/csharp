using System;
using System.Collections.Generic;
using System.Text;
using Exercism.CSharp.Helpers;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Templates;

namespace Exercism.CSharp.Exercises.Generators
{
    public class RobotSimulator : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            const string direction = "direction";
            const string position = "position";
            const string coordinate = "coordinate";

            var positionVal = new UnescapedValue(GetCoordinateInstance(data.Input[position]));
            var directionVal = new UnescapedValue(GetDirectionEnum(data.Input[direction]));

            data.Input[direction] = directionVal;
            data.Input[coordinate] = positionVal;

            data.SetConstructorInputParameters(direction, coordinate);

            data.UseFullDescriptionPath = true;
        }

        protected override void UpdateTestMethod(TestMethod method)
        {
            method.Act = RenderAct(method);
            method.Assert = RenderAssert(method);
        }

        private static string RenderAct(TestMethod method)
        {
            switch (method.Data.Property)
            {
                case "create": return null;
                case "instructions": return RenderInstructionsAct(method);
                default: return RenderDefaultAct(method);
            }
        }

        private static string RenderDefaultAct(TestMethod method)
        {
            const string template = @"sut.{{MethodInvocation}}();";

            var templateParameters = new
            {
                MethodInvocation = method.Data.Property.ToTestedMethodName()
            };

            return TemplateRenderer.RenderInline(template, templateParameters);
        }

        private static string RenderInstructionsAct(TestMethod method)
        {
            const string template = @"sut.{{MethodInvocation}}(""{{Instructions}}"");";

            var templateParameters = new
            {
                MethodInvocation = "Simulate",
                Instructions = method.Data.Input["instructions"]
            };

            return TemplateRenderer.RenderInline(template, templateParameters);
        }

        private static string RenderAssert(TestMethod method)
        {
            var expected = method.Data.Expected as Dictionary<string, dynamic>;
            expected.TryGetValue("position", out var position);
            expected.TryGetValue("direction", out var direction);

            var template = new StringBuilder();

            if (direction != null)
                template.AppendLine("Assert.Equal({{Direction}}, sut.Direction);");

            if (position != null)
            {
                template.AppendLine("Assert.Equal({{X}}, sut.Coordinate.X);");
                template.AppendLine("Assert.Equal({{Y}}, sut.Coordinate.Y);");
            }

            var templateParameters = new
            {
                Direction = !string.IsNullOrEmpty(direction) ? GetDirectionEnum(direction) : null,
                X = position?["x"],
                Y = position?["y"]
            };

            return TemplateRenderer.RenderInline(template.ToString(), templateParameters);
        }

        private static string GetDirectionEnum(string direction)
        {
            switch (direction)
            {
                case "north": return "Direction.North";
                case "east": return "Direction.East";
                case "south": return "Direction.South";
                case "west": return "Direction.West";

                default: throw new ArgumentException("Unrecognized 'Direction' enum value");
            }
        }

        private static string GetCoordinateInstance(dynamic coordinates) => $"new Coordinate({coordinates["x"]}, {coordinates["y"]})";
    }
}
