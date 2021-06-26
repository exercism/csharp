using System;
using System.Collections.Generic;
using System.Text;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class Bowling : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            if (testMethod.Expected is int)
                testMethod.UseVariableForTested = true;
            else
                testMethod.ExceptionThrown = typeof(ArgumentException);

            testMethod.InputParameters = Array.Empty<string>();

            testMethod.Arrange = RenderArrange(testMethod);
            testMethod.Act = RenderAct(testMethod);
            testMethod.Assert = RenderAssert(testMethod);
        }

        private string RenderArrange(TestMethod testMethod)
        {
            var builder = new StringBuilder();
            builder.AppendLine(Render.Variable("sut", "new BowlingGame()"));

            if (!testMethod.Input.ContainsKey("previousRolls"))
                return builder.ToString();

            var previousRolls = testMethod.Input["previousRolls"] as int[] ?? Array.Empty<int>();
            builder.Append(Render.Variable("previousRolls", Render.ObjectMultiLine(previousRolls)));

            return builder.ToString();
        }

        private string RenderAssert(TestMethod testMethod)
        {
            if (testMethod.ExceptionThrown != null && testMethod.Input.ContainsKey("roll"))
            {
                var actual = Render.Object(testMethod.Input["roll"]);
                return Render.AssertThrows(testMethod.ExceptionThrown, $"sut.Roll({actual})");
            }

            if (testMethod.ExceptionThrown == null || testMethod.Property != "score")
                return testMethod.Assert;
            
            return Render.AssertThrows(testMethod.ExceptionThrown, "sut.Score()");
        }

        private string RenderAct(TestMethod testMethod)
        {
            var act = new StringBuilder();
            act.AppendLine("DoRoll(previousRolls, sut);");
            
            if (testMethod.ExceptionThrown != null)
            {
                return act.ToString();
            }

            if (testMethod.Input.ContainsKey("roll"))
            {
                act.AppendLine($"sut.Roll({testMethod.Input["roll"]});");
                act.AppendLine(Render.Variable("actual", "sut.Score()"));
                return act.ToString();
            }

            act.AppendLine(Render.Variable("actual", "sut.Score()"));
            return act.ToString();
        }

        protected override void UpdateTestClass(TestClass testClass) => AddDoRollMethod(testClass);

        private static void AddDoRollMethod(TestClass testClass) =>
            testClass.AdditionalMethods.Add(@"
private void DoRoll(IEnumerable<int> rolls, BowlingGame sut)
{
    foreach (var roll in rolls)
    {
        sut.Roll(roll);
    }
}");

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Array).Namespace);
            namespaces.Add(typeof(ICollection<>).Namespace);
        }
    }
}