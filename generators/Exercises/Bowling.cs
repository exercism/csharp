using System;
using System.Text;
using Generators.Input;
using Generators.Output;
using System.Linq;
using System.Collections.Generic;

namespace Generators.Exercises
{
    public class Bowling : Exercise
    {
        private const String PreviousRolls = "previous_rolls";

        protected override string RenderTestMethodBodyArrange(TestMethodBody testMethodBody)
        {
            var builder = new StringBuilder();
            var testCase = testMethodBody.CanonicalDataCase.Properties.ToArray();
            for (int i = 0; i<testCase.Length; i++)
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

            builder.AppendLine("var sut = new BowlingGame();");

             return builder.ToString();
        }

        protected override string RenderTestMethodBodyAct(TestMethodBody testMethodBody)
        {
            return "DoRoll(previousRolls, sut);";
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

        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.ExceptionThrown = canonicalDataCase.Expected is long ? null : typeof(ArgumentException);
                canonicalDataCase.SetConstructorInputParameters();
                if (canonicalDataCase.Property == "roll")
                {
                    canonicalDataCase.SetInputParameters(canonicalDataCase.Property);
                }
                else
                {
                    canonicalDataCase.SetInputParameters();
                }
            }
        }

        protected override HashSet<string> AddAdditionalNamespaces()
        {
            return new HashSet<string> { typeof(ICollection<>).Namespace };
        }
    }
}
