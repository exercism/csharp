using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class Clock : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.ConstructorInputParameters = new[] { "hour", "minute" };
            testMethod.TestedMethodType = TestedMethodType.InstanceMethod;

            if (testMethod.Property == "create")
                UpdateTestMethodForCreateProperty(testMethod);
            else if (testMethod.Property == "equal")
                UpdateTestMethodForEqualProperty(testMethod);
            else
                UpdateTestMethodForConsistencyProperty(testMethod);
        }

        protected override void UpdateTestClass(TestClass testClass)
        {
            testClass.AdditionalMethods.Add(@"[Fact(Skip = ""Remove this Skip property to run this test"")]
public void Clocks_are_immutable()
{
    var sut = new Clock(0, 0);
    var sutPlus1 = sut.Add(1);
    Assert.NotEqual(sutPlus1, sut);
}");
        }

        private static void UpdateTestMethodForCreateProperty(TestMethod testMethod)
        {
            testMethod.TestedMethod = "ToString";
        }

        private void UpdateTestMethodForEqualProperty(TestMethod testMethod)
        {
            var clock1 = testMethod.Input["clock1"];
            testMethod.Input["clock1"] = new UnescapedValue($"new Clock({clock1["hour"]}, {clock1["minute"]})");

            var clock2 = testMethod.Input["clock2"];
            testMethod.Input["hour"] = clock2["hour"];
            testMethod.Input["minute"] = clock2["minute"];

            testMethod.Assert = RenderEqualToAssert(testMethod);
        }

        private string RenderEqualToAssert(TestMethod testMethod)
        {
            var expected = Render.Object(testMethod.Input["clock1"]);

            return testMethod.Expected
                ? Render.AssertEqual(expected, "sut")
                : Render.AssertNotEqual(expected, "sut");
        }

        private void UpdateTestMethodForConsistencyProperty(TestMethod testMethod)
        {
            testMethod.Assert = RenderConsistencyToAssert(testMethod);
        }

        private string RenderConsistencyToAssert(TestMethod testMethod)
            => Render.AssertEqual(Render.Object(testMethod.Expected), $"sut.{testMethod.TestedMethod}({testMethod.Input["value"]}).ToString()");
    }
}