using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exercism.CSharp.Helpers;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    public class DndCharacter : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.TestMethodName = testMethod.Description.Replace("-", "minus_").ToTestMethodName();

            if (testMethod.Property == "ability")
                UpdateTestMethodForAbilityProperty(testMethod);
            else if (testMethod.Property == "character")
                UpdateTestMethodForCharacterProperty(testMethod);
            else if (testMethod.Property == "strength")
                UpdateTestMethodForStrengthProperty(testMethod);
        }

        private void UpdateTestMethodForAbilityProperty(TestMethod testMethod)
            => testMethod.Assert = RenderAssertForAbilityProperty(testMethod);

        private string RenderAssertForAbilityProperty(TestMethod testMethod)
        {
            var assert = new StringBuilder();
            assert.AppendLine("for (var i = 0; i < 10; i++)");
            assert.AppendLine("{");
            assert.AppendLine(RenderAssertForAbilityRange($"{testMethod.TestedClass}.{testMethod.TestedMethod}()").Indent());
            assert.AppendLine("}");
            return assert.ToString();
        }

        private void UpdateTestMethodForCharacterProperty(TestMethod testMethod) 
            => testMethod.Assert = RenderAssertForCharacterProperty(testMethod);

        private string RenderAssertForCharacterProperty(TestMethod testMethod)
        {
            var assert = new StringBuilder();
            assert.AppendLine("for (var i = 0; i < 10; i++)");
            assert.AppendLine("{");
            assert.AppendLine(Render.Variable("sut", $"{testMethod.TestedClass}.Generate()").Indent());
            assert.AppendLine(RenderAssertForAbilityRange("sut.Strength").Indent());
            assert.AppendLine(RenderAssertForAbilityRange("sut.Dexterity").Indent());
            assert.AppendLine(RenderAssertForAbilityRange("sut.Constitution").Indent());
            assert.AppendLine(RenderAssertForAbilityRange("sut.Intelligence").Indent());
            assert.AppendLine(RenderAssertForAbilityRange("sut.Wisdom").Indent());
            assert.AppendLine(RenderAssertForAbilityRange("sut.Charisma").Indent());
            assert.AppendLine(Render.AssertEqual($"sut.Hitpoints", $"10 + {testMethod.TestedClass}.Modifier(sut.Constitution)").Indent());
            assert.AppendLine("}");
            return assert.ToString();
        }

        private string RenderAssertForAbilityRange(string ability) => Render.AssertInRange(ability, 3, 18);

        private void UpdateTestMethodForStrengthProperty(TestMethod testMethod)
            => testMethod.Assert = RenderAssertForStrengthProperty(testMethod);

        private string RenderAssertForStrengthProperty(TestMethod testMethod)
        {
            var assert = new StringBuilder();
            assert.AppendLine("for (var i = 0; i < 10; i++)");
            assert.AppendLine("{");
            assert.AppendLine(Render.Variable("sut", $"{testMethod.TestedClass}.Generate()").Indent());
            assert.AppendLine(Render.AssertEqual("sut.Strength", "sut.Strength").Indent());
            assert.AppendLine(Render.AssertEqual("sut.Dexterity", "sut.Dexterity").Indent());
            assert.AppendLine(Render.AssertEqual("sut.Constitution", "sut.Constitution").Indent());
            assert.AppendLine(Render.AssertEqual("sut.Intelligence", "sut.Intelligence").Indent());
            assert.AppendLine(Render.AssertEqual("sut.Wisdom", "sut.Wisdom").Indent());
            assert.AppendLine(Render.AssertEqual("sut.Charisma", "sut.Charisma").Indent());
            assert.AppendLine("}");
            return assert.ToString();
        }

        protected override void UpdateNamespaces(ISet<string> namespaces)
            => namespaces.Add(typeof(System.Linq.Enumerable).Namespace);
    }
}