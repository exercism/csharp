using System.Text;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Allergies : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            if (testMethod.Property == "allergicTo")
                testMethod.TestedMethod = $"Is{testMethod.TestedMethod}";
            else if (testMethod.Property == "list")
                testMethod.UseVariableForExpected = true;

            testMethod.ConstructorInputParameters = new[] { "score" };
            testMethod.TestedMethodType = TestedMethodType.InstanceMethod;

            testMethod.Assert = RenderAssert(testMethod);
        }

        private string RenderAssert(TestMethod testMethod) 
            => testMethod.Property == "allergicTo"
                ? RenderIsAllergicToAssert(testMethod)
                : testMethod.Assert;

        private string RenderIsAllergicToAssert(TestMethod testMethod)
        {
            var assert = new StringBuilder();

            foreach (var allergy in testMethod.Expected)
                assert.AppendLine(Render.AssertBoolean(allergy["result"], $"sut.{testMethod.TestedMethod}({Render.Object(allergy["substance"])})"));

            return assert.ToString();
        }
    }
}