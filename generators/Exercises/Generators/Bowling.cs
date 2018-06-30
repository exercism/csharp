using System;
using System.Collections.Generic;
using System.Text;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

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

        private static string RenderAct(TestMethod method)
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
                act.AppendLine("var actual = sut.Score();");
                return act.ToString();
            }

            act.AppendLine("var actual = sut.Score();");
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