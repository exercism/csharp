using System;
using System.Collections.Generic;
using System.Text;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    public class OcrNumbers : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.ExceptionThrown = data.Expected is int && data.Expected <= 0 ? typeof(ArgumentException) : null;
            data.Input["rows"] = ToDigitStringRepresentation(data.Input["rows"]);
            data.Expected = data.Expected.ToString();
            data.UseVariableForTested = true;
            data.UseVariablesForInput = true;
        }

        private UnescapedValue ToDigitStringRepresentation(string[] input)
        {
            var lines = new StringBuilder();
            lines.AppendLine();

            for (var i = 0; i < input.Length; i++)
            {
                lines.Append(Render.Object(input[i]).Indent());

                if (i < input.Length - 1)
                    lines.Append(" + \"\\n\" +\n");
            }

            return new UnescapedValue(lines.ToString());
        }

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Array).Namespace);
        }
    }
}
