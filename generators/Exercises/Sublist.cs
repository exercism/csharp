using System;
using System.Collections.Generic;
using Generators.Input;
using Generators.Output;
using Humanizer;

namespace Generators.Exercises
{
    public class Sublist : GeneratorExercise
    {
        protected override HashSet<string> AddAdditionalNamespaces() => new HashSet<string>() { typeof(IList<int>).Namespace };

        private UnescapedValue InputValues(int[] list)
        {
            var template = (list != null) ? string.Join(", ", Array.ConvertAll<int, string>(list, (x) => { return $"{x}"; })) : "";
            return new UnescapedValue($"new List<int>() {{ {template} }}".Replace("  ", " "));
        }
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {              
                var input = canonicalDataCase.Properties["input"] as Dictionary<string, object>;
                input["listOne"] = InputValues(input["listOne"] as int[]);
                input["listTwo"] = InputValues(input["listTwo"] as int[]);

                canonicalDataCase.Property = "classify";
                canonicalDataCase.Properties["expected"] = new UnescapedValue($"SublistType.{(canonicalDataCase.Properties["expected"] as string).Dehumanize()}");
            }
        }
    }
}

