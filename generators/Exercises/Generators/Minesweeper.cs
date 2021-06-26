using System;
using System.Collections.Generic;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class Minesweeper : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.UseVariablesForInput = true;
            testMethod.UseVariableForExpected = true;

            testMethod.Input["minefield"] = RenderAsMultilineArray(testMethod.Input["minefield"]);
            testMethod.Expected = RenderAsMultilineArray(testMethod.Expected);
        }

        private UnescapedValue RenderAsMultilineArray(dynamic value) 
            => new UnescapedValue(Render.ArrayMultiLine(value as string[] ?? Array.Empty<string>()));

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Array).Namespace);
        }
    }
}
