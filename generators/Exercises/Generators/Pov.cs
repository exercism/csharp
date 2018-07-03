using System;
using System.Linq;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Pov : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.UseVariablesForInput = true;
            data.UseVariableForExpected = true;
            
            if (data.Expected is null)
                data.ExceptionThrown = typeof(ArgumentException);
            
            data.Input["tree"] = RenderTree(data.Input["tree"]);

            if (data.Property == "fromPov")
            {
                data.Expected = RenderTree(data.Expected);
            }
        }

        private UnescapedValue RenderTree(dynamic tree)
        {
            if (tree == null)
            {
                return null;
            }

            var label = Render.Object(tree["label"]);

            if (tree.ContainsKey("children"))
            {
                var children = string.Join(", ", ((object[])tree["children"]).Select(RenderTree));
                return new UnescapedValue($"new Tree({label}, {children})");
            }
            
            return new UnescapedValue($"new Tree({label})");
        }
    }
}