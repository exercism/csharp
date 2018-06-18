using System;
using System.Collections.Generic;
using Generators.Input;
using Generators.Output;
using Humanizer;

namespace Generators.Exercises
{
    public class Sublist : GeneratorExercise
    {
        protected override IEnumerable<string> AdditionalNamespaces => new[] { typeof(IList<int>).Namespace };

        private UnescapedValue InputValues(int[] list)
        {
            var template = (list != null) ? string.Join(", ", Array.ConvertAll<int, string>(list, (x) => { return $"{x}"; })) : "";
            return new UnescapedValue($"new List<int>() {{ {template} }}".Replace("  ", " "));
        }
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.Input["listOne"] = InputValues(canonicalDataCase.Input["listOne"] as int[]);
                canonicalDataCase.Input["listTwo"] = InputValues(canonicalDataCase.Input["listTwo"] as int[]);

                canonicalDataCase.Property = "classify";
                canonicalDataCase.Expected = new UnescapedValue($"SublistType.{(canonicalDataCase.Expected as string).Dehumanize()}");
            }
        }
    }
}

