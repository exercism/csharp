using System;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class SpaceAge : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.TestedMethod = $"On{testMethod.Input["planet"]}";
            testMethod.TestedMethodType = TestedMethodType.InstanceMethod;

            testMethod.InputParameters = Array.Empty<string>();
            testMethod.ConstructorInputParameters = new[] {"seconds"};
        }
    }
}