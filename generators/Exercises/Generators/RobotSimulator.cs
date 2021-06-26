using System.Collections.Generic;
using System.Text;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class RobotSimulator : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.Input["direction"] = RenderDirection(testMethod.Input["direction"]);
            testMethod.Input["x"] = testMethod.Input["position"]["x"];
            testMethod.Input["y"] = testMethod.Input["position"]["y"];

            testMethod.ConstructorInputParameters = new[] { "direction", "x", "y" };
            testMethod.TestedMethodType = TestedMethodType.InstanceMethod;
            testMethod.TestMethodName = testMethod.TestMethodNameWithPath;

            testMethod.Act = RenderAct(testMethod);
            testMethod.Assert = RenderAssert(testMethod);
        }

        private string RenderAct(TestMethod testMethod)
            => testMethod.Property == "move" ? RenderMoveAct(testMethod) : null;

        private string RenderMoveAct(TestMethod testMethod)
        {
            var actual = Render.Object(testMethod.Input["instructions"]);
            return $"sut.{testMethod.TestedMethod}({actual});";
        }

        private string RenderAssert(TestMethod testMethod)
        {
            var expected = (Dictionary<string, dynamic>)testMethod.Expected;
            expected.TryGetValue("position", out var position);
            expected.TryGetValue("direction", out var direction);

            var assert = new StringBuilder();

            var expectedDirection = RenderDirection(direction);
            assert.AppendLine(Render.AssertEqual(Render.Object(expectedDirection), "sut.Direction"));

            var x = Render.Object(position["x"]);
            var y = Render.Object(position["y"]);

            assert.AppendLine(Render.AssertEqual(x, "sut.X"));
            assert.AppendLine(Render.AssertEqual(y, "sut.Y"));

            return assert.ToString();
        }

        private UnescapedValue RenderDirection(string direction)
            => Render.Enum("Direction", direction);
    }
}
