using System;
using System.Collections.Generic;
using System.Text;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class GradeSchool : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.UseVariableForExpected = true;
            testMethod.TestedMethodType = TestedMethodType.InstanceMethod;
            testMethod.InputParameters = testMethod.Input.ContainsKey("desiredGrade")
                ? new[] { "desiredGrade" }
                : Array.Empty<string>();

            testMethod.Arrange = RenderArrange(testMethod);
        }

        private string RenderArrange(TestMethod testMethod)
        {
            var arrange = new StringBuilder();

            arrange.AppendLine(Render.Variable("sut", "new GradeSchool()"));

            foreach (var student in testMethod.Input["students"])
                arrange.AppendLine($"sut.Add({Render.Object((string)student[0])}, {Render.Object(student[1])});");

            arrange.AppendLine(Render.Variable("expected", Render.ObjectMultiLine(testMethod.Expected as string[] ?? Array.Empty<string>())));
            
            return arrange.ToString();
        }

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Array).Namespace);
        }
    }
}