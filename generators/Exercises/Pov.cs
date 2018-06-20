using System;
using System.Linq;
using System.Text;
using Generators.Output;

namespace Generators.Exercises
{
    public class Pov : GeneratorExercise
    {
        protected override void UpdateTestMethodBodyData(TestMethodBodyData data)
        {
            data.UseVariablesForInput = true;
            data.UseVariableForExpected = true;
            data.ExceptionThrown = data.Expected is null ? typeof(ArgumentException) : null;

            data.Input["tree"] = RenderTree(data.Input["tree"]);

            if (data.Property == "fromPov")
            {
                data.Expected = RenderTree(data.Expected);
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