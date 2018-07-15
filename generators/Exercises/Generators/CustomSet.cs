using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Exercises.Generators
{
    public class CustomSet : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.UseVariablesForInput = true;
            testMethod.TestedMethodType = TestedMethodType.InstanceMethod;
            testMethod.Expected = ConvertToCustomSet(testMethod.Expected);

            if (testMethod.Input.ContainsKey("set"))
                UpdateTestMethodForSingleSetProperty(testMethod);
            else
                UpdateTestMethodForMultipleSetsProperty(testMethod);
        }

        private static void UpdateTestMethodForSingleSetProperty(TestMethod testMethod)
        {
            if (testMethod.Input["set"] is JArray)
            {
                testMethod.Input["set"] = new UnescapedValue("");
            }

            testMethod.ConstructorInputParameters = new[] {"set"};
        }

        private void UpdateTestMethodForMultipleSetsProperty(TestMethod testMethod)
        {
            if (testMethod.Input["set1"] is JArray)
            {
                testMethod.Input["set1"] = new UnescapedValue("");
            }

            testMethod.ConstructorInputParameters = new[] {"set1"};
            testMethod.Input["set2"] = ConvertToCustomSet(testMethod.Input["set2"]);

            if (testMethod.Property == "equal")
            {
                testMethod.TestedMethod = "Equals";
            }
        }

        private dynamic ConvertToCustomSet(dynamic value)
        {
            switch (value)
            {
                case bool _:
                    return value;
                case int[] values when values.Length > 0:
                    return new UnescapedValue($"new CustomSet({Render.Object(values)})");
                default:
                    return new UnescapedValue("new CustomSet()");
            }
        }
    }
}