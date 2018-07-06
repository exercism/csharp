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

            if (testMethod.Input.ContainsKey("set"))
            {
                if (testMethod.Input["set"] is JArray)
                {
                    testMethod.Input["set"] = new UnescapedValue("");
                }

                testMethod.SetConstructorInputParameters("set");
            }
            else
            {
                if (testMethod.Input["set1"] is JArray)
                {
                    testMethod.Input["set1"] = new UnescapedValue("");
                }

                testMethod.SetConstructorInputParameters("set1");
                testMethod.Input["set2"] = ConvertCustomSet(testMethod.Input["set2"]);

                if (testMethod.Property == "equal")
                {
                    testMethod.TestedMethod = "Equals";
                }
            }

            testMethod.Expected = ConvertCustomSet(testMethod.Expected);
        }

        private dynamic ConvertCustomSet(dynamic value)
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