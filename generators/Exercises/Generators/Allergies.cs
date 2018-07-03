using System.Text;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Allergies : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            if (data.Property == "allergicTo")
                data.TestedMethod = $"Is{data.TestedMethod}";
            else if (data.Property == "list")
                data.UseVariableForExpected = true;

            data.SetConstructorInputParameters("score");
        }

        protected override void UpdateTestMethod(TestMethod method)
        {
            method.Assert = RenderAssert(method);
        }

        private string RenderAssert(TestMethod method) 
            => method.Data.Property == "allergicTo"
                ? RenderIsAllergicToAssert(method)
                : method.Assert;

        private string RenderIsAllergicToAssert(TestMethod method)
        {
            var assert = new StringBuilder();

            foreach (var allergy in method.Data.Expected)
                assert.AppendLine(Render.AssertBoolean(allergy["result"], $"sut.{method.Data.TestedMethod}({Render.Object(allergy["substance"])})"));

            return assert.ToString();
        }
    }
}