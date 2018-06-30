using System.Text;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Allergies : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            if (data.Property == "allergicTo")
                data.TestedMethod = "IsAllergicTo";
            else if (data.Property == "list")
                data.UseVariableForExpected = true;

            data.SetConstructorInputParameters("score");
        }

        protected override void UpdateTestMethod(TestMethod method)
        {
            method.Assert = RenderAssert(method);
        }

        private static string RenderAssert(TestMethod method)
        {
            return method.Data.Property == "allergicTo"
                ? RenderIsAllergicToAssert(method)
                : method.Assert;
        }

        private static string RenderIsAllergicToAssert(TestMethod method)
        {
            var assert = new StringBuilder();

            foreach (var allergy in method.Data.Expected)
                assert.AppendLine(Render.Assert.Boolean(allergy["result"], $"sut.IsAllergicTo({Render.Object(allergy["substance"])})"));

            return assert.ToString();
        }
    }
}