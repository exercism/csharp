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

        protected override void UpdateTestClass(TestClass testClass)
        {
            AddTestMethodForDistribution(testClass);
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

        private static void AddTestMethodForDistribution(TestClass testClass)
        {
            testClass.AdditionalMethods.Add(@"
[Fact(Skip = ""Remove to run test"")]
public void Random_ability_is_distributed_correctly()
{
    var expectedDistribution = new Dictionary<int, int>
    {
        [3] = 1,        [4] = 4,
        [5] = 10,       [6] = 21,
        [7] = 38,       [8] = 62,
        [9] = 91,       [10] = 122,
        [11] = 148,     [12] = 167,
        [13] = 172,     [14] = 160,
        [15] = 131,     [16] = 94,
        [17] = 54,      [18] = 21
    };
    var actualDistribution = new Dictionary<int, int>();
    const int times = 100;
    const int possibleCombinationsCount = 6*6*6*6; // 4d6

    for (var i = 3; i <= 18; i++)
        actualDistribution[i] = 0;

    for (var i = 0; i < times * possibleCombinationsCount; i++)
    {
        var ability = DndCharacter.Ability();
        actualDistribution[ability]++;
    }

    int min(int expected) => (int)(expected * (times * 0.8));
    int max(int expected) => (int)(expected * (times * 1.2));

    foreach (var k in expectedDistribution.Keys)
        Assert.InRange(actualDistribution[k], min(expectedDistribution[k]), max(expectedDistribution[k]));
}");
        }

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Enumerable).Namespace);
            namespaces.Add(typeof(Dictionary<int, int>).Namespace);
        }
    }
}