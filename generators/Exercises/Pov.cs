using System;
using System.Linq;
using System.Text;
using Generators.Input;
using Generators.Output;
using Humanizer;
using Newtonsoft.Json.Linq;

namespace Generators.Exercises
{
    public class Pov : GeneratorExercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.UseVariablesForInput = true;
                canonicalDataCase.UseVariableForExpected = true;
                canonicalDataCase.ExceptionThrown = canonicalDataCase.Expected is null ? typeof(ArgumentException) : null;

                canonicalDataCase.Input["tree"] = RenderTree(canonicalDataCase.Input["tree"]);

                if (canonicalDataCase.Property == "fromPov")
                {
                    canonicalDataCase.Expected = RenderTree(canonicalDataCase.Expected);
                }
            }
        }

        private static UnescapedValue RenderTree(dynamic tree)
        {
            if (tree == null)
            {
                return null;
            }

            var sb = new StringBuilder();

            var label = ValueFormatter.Format(tree["label"]);

            if (tree.ContainsKey("children"))
            {
                var children = string.Join(", ", ((object[])tree["children"]).Select(RenderTree));
                sb.Append($"new Tree({label}, {children})");
            }
            else
            {
                sb.Append($"new Tree({label})");
            }

            return new UnescapedValue(sb.ToString());
        }
    }
}