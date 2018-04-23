using System;
using System.Collections.Generic;
using System.Text;
using Generators.Input;
using Generators.Output;
using Humanizer;
using System.Linq;

namespace Generators.Exercises
{
    public class Sublist : GeneratorExercise
    {
        protected override HashSet<string> AddAdditionalNamespaces() => new HashSet<string>() { typeof(System.Collections.Generic.IList<int>).Namespace };

        private UnescapedValue inputValues(int[] list)
        {
            var template = (list != null) ? string.Join(", ", Array.ConvertAll<int, string>(list, (x) => { return $"{x}"; })) : "";
            return new UnescapedValue($"new List<int>() {{ {template} }}".Replace("  ", " "));
        }
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {              
                var input = canonicalDataCase.Properties["input"] as System.Collections.Generic.Dictionary<string, object>;
                input["listOne"] = inputValues(input["listOne"] as int[]);
                input["listTwo"] = inputValues(input["listTwo"] as int[]);

                canonicalDataCase.Property = "classify";
                canonicalDataCase.Properties["expected"] = new UnescapedValue($"SublistType.{(canonicalDataCase.Properties["expected"] as string).Dehumanize()}");
            }
        }
    }
}

