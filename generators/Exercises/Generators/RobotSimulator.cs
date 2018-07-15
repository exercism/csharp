using System.Collections.Generic;
using System.Text;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    public class RobotSimulator : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.Input["direction"] = RenderDirection(testMethod.Input["direction"]);
            testMethod.Input["coordinate"] = RenderCreateCoordinate(testMethod.Input["position"]);

            testMethod.ConstructorInputParameters = new[] { "direction", "coordinate" };
            testMethod.TestedMethodType = TestedMethodType.InstanceMethod;
            testMethod.TestMethodName = testMethod.TestMethodNameWithPath;

            testMethod.Act = RenderAct(testMethod);
            testMethod.Assert = RenderAssert(testMethod);
        }

        private string RenderAct(TestMethod testMethod)
        {
            switch (testMethod.Property)
            {
                case "create": return null;
                case "instructions": return RenderInstructionsAct(testMethod);
                default: return RenderDefaultAct(testMethod);
            }
        }

        private static string RenderDefaultAct(TestMethod testMethod) => $"sut.{testMethod.TestedMethod}();";

        private string RenderInstructionsAct(TestMethod testMethod)
        {
            var actual = Render.Object(testMethod.Input["instructions"]);
            return $"sut.Simulate({actual});";
        }

        private string RenderAssert(TestMethod testMethod)
        {
            var expected = (Dictionary<string, dynamic>)testMethod.Expected;
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
