using System;
using System.Collections.Generic;
using System.Text;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

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

        private string RenderAct(TestMethod method)
        {
            switch (method.Data.Property)
            {
                case "create": return null;
                case "instructions": return RenderInstructionsAct(method);
                default: return RenderDefaultAct(method);
            }
        }

        private static string RenderDefaultAct(TestMethod method) => $"sut.{method.Data.TestedMethod}();";

        private string RenderInstructionsAct(TestMethod method)
        {
            var actual = Render.Object(method.Data.Input["instructions"]);
            return $"sut.Simulate({actual});";
        }

        private string RenderAssert(TestMethod method)
        {
            var expected = method.Data.Expected as Dictionary<string, dynamic>;
            expected.TryGetValue("position", out var position);
            expected.TryGetValue("direction", out var direction);

            var assert = new StringBuilder();

            if (direction != null)
            {
                var expectedDirection = GetDirectionEnum(direction);
                assert.AppendLine(Render.AssertEqual(expectedDirection, "sut.Direction"));
            }   

            if (position != null)
            {
                var x = Render.Object(position["x"]);
                var y = Render.Object(position["y"]);
                
                assert.AppendLine(Render.AssertEqual(x, "sut.Coordinate.X"));
                assert.AppendLine(Render.AssertEqual(y, "sut.Coordinate.Y"));
            }
            
            return assert.ToString();
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
