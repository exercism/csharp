using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class Tournament : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.TestedMethod = "RunTally";
            testMethod.TestedMethodType = TestedMethodType.StaticMethod;
            testMethod.UseVariablesForInput = true;
            testMethod.UseVariableForExpected = true;
            testMethod.Input["rows"] = new MultiLineString(testMethod.Input["rows"]);
            testMethod.Expected = new MultiLineString(testMethod.Expected);

            testMethod.Assert = RenderAssert();
        }

        private string RenderAssert() => Render.AssertEqual("expected", "RunTally(rows)");

        protected override void UpdateTestClass(TestClass testClass)
        {
            AddRunTallyMethod(testClass);
        }

        private static void AddRunTallyMethod(TestClass testClass)
        {
            testClass.AdditionalMethods.Add(@"
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

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Array).Namespace);
            namespaces.Add(typeof(Stream).Namespace);
            namespaces.Add(typeof(UTF8Encoding).Namespace);
        }
    }
}
