using System;
using System.Collections.Generic;
using Generators.Input;
using Generators.Output;

namespace Generators.Exercises
{
    public class Tournament : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            canonicalDataCase.Property = "RunTally";
            canonicalDataCase.TestedMethodType = TestedMethodType.Static;
            canonicalDataCase.UseVariablesForInput = true;
            canonicalDataCase.UseVariableForExpected = true;
            canonicalDataCase.Input["rows"] = ConvertHelper.ToMultiLineString(canonicalDataCase.Input["rows"], "");
            canonicalDataCase.Expected = ConvertHelper.ToMultiLineString(canonicalDataCase.Expected);
        }

        protected override IEnumerable<string> AdditionalNamespaces => new[]
        {
            typeof(Array).Namespace,
            typeof(System.IO.Stream).Namespace,
            typeof(System.Text.UTF8Encoding).Namespace
        };

        protected override IEnumerable<string> RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            string template = @"Assert.Equal(expected, RunTally(rows));";
            return new[] { TemplateRenderer.RenderInline(template, new { }) };
        }

        protected override IEnumerable<string> RenderAdditionalMethods()
        {
            var methods = @"
private string RunTally(string input)
{
    var encoding = new UTF8Encoding();

    using (var inStream = new MemoryStream(encoding.GetBytes(input)))
    using (var outStream = new MemoryStream())
    {
        Tournament.Tally(inStream, outStream);
        return encoding.GetString(outStream.ToArray());
    }
}";
            return methods.Split("", System.StringSplitOptions.None);
        }
    }
}
