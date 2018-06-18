using System.Collections.Generic;
using System.Linq;
using Generators.Input;
using Generators.Output;
using Humanizer;

namespace Generators.Exercises
{
    public class KindergartenGarden : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            canonicalDataCase.TestedMethodType = TestedMethodType.Instance;
            canonicalDataCase.UseFullDescriptionPath = true;

            if (canonicalDataCase.Input.ContainsKey("students"))
                canonicalDataCase.SetConstructorInputParameters("diagram", "students");
            else
                canonicalDataCase.SetConstructorInputParameters("diagram");

            var plants = (IEnumerable<string>)canonicalDataCase.Expected;
            canonicalDataCase.Expected = plants
                .Select(x => new UnescapedValue($"Plant.{x.Humanize()}"))
                .ToArray();
        }
    }
}