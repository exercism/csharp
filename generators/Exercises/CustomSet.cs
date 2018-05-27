using Generators.Input;
using Generators.Output;

namespace Generators.Exercises
{
    public class CustomSet : GeneratorExercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.UseVariablesForInput = true;

                if (canonicalDataCase.Input.ContainsKey("set"))
                {
                    if (!(canonicalDataCase.Input["set"] is int[]))
                    {
                        canonicalDataCase.Input["set"] = new UnescapedValue("");
                    }

                    canonicalDataCase.SetConstructorInputParameters("set");
                }
                else
                {
                    if (!(canonicalDataCase.Input["set1"] is int[]))
                    {
                        canonicalDataCase.Input["set1"] = new UnescapedValue("");
                    }

                    canonicalDataCase.SetConstructorInputParameters("set1");
                    canonicalDataCase.Input["set2"] = ConvertCustomSet(canonicalDataCase.Input["set2"]);

                    if (canonicalDataCase.Property == "equal")
                    {
                        canonicalDataCase.Property = "Equals";
                    }
                }

                canonicalDataCase.Expected = ConvertCustomSet(canonicalDataCase.Expected);
            }
        }

        private static dynamic ConvertCustomSet(dynamic value)
        {
            if (value is bool)
                return value;

            if (value is int[] values && values.Length > 0)
            {
                return new UnescapedValue($"new CustomSet({ValueFormatter.Format(values)})");
            }

            return new UnescapedValue($"new CustomSet()");
        }
    }
}