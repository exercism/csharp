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
            data.Input["direction"] = RenderDirection(data.Input["direction"]);
            data.Input["coordinate"] = RenderCreateCoordinate(data.Input["position"]);

            data.SetConstructorInputParameters("direction", "coordinate");

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
            var expected = (Dictionary<string, dynamic>)method.Data.Expected;
            expected.TryGetValue("position", out var position);
            expected.TryGetValue("direction", out var direction);

            var assert = new StringBuilder();

            if (direction != null)
            {
                var expectedDirection = RenderDirection(direction);
                assert.AppendLine(Render.AssertEqual(Render.Object(expectedDirection), "sut.Direction"));
            }

            if (position == null)
                return assert.ToString();

            var x = Render.Object(position["x"]);
            var y = Render.Object(position["y"]);
                
            assert.AppendLine(Render.AssertEqual(x, "sut.Coordinate.X"));
            assert.AppendLine(Render.AssertEqual(y, "sut.Coordinate.Y"));

            return assert.ToString();
        }

        private UnescapedValue RenderDirection(string direction)
            => Render.Enum("Direction", direction);

        private static UnescapedValue RenderCreateCoordinate(dynamic coordinates)
            => new UnescapedValue($"new Coordinate({coordinates["x"]}, {coordinates["y"]})");
    }
}
