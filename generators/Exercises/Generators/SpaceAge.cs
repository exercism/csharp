using System;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class SpaceAge : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.TestedMethodType = TestedMethodType.InstanceMethod;
            testMethod.ConstructorInputParameters = new[] { "seconds" };
            testMethod.Assert = RenderAssert(testMethod);
        }

        private string RenderAssert(TestMethod testMethod)
            => Render.AssertEqualWithin(Render.Object(testMethod.Expected), $"sut.On{testMethod.Input["planet"]}()", 2);
    }
}