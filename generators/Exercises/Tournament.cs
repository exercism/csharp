using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Generators.Input;
using Generators.Output;

namespace Generators.Exercises
{
    public class Tournament : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.TestedMethod = "RunTally";
            data.TestedMethodType = TestedMethodType.Static;
            data.UseVariablesForInput = true;
            data.UseVariableForExpected = true;
            data.Input["rows"] = ConvertHelper.ToMultiLineString(data.Input["rows"], "");
            data.Expected = ConvertHelper.ToMultiLineString(data.Expected);
        }
        
        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Array).Namespace);
            namespaces.Add(typeof(Stream).Namespace);
            namespaces.Add(typeof(UTF8Encoding).Namespace);
        }
        
        
        protected override void UpdateTestMethodBody(TestMethodBody body)
        {
            body.Assert = RenderTestMethodBodyAssert();
        }

        private static IEnumerable<string> RenderTestMethodBodyAssert()
        {
            const string template = @"Assert.Equal(expected, RunTally(rows));";
            return new[] { TemplateRenderer.RenderInline(template, new { }) };
        }

        protected override void UpdateTestClass(TestClass @class)
        {
            AddRunTallyMethod(@class);
        }

        private static void AddRunTallyMethod(TestClass @class)
        {
            @class.Methods.Add(@"
private string RunTally(string input)
{
    var encoding = new UTF8Encoding();

    using (var inStream = new MemoryStream(encoding.GetBytes(input)))
    using (var outStream = new MemoryStream())
    {
        Tournament.Tally(inStream, outStream);
        return encoding.GetString(outStream.ToArray());
    }
}");
        }
    }
}
