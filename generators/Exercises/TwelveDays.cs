using System;
using System.Collections.Generic;
using System.Text;
using Generators.Input;
using Generators.Output;
using System.Linq;
using Humanizer;

namespace Generators.Exercises
{
    public class TwelveDays : GeneratorExercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            canonicalData.Exercise = "twelve-days-song";
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.UseVariableForExpected = true;
                var properties = canonicalDataCase.Properties as Dictionary<string, object>;
                var input = properties["input"] as Dictionary<string, object>;
                if ((long)input["startVerse"] == (long)input["endVerse"])
                {
                    canonicalDataCase.Property = "verse";
                    properties["input"] = input["startVerse"];
                }
                else canonicalDataCase.Property = "verses";
            }
        }

        protected override string RenderTestMethodBodyArrange(TestMethodBody testMethodBody)
        {
            string expectedValue = "";
            var properties = testMethodBody.CanonicalDataCase.Properties as Dictionary<string, object>;
            var expectedValues = properties["expected"] as string[];
            if (expectedValues.Length == 1)
            {
                expectedValue = $"\"{expectedValues[0]}\\n\"";
            }
            else
            {
                for (int i = 0; i < expectedValues.Length; i++)
                {
                    expectedValues[i] = $"\"{expectedValues[i]}\\n\\n\"" + (i < expectedValues.Length - 1? " +" : "");
                }
                expectedValue = expectedValues.Aggregate("", (x, y) => x + System.Environment.NewLine + new string(' ', 4) + y);
            }
            return $"var expected = {expectedValue};";
        }
    }
}
