using System;
using System.Text;
using Generators.Input;
using Generators.Output;
using System.Collections.Generic;

namespace Generators.Exercises
{
    public class Bowling : Exercise
    {
        private const string PreviousRolls = "previous_rolls";

        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                if(!(canonicalDataCase.Expected is long))
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

            if (testMethodBody.CanonicalDataCase.Properties.ContainsKey(PreviousRolls))
            {
                int[] array = testMethodBody.CanonicalDataCase.Properties[PreviousRolls];
                    builder.Append("var previousRolls = new int[] {");
                    builder.AppendJoin(", ", array);
                    builder.AppendLine("};");
            }

            return builder.ToString();
        }

        protected override string RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            var template = string.Empty;
            if(testMethodBody.CanonicalDataCase.ExceptionThrown != null && testMethodBody.CanonicalDataCase.Properties.ContainsKey("roll"))
            {
                template = "Assert.Throws<ArgumentException>(() => sut.Roll({{RollVal}}));";
                var templateParams = new
                {
                    RollVal = testMethodBody.CanonicalDataCase.Properties["roll"]
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

            if(testMethodBody.CanonicalDataCase.ExceptionThrown != null)
            {
                return template;
            }

            if (testMethodBody.CanonicalDataCase.Properties.ContainsKey("roll"))
            {
                template +=
@"sut.Roll({{RolVal}});
var actual = sut.Score();
";
                var templateParameters = new
                {
                    RolVal = testMethodBody.CanonicalDataCase.Properties["roll"]
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

        protected override HashSet<string> AddAdditionalNamespaces()
        {
            return new HashSet<string> { typeof(ICollection<>).Namespace };
        }
    }
}