﻿using System;
using System.Linq;
using System.Text;
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
            data.ExceptionThrown = data.Expected is null ? typeof(ArgumentException) : null;

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

            var sb = new StringBuilder();

            var label = Render.Object(tree["label"]);

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