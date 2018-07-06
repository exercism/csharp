using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Clock : GeneratorExercise
    {
        private const string ParamClock1 = "clock1";
        private const string ParamClock2 = "clock2";
        private const string ParamHour = "hour";
        private const string ParamMinute = "minute";

        private const string PropertyCreate = "create";
        private const string PropertyEqual = "equal";

        protected override void UpdateTestMethod(TestMethod testMethod)
        {   
            testMethod.SetConstructorInputParameters(ParamHour, ParamMinute);
            
            if (testMethod.Property == PropertyEqual)
            {
                var clock1 = testMethod.Input[ParamClock1];
                testMethod.Input[ParamClock1] = new UnescapedValue($"new Clock({clock1[ParamHour]}, {clock1[ParamMinute]})");
                
                var clock2 = testMethod.Input[ParamClock2];
                testMethod.Input[ParamHour] = clock2[ParamHour];
                testMethod.Input[ParamMinute] = clock2[ParamMinute];
            }

            if (testMethod.Property == PropertyCreate)
            {
                testMethod.TestedMethod = "ToString";
            }
            else if (testMethod.Property == PropertyEqual)
            {
                testMethod.TestedMethod = "Equals";
            }

            testMethod.Assert = RenderAssert(testMethod);
        }

        private string RenderAssert(TestMethod testMethod)
        {
            if (testMethod.Property == PropertyEqual)
            {
                return RenderEqualToAssert(testMethod);
            }

            return testMethod.Property == PropertyCreate
                ? testMethod.Assert
                : RenderConsistencyToAssert(testMethod);
        }

        private string RenderConsistencyToAssert(TestMethod testMethod) 
            => Render.AssertEqual(testMethod.ExpectedParameter, $"{testMethod.TestedValue}.ToString()");

        private string RenderEqualToAssert(TestMethod testMethod)
        {
            var expected = Render.Object(testMethod.Input[ParamClock1]);

            return testMethod.Expected 
                ? Render.AssertEqual(expected, "sut")
                : Render.AssertNotEqual(expected, "sut");
        }
    }
}