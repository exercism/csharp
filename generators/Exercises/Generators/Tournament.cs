using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Tournament : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.TestedMethod = "RunTally";
            data.TestedMethodType = TestedMethodType.Static;
            data.UseVariablesForInput = true;
            data.UseVariableForExpected = true;
            data.Input["rows"] = new MultiLineString(data.Input["rows"]);
            data.Expected = new MultiLineString(data.Expected);
        }

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Array).Namespace);
            namespaces.Add(typeof(Stream).Namespace);
            namespaces.Add(typeof(UTF8Encoding).Namespace);
        }

        protected override void UpdateTestMethod(TestMethod method)
        {
            method.Assert = RenderAssert();
        }

        private string RenderAssert() => Render.AssertEqual("expected", "RunTally(rows)");

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
