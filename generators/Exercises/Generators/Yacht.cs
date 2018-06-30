using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;
using Humanizer;

namespace Exercism.CSharp.Exercises.Generators
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
