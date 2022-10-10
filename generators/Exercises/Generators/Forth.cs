using Exercism.CSharp.Output;
using System;
using System.Text;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class Forth : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.TestMethodName = testMethod.TestMethodNameWithPath;

            if (testMethod.ExpectedIsError)
            {
                testMethod.ExceptionThrown = testMethod.Expected!["error"] == "divide by zero" ? typeof(DivideByZeroException) : typeof(InvalidOperationException);
            }
            else
            {
                if (testMethod.Property == "evaluateBoth")
                {
                    testMethod.Assert = RenderEvaluateBothAssert(testMethod);
                }
                else
                {
                    testMethod.Expected = string.Join(" ", testMethod.Expected);    
                }
            }
        }

        private string RenderEvaluateBothAssert(TestMethod testMethod)
        {
            var instructionsFirst = Render.Object(testMethod.Input["instructionsFirst"]);
            var instructionsSecond = Render.Object(testMethod.Input["instructionsSecond"]);
            var expectedFirst = Render.String(string.Join(" ", testMethod.Expected![0]));
            var expectedSecond = Render.String(string.Join(" ", testMethod.Expected[1]));
            var assert = new StringBuilder();
            assert.AppendLine(Render.AssertEqual(expectedFirst, $"Forth.Evaluate({instructionsFirst})"));
            assert.AppendLine(Render.AssertEqual(expectedSecond, $"Forth.Evaluate({instructionsSecond})"));

            return assert.ToString();
        }
    }
}
