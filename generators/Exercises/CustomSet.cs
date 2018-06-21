using Generators.Output;

namespace Generators.Exercises
{
    public class CustomSet : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.UseVariablesForInput = true;

            if (data.Input.ContainsKey("set"))
            {
                if (!(data.Input["set"] is int[]))
                {
                    data.Input["set"] = new UnescapedValue("");
                }

                data.SetConstructorInputParameters("set");
            }
            else
            {
                if (!(data.Input["set1"] is int[]))
                {
                    data.Input["set1"] = new UnescapedValue("");
                }

                data.SetConstructorInputParameters("set1");
                data.Input["set2"] = ConvertCustomSet(data.Input["set2"]);

                if (data.Property == "equal")
                {
                    data.Property = "Equals";
                }
            }

            data.Expected = ConvertCustomSet(data.Expected);
        }

        private static dynamic ConvertCustomSet(dynamic value)
        {
            switch (value)
            {
                case bool _:
                    return value;
                case int[] values when values.Length > 0:
                    return new UnescapedValue($"new CustomSet({ValueFormatter.Format(values)})");
                default:
                    return new UnescapedValue("new CustomSet()");
            }
        }
    }
}