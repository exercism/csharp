using System;
using System.Linq;
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
                testMethod.TestMethodName = testMethod.TestMethodNameWithPath;
                testMethod.TestedMethod = "IsAllergicTo";
                testMethod.Input["item"] = RenderAllergen(testMethod.Input["item"]);
            }
            else
            {
                testMethod.UseVariableForExpected = true;
                testMethod.Expected = ConvertExpected(testMethod.Expected);
            }
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