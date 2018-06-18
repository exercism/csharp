using Generators.Input;
using Generators.Output;
using Humanizer;

namespace Generators.Exercises
{
    public class Yacht : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {   
            canonicalDataCase.Exercise = "yacht-game";
            var category = canonicalDataCase.Input["category"].ToString();
            var formattedCategory = StringDehumanizeExtensions.Dehumanize(category);
            canonicalDataCase.Input["category"] = new UnescapedValue($"YachtCategory.{formattedCategory}");
        }
    }
}
