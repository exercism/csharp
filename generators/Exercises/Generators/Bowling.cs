using System;
using System.Collections.Generic;
using System.Text;
using Exercism.CSharp.Output;

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

        private string RenderArrange(TestMethod method)
        {
            var builder = new StringBuilder();
            builder.AppendLine(Render.Variable("sut", "new BowlingGame()"));

            if (!method.Data.Input.ContainsKey(PreviousRolls))
                return builder.ToString();

            var previousRolls = method.Data.Input[PreviousRolls] as int[] ?? Array.Empty<int>();
            builder.Append(Render.Variable("previousRolls", Render.ObjectMultiLine(previousRolls)));

            return builder.ToString();
        }

        private string RenderAssert(TestMethod method)
        {
            if (method.Data.ExceptionThrown != null && method.Data.Input.ContainsKey("roll"))
            {
                var actual = Render.Object(method.Data.Input["roll"]);
                return Render.AssertThrows(method.Data.ExceptionThrown, $"sut.Roll({actual})");
            }

            if (method.Data.ExceptionThrown == null ||
                method.Data.Property != "score")
                return method.Assert;
            
            return Render.AssertThrows(method.Data.ExceptionThrown, "sut.Score()");
        }

        private string RenderAct(TestMethod method)
        {
            var act = new StringBuilder();
            act.AppendLine("DoRoll(previousRolls, sut);");
            
            if (method.Data.ExceptionThrown != null)
            {
                return act.ToString();
            }

            if (method.Data.Input.ContainsKey("roll"))
            {
                act.AppendLine($"sut.Roll({method.Data.Input["roll"]});");
                act.AppendLine(Render.Variable("actual", "sut.Score()"));
                return act.ToString();
            }

            act.AppendLine(Render.Variable("actual", "sut.Score()"));
            return act.ToString();
        }

        protected override void UpdateTestClass(TestClass @class)
        {
            AddDoRollMethod(@class);
        }

        private static void AddDoRollMethod(TestClass @class)
        {
            @class.Methods.Add(@"
public void DoRoll(IEnumerable<int> rolls, BowlingGame sut)
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