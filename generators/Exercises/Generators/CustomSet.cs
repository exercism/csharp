using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Exercises.Generators
{
    public class CustomSet : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.UseVariablesForInput = true;

            if (data.Input.ContainsKey("set"))
            {
                if (data.Input["set"] is JArray)
                {
                    data.Input["set"] = new UnescapedValue("");
                }

                data.SetConstructorInputParameters("set");
            }
            else
            {
                if (data.Input["set1"] is JArray)
                {
                    data.Input["set1"] = new UnescapedValue("");
                }

                data.SetConstructorInputParameters("set1");
                data.Input["set2"] = ConvertCustomSet(data.Input["set2"]);

                if (data.Property == "equal")
                {
                    data.TestedMethod = "Equals";
                }
            }

            data.Expected = ConvertCustomSet(data.Expected);
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