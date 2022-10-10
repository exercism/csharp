using System;
using System.Collections.Generic;
using System.Text;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class GradeSchool : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {   
            testMethod.TestedMethodType = TestedMethodType.InstanceMethod;
            testMethod.Act = RenderAct(testMethod);
            testMethod.InputParameters.Remove("students");
            
            if (testMethod.Property == "add")
                testMethod.Assert = "";
            else
                testMethod.UseVariableForExpected = true;
        }

        private string RenderAct(TestMethod testMethod)
        {
            var act = new StringBuilder();

            for (var i = 0; i < testMethod.Input["students"].Count; i++)
            {
                var student = testMethod.Input["students"][i];
                var add = $"sut.Add({Render.Object((string)student[0])}, {Render.Object(student[1])})";
                if (testMethod.Property == "add")
                    act.AppendLine(Render.AssertBoolean(testMethod.Expected![i], add));
                else
                    act.AppendLine($"{add};");
            }
            
            return act.ToString();
        }

        protected override void UpdateNamespaces(ISet<string> namespaces) => namespaces.Add(typeof(Array).Namespace!);
    }
}