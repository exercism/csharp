using Generators.Output;
using System;
using System.Collections.Generic;
using System.Text;
using Generators.Input;
using System.Linq;

namespace Generators.Exercises
{
    public class Bowling : Exercise
    {
        private const String PreviousRolls = "previous_rolls";
        private const String Expected = "expected";

        protected override string RenderTestMethodBodyArrange(TestMethodBody testMethodBody)
        {
            var builder = new StringBuilder();
            var testCase = testMethodBody.CanonicalDataCase.Properties.ToArray();
            for (int i = 0; i < testCase.Length; i++)
            {
                var pair = testCase[i];
                if (pair.Key == PreviousRolls)
                {
                    int[] array = pair.Value;
                    builder.Append("var previousRolls = new int[] {");
                        builder.AppendJoin(", ", array);
                    builder.AppendLine("};");
                }
            }

            return builder.ToString();
        }

        protected override string RenderTestMethodBodyAct(TestMethodBody testMethodBody)
        {
            return
@"var sut = new BowlingGame();
foreach (var roll in previousRolls)
{
    sut.Roll(roll);
}";
        }

        protected override string RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            var sb = new StringBuilder();

            if (testMethodBody.CanonicalDataCase.Properties.Keys.Contains("roll"))
            {
                sb.AppendLine($"sut.Roll({testMethodBody.CanonicalDataCase.Properties["roll"]});");
            }

            sb.AppendLine(base.RenderTestMethodBodyAssert(testMethodBody));

            return sb.ToString();
        }

        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.SetConstructorInputParameters();
                canonicalDataCase.SetInputParameters();
                var testCase = canonicalDataCase.Properties.ToArray();
                for (int i = 0; i < testCase.Length; i++)
                {
                    var pair = testCase[i];
                    if (pair.Key == Expected)
                    {
                        if (pair.Value is Dictionary<string, object>)
                        {
                            canonicalDataCase.Expected = null;
                        }
                    }
                }

                if (canonicalDataCase.Property != "score")
                {
                    canonicalDataCase.Property = "score";
                }
            }
        }
    }
}
