using Generators.Output;
using Humanizer;

namespace Generators.Exercises
{
    public class Yacht : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {   
            data.TestedClass = "YachtGame";
            var category = data.Input["category"].ToString();
            var formattedCategory = StringDehumanizeExtensions.Dehumanize(category);
            data.Input["category"] = new UnescapedValue($"YachtCategory.{formattedCategory}");
        }
    }
}
