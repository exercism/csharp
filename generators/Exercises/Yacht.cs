using System;
using Generators.Input;
using Generators.Output;
using Humanizer;

namespace Generators.Exercises
{
    public class Yacht : GeneratorExercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            canonicalData.Exercise = "yacht-game";
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                var category = canonicalDataCase.Input["category"].ToString();
                var formattedCategory = StringDehumanizeExtensions.Dehumanize(category);
                canonicalDataCase.Input["category"] = new UnescapedValue($"YachtCategory.{formattedCategory}");
            }
        }
    }
}
