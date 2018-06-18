using System;
using System.Text;
using Generators.Input;
using Generators.Output;
using System.Collections.Generic;

namespace Generators.Exercises
{
    public class Bowling : GeneratorExercise
    {
        private const string PreviousRolls = "previousRolls";

        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                if (!(canonicalDataCase.Expected is int))
                {
                    canonicalDataCase.ExceptionThrown = typeof(ArgumentException);
                }
                else
                {
                    canonicalDataCase.UseVariableForTested = true;

                }
                canonicalDataCase.SetInputParameters();
            }
        }

        protected override string RenderTestMethodBodyArrange(TestMethodBody testMethodBody)
        {
            var builder = new StringBuilder();
            builder.AppendLine("var sut = new BowlingGame();");

            if (testMethodBody.CanonicalDataCase.Input.ContainsKey(PreviousRolls))
            {
                var array = testMethodBody.CanonicalDataCase.Input[PreviousRolls] as int[];
                if (array == null)
                {
                    builder.Append("var previousRolls = Array.Empty<int>();");
                }
                else
                {
                    builder.Append("var previousRolls = new [] { ");
                    builder.AppendJoin(", ", array);
                    builder.AppendLine(" };");
                }
            }

            return builder.ToString();
        }

        protected override string RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            var template = string.Empty;
            if (testMethodBody.CanonicalDataCase.ExceptionThrown != null && testMethodBody.CanonicalDataCase.Input.ContainsKey("roll"))
            {
                template = "Assert.Throws<ArgumentException>(() => sut.Roll({{RollVal}}));";
                var templateParams = new
                {
                    RollVal = testMethodBody.CanonicalDataCase.Input["roll"]
                };
                return TemplateRenderer.RenderInline(template, templateParams);
            }
            else if (testMethodBody.CanonicalDataCase.ExceptionThrown != null && testMethodBody.CanonicalDataCase.Property == "score")
            {
                template = "Assert.Throws<ArgumentException>(() => sut.Score());";
                return template;
            }

            return base.RenderTestMethodBodyAssert(testMethodBody);
        }

        protected override string RenderTestMethodBodyAct(TestMethodBody testMethodBody)
        {
            var template =
@"DoRoll(previousRolls, sut);
";

            if (testMethodBody.CanonicalDataCase.ExceptionThrown != null)
            {
                return template;
            }

            if (testMethodBody.CanonicalDataCase.Input.ContainsKey("roll"))
            {
                template +=
@"sut.Roll({{RolVal}});
var actual = sut.Score();
";
                var templateParameters = new
                {
                    RolVal = testMethodBody.CanonicalDataCase.Input["roll"]
                };
                return TemplateRenderer.RenderInline(template, templateParameters);
            }

            template += "var actual = sut.Score();";
            return template;
        }

        protected override string[] RenderAdditionalMethods()
        {
            return new string[] {
@"
public void DoRoll(ICollection<int> rolls, BowlingGame sut)
{
    foreach (var roll in rolls)
    {
        sut.Roll(roll);
    }
}" };
        }

        protected override IEnumerable<string> AdditionalNamespaces => new[]
        {
            typeof(Array).Namespace,
            typeof(ICollection<>).Namespace
        };
    }
}