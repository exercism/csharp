using System;
using System.Collections.Generic;
using System.Text;
using Generators.Output;
using Generators.Output.Templates;

namespace Generators.Exercises
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
        
        protected override void UpdateTestMethodBody(TestMethodBody body)
        {
            body.Arrange = RenderTestMethodBodyArrange(body);
            body.Act = RenderTestMethodBodyAct(body);
            body.Assert = RenderTestMethodBodyAssert(body);
        }

        private static IEnumerable<string> RenderTestMethodBodyArrange(TestMethodBody testMethodBody)
        {
            var builder = new StringBuilder();
            builder.AppendLine("var sut = new BowlingGame();");

            if (!testMethodBody.Data.Input.ContainsKey(PreviousRolls))
                return new[] { builder.ToString() };

            if (testMethodBody.Data.Input[PreviousRolls] is int[] array)
            {
                builder.Append("var previousRolls = new [] { ");
                builder.AppendJoin(", ", array);
                builder.AppendLine(" };");
            }
            else
            {
                builder.Append("var previousRolls = Array.Empty<int>();");
            }

            return new[] { builder.ToString() };
        }

        private static IEnumerable<string> RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            if (testMethodBody.Data.ExceptionThrown != null && testMethodBody.Data.Input.ContainsKey("roll"))
            {
                const string template = "Assert.Throws<ArgumentException>(() => sut.Roll({{RollVal}}));";
                var templateParams = new
                {
                    RollVal = testMethodBody.Data.Input["roll"]
                };
                return new[] { TemplateRenderer.RenderInline(template, templateParams) };
            }

            if (testMethodBody.Data.ExceptionThrown == null ||
                testMethodBody.Data.Property != "score")
                return testMethodBody.Assert;

            const string throwTemplate = "Assert.Throws<ArgumentException>(() => sut.Score());";
            return new[] { throwTemplate };

        }

        private static IEnumerable<string> RenderTestMethodBodyAct(TestMethodBody testMethodBody)
        {
            var template =
    @"DoRoll(previousRolls, sut);
";

            if (testMethodBody.Data.ExceptionThrown != null)
            {
                return new[] { template };
            }

            if (testMethodBody.Data.Input.ContainsKey("roll"))
            {
                template +=
    @"sut.Roll({{RolVal}});
var actual = sut.Score();
";
                var templateParameters = new
                {
                    RolVal = testMethodBody.Data.Input["roll"]
                };
                return new[] { TemplateRenderer.RenderInline(template, templateParameters) };
            }

            template += "var actual = sut.Score();";
            return new[] { template };
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