using System.Collections.Generic;
using System.Linq;
using Generators.Input;
using Generators.Output;
using Humanizer;

namespace Generators.Exercises
{
    public class Sublist : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            canonicalDataCase.Input["listOne"] = InputValues(canonicalDataCase.Input["listOne"] as int[]);
            canonicalDataCase.Input["listTwo"] = InputValues(canonicalDataCase.Input["listTwo"] as int[]);

            canonicalDataCase.Property = "classify";
            canonicalDataCase.Expected = new UnescapedValue($"SublistType.{(canonicalDataCase.Expected as string).Dehumanize()}");
        }

        protected override IEnumerable<string> AdditionalNamespaces => new[] { typeof(IList<int>).Namespace };

        private static UnescapedValue InputValues(int[] list)
        {
            var template = list != null ? string.Join(", ", list.Select(x => x.ToString())) : "";
            return new UnescapedValue($"new List<int>() {{ {template} }}".Replace("  ", " "));
        }
    }
}

