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
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.UseVariableForExpected = true;
                canonicalDataCase.Expected = ConvertHelper.ToMultiLineString(canonicalDataCase.Expected);
                var properties = canonicalDataCase.Properties as Dictionary<string, object>;
                var input = properties["input"] as Dictionary<string, object>;
                if ((long)input["startVerse"] == (long)input["endVerse"])
                {
                    properties["input"] = input["startVerse"];
                }
                else if ((long)input["startVerse"] == 1 && (long)input["endVerse"] == 12)
                {
                    canonicalDataCase.Property = "sing";
                    properties["input"] = null;
                }
            }
        }
    }
}
