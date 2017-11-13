using System;
using System.Linq;
using Generators.Input;
using Newtonsoft.Json.Linq;

namespace Generators.Exercises
{
    public class PascalsTriangle : GeneratorExercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            //remove null case until canonical data is updated
            var cases = canonicalData.Cases.ToList();
            cases.RemoveAll(x => x.Properties["count"] == null);
            canonicalData.Cases = cases.ToArray();

            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.UseVariableForExpected = true;
                canonicalDataCase.Property = "calculate";
                if (!(canonicalDataCase.Expected is JArray))
                    canonicalDataCase.ExceptionThrown = typeof(ArgumentOutOfRangeException);
                if (canonicalDataCase.Properties["count"] == null)
                    canonicalDataCase.Properties["count"] = -1;
            }
        }
    }
}