using System.Collections.Generic;
using System.Linq;
using Generators.Output;
using Humanizer;

namespace Generators.Exercises
{
    public class Sublist : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.Input["listOne"] = InputValues(data.Input["listOne"] as int[]);
            data.Input["listTwo"] = InputValues(data.Input["listTwo"] as int[]);

            data.TestedMethod = "Classify";
            data.Expected = new UnescapedValue($"SublistType.{(data.Expected as string).Dehumanize()}");
        }

        protected override IEnumerable<string> AdditionalNamespaces => new[] { typeof(IList<int>).Namespace };

        private static UnescapedValue InputValues(int[] list)
        {
            var template = list != null ? string.Join(", ", list.Select(x => x.ToString())) : "";
            return new UnescapedValue($"new List<int>() {{ {template} }}".Replace("  ", " "));
        }
    }
}

