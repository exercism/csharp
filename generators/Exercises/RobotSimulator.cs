using System;
using System.Collections.Generic;
using System.Text;
using Generators.Input;
using Generators.Output;

namespace Generators.Exercises
{
    public class RobotSimulator : GeneratorExercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            const string direction = "direction";
            const string position = "position";
            const string coordinate = "coordinate";

            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                var positionVal = new UnescapedValue(GetCoordinateInstance(canonicalDataCase.Input[position]));
                var directionVal = new UnescapedValue(GetDirectionEnum(canonicalDataCase.Input[direction]));

                canonicalDataCase.Input[direction] = directionVal;
                canonicalDataCase.Input[coordinate] = positionVal;

                canonicalDataCase.SetConstructorInputParameters(direction, coordinate);

                canonicalDataCase.UseFullDescriptionPath = true;
                canonicalDataCase.UseVariableForTested = true;
            }
        }

        protected override string RenderTestMethodBodyArrange(TestMethodBody testMethodBody)
        {
            ((testMethodBody.ArrangeTemplateParameters as dynamic).Variables as List<string>).RemoveAt(1);

            return base.RenderTestMethodBodyArrange(testMethodBody);
        }

        protected override string RenderTestMethodBodyAct(TestMethodBody testMethodBody)
        {
            switch (testMethodBody.CanonicalDataCase.Property)
            {
                case "create": return string.Empty;
                case "instructions": return RenderInstructionsMethodBodyAct(testMethodBody);
                default: return RenderDefaultMethodBodyAct(testMethodBody);
            }
        }

        private string RenderDefaultMethodBodyAct(TestMethodBody testMethodBody)
        {
            string template = @"sut.{{MethodInvocation}}();";

            var templateParameters = new
            {
                MethodInvocation = testMethodBody.CanonicalDataCase.Property.ToTestedMethodName()
            };

            return TemplateRenderer.RenderInline(template, templateParameters);
        }

        private string RenderInstructionsMethodBodyAct(TestMethodBody testMethodBody)
        {
            string template = @"sut.{{MethodInvocation}}(""{{Instructions}}"");";

            var templateParameters = new
            {
                MethodInvocation = "Simulate",
                Instructions = testMethodBody.CanonicalDataCase.Input["instructions"]
            };

            return TemplateRenderer.RenderInline(template, templateParameters);
        }

        protected override string RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            var expected = testMethodBody.CanonicalDataCase.Expected as Dictionary<string, dynamic>;
            expected.TryGetValue("position", out dynamic position);
            expected.TryGetValue("direction", out dynamic direction);

            StringBuilder template = new StringBuilder();

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

        private string GetDirectionEnum(string direction)
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

        private string GetCoordinateInstance(dynamic coordinates) => $"new Coordinate({coordinates["x"]}, {coordinates["y"]})";
    }
}
