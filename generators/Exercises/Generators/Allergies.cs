using System;
using System.Linq;
using System.Text;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Allergies : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.ConstructorInputParameters = new[] { "score" };
            testMethod.TestedMethodType = TestedMethodType.InstanceMethod;

            if (testMethod.Property == "allergicTo")
            {
                testMethod.Assert = RenderIsAllergicToAssert(testMethod);
            }
            else if (testMethod.Property == "list")
            {
                testMethod.UseVariableForExpected = true;
                testMethod.Expected = ConvertExpected(testMethod.Expected);
            }
        }

        private string RenderIsAllergicToAssert(TestMethod testMethod)
        {
            var assert = new StringBuilder();

            foreach (var allergy in testMethod.Expected)
                assert.AppendLine(Render.AssertBoolean(allergy["result"], $"sut.IsAllergicTo({RenderAllergen(allergy["substance"])})"));

            return assert.ToString();
        }

        private UnescapedValue[] ConvertExpected(dynamic expected)
        {
            if (expected is string[] allergens)
                return allergens.Select(RenderAllergen).ToArray();

            return Array.Empty<UnescapedValue>();
        }

        private UnescapedValue RenderAllergen(dynamic input) => Render.Enum("Allergen", input);
    }
}