using System;
using System.Linq;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Pov : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.UseVariablesForInput = true;
            testMethod.UseVariableForExpected = true;
            
            if (testMethod.Expected is null)
                testMethod.ExceptionThrown = typeof(ArgumentException);
            
            testMethod.Input["tree"] = RenderTree(testMethod.Input["tree"]);

            if (testMethod.Property == "fromPov")
            {
                testMethod.Expected = RenderTree(testMethod.Expected);
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