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

                if (canonicalDataCase.Input["startVerse"] == canonicalDataCase.Input["endVerse"])
                {
                    canonicalDataCase.SetInputParameters("startVerse");
                }
            }
        }
    }
}
