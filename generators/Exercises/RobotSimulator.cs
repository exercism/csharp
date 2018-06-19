using System;
using System.Collections.Generic;
using System.Text;
using Generators.Input;
using Generators.Output;

namespace Generators.Exercises
{
    public class RobotSimulator : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            const string direction = "direction";
            const string position = "position";
            const string coordinate = "coordinate";

            var positionVal = new UnescapedValue(GetCoordinateInstance(canonicalDataCase.Input[position]));
            var directionVal = new UnescapedValue(GetDirectionEnum(canonicalDataCase.Input[direction]));

            canonicalDataCase.Input[direction] = directionVal;
            canonicalDataCase.Input[coordinate] = positionVal;

            canonicalDataCase.SetConstructorInputParameters(direction, coordinate);

            canonicalDataCase.UseFullDescriptionPath = true;
        }

        protected override IEnumerable<string> RenderTestMethodBodyAct(TestMethodBody testMethodBody)
        {
            switch (testMethodBody.Data.CanonicalDataCase.Property)
            {
                case "create": return Array.Empty<string>();
                case "instructions": return RenderInstructionsMethodBodyAct(testMethodBody);
                default: return RenderDefaultMethodBodyAct(testMethodBody);
            }
        }

        private static IEnumerable<string> RenderDefaultMethodBodyAct(TestMethodBody testMethodBody)
        {
            const string template = @"sut.{{MethodInvocation}}();";

            var templateParameters = new
            {
                MethodInvocation = testMethodBody.Data.CanonicalDataCase.Property.ToTestedMethodName()
            };

            return new[] { TemplateRenderer.RenderInline(template, templateParameters) };
        }

        private static IEnumerable<string> RenderInstructionsMethodBodyAct(TestMethodBody testMethodBody)
        {
            const string template = @"sut.{{MethodInvocation}}(""{{Instructions}}"");";

            var templateParameters = new
            {
                MethodInvocation = "Simulate",
                Instructions = testMethodBody.Data.CanonicalDataCase.Input["instructions"]
            };

            return new[] { TemplateRenderer.RenderInline(template, templateParameters) };
        }

        protected override IEnumerable<string> RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            var expected = testMethodBody.Data.CanonicalDataCase.Expected as Dictionary<string, dynamic>;
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

            return new[] { TemplateRenderer.RenderInline(template.ToString(), templateParameters) };
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
