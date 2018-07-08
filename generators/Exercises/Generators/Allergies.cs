using System.Text;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Allergies : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.ConstructorInputParameters = new[] { "score" };
            testMethod.TestedMethodType = TestedMethodType.InstanceMethod;

            if (testMethod.Property == "allergicTo")
                testMethod.Assert = RenderIsAllergicToAssert(testMethod);
            else if (testMethod.Property == "list")
                testMethod.UseVariableForExpected = true;
        }

        private string RenderIsAllergicToAssert(TestMethod testMethod)
        {
            var assert = new StringBuilder();

            foreach (var allergy in testMethod.Expected)
                assert.AppendLine(Render.AssertBoolean(allergy["result"], $"sut.IsAllergicTo({Render.Object(allergy["substance"])})"));

            return assert.ToString();
        }
    }
}