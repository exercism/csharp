using System.Collections.Generic;
using System.Linq;
using Generators.Output;
using Humanizer;

namespace Generators.Exercises
{
    public class KindergartenGarden : GeneratorExercise
    {
        protected override void UpdateTestMethodBodyData(TestMethodBodyData data)
        {
            data.TestedMethodType = TestedMethodType.Instance;
            data.UseFullDescriptionPath = true;

            if (data.Input.ContainsKey("students"))
                data.SetConstructorInputParameters("diagram", "students");
            else
                data.SetConstructorInputParameters("diagram");

            var plants = (IEnumerable<string>)data.Expected;
            data.Expected = plants
                .Select(x => new UnescapedValue($"Plant.{x.Humanize()}"))
                .ToArray();
        }
    }
}