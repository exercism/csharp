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

        protected override void UpdateTestData(TestData data)
        {   
            data.SetConstructorInputParameters(ParamHour, ParamMinute);
            
            if (data.Property == PropertyEqual)
            {
                var clock1 = data.Input[ParamClock1];
                data.Input[ParamClock1] = new UnescapedValue($"new Clock({clock1[ParamHour]}, {clock1[ParamMinute]})");
                
                var clock2 = data.Input[ParamClock2];
                data.Input[ParamHour] = clock2[ParamHour];
                data.Input[ParamMinute] = clock2[ParamMinute];
            }

            if (data.Property == PropertyCreate)
            {
                data.TestedMethod = "ToString";
            }
            else if (data.Property == PropertyEqual)
            {
                data.TestedMethod = "Equals";
            }
        }

        protected override void UpdateTestMethod(TestMethod method)
        {
            method.Assert = RenderAssert(method);
        }

        private string RenderAssert(TestMethod method)
        {
            if (method.Data.Property == PropertyEqual)
            {
                return RenderEqualToAssert(method);
            }

            return method.Data.Property == PropertyCreate
                ? method.Assert
                : RenderConsistencyToAssert(method);
        }

        private string RenderConsistencyToAssert(TestMethod method) 
            => Render.AssertEqual(method.ExpectedParameter, $"{method.TestedValue}.ToString()");

        private string RenderEqualToAssert(TestMethod method)
        {
            var expected = Render.Object(method.Data.Input[ParamClock1]);

            return method.Data.Expected 
                ? Render.AssertEqual(expected, "sut")
                : Render.AssertNotEqual(expected, "sut");
        }
    }
}