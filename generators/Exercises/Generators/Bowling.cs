using System;
using System.Collections.Generic;
using System.Text;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Templates;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Bowling : GeneratorExercise
    {
        private const string PreviousRolls = "previousRolls";

        protected override void UpdateTestData(TestData data)
        {
            if (!(data.Expected is int))
            {
                data.ExceptionThrown = typeof(ArgumentException);
            }
            else
            {
                data.UseVariableForTested = true;
            }

            data.SetInputParameters();
        }

        protected override void UpdateTestMethod(TestMethod method)
        {
            method.Arrange = RenderArrange(method);
            method.Act = RenderAct(method);
            method.Assert = RenderAssert(method);
        }

        private static string RenderArrange(TestMethod method)
        {
            var builder = new StringBuilder();
            builder.AppendLine("var sut = new BowlingGame();");

            if (!method.Data.Input.ContainsKey(PreviousRolls))
                return builder.ToString();

            if (method.Data.Input[PreviousRolls] is int[] array)
            {
                builder.Append("var previousRolls = new [] { ");
                builder.AppendJoin(", ", array);
                builder.AppendLine(" };");
            }
            else
            {
                builder.Append("var previousRolls = Array.Empty<int>();");
            }

            return builder.ToString();
        }

        private static string RenderAssert(TestMethod method)
        {
            if (method.Data.ExceptionThrown != null && method.Data.Input.ContainsKey("roll"))
            {
                var actual = ValueFormatter.Format(method.Data.Input["roll"]);
                return Assertion.Throws(method.Data.ExceptionThrown, $"sut.Roll({actual})");
            }

            if (method.Data.ExceptionThrown == null ||
                method.Data.Property != "score")
                return method.Assert;
            
            return Assertion.Throws(method.Data.ExceptionThrown, "sut.Score()");
        }

        private static string RenderAct(TestMethod method)
        {
            var template =
    @"DoRoll(previousRolls, sut);
";

            if (method.Data.ExceptionThrown != null)
            {
                return template;
            }

            if (method.Data.Input.ContainsKey("roll"))
            {
                template +=
    @"sut.Roll({{RolVal}});
var actual = sut.Score();
";
                var templateParameters = new
                {
                    RolVal = method.Data.Input["roll"]
                };
                return TemplateRenderer.RenderInline(template, templateParameters);
            }

            template += "var actual = sut.Score();";
            return template;
        }

        protected override void UpdateTestClass(TestClass @class)
        {
            AddDoRollMethod(@class);
        }

        private static void AddDoRollMethod(TestClass @class)
        {
            @class.Methods.Add(@"
public void DoRoll(ICollection<int> rolls, BowlingGame sut)
{
    foreach (var roll in rolls)
    {
        sut.Roll(roll);
    }
}");
        }

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Array).Namespace);
            namespaces.Add(typeof(ICollection<>).Namespace);
        }
    }
}