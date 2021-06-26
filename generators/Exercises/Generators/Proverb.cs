using System;
using System.Collections.Generic;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class Proverb : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.UseVariablesForInput = true;
            testMethod.UseVariableForExpected = true;

            testMethod.Input["strings"] = RenderAsMultilineArray(testMethod.Input["strings"]);
            testMethod.Expected = RenderAsMultilineArray(testMethod.Expected);
        }
        
        private UnescapedValue RenderAsMultilineArray(dynamic value) 
            => new(Render.ArrayMultiLine(value as string[] ?? Array.Empty<string>()));

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Array).Namespace);
        }
    }
}