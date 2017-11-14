using System.Collections.Generic;
using System.Linq;
using Generators.Input;
using Generators.Output;
using Humanizer;

namespace Generators.Exercises
{
    public class KindergartenGarden : GeneratorExercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.TestedMethodType = TestedMethodType.Instance;
                canonicalDataCase.UseFullDescriptionPath = true;

                if (canonicalDataCase.Properties.ContainsKey("students"))
                    canonicalDataCase.SetConstructorInputParameters("diagram", "students");
                else
                    canonicalDataCase.SetConstructorInputParameters("diagram");

                var plants = (IEnumerable<string>)canonicalDataCase.Properties["expected"];
                canonicalDataCase.Properties["expected"] = plants
                    .Select(x => new UnescapedValue($"Plant.{x.Humanize()}"))
                    .ToArray();
            }
        }
    }
}