using System.Collections.Generic;
using Xunit;

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.shortTestMethod }}()
    {
        {{- if test.property == "ability" }}
        for (var i = 0; i < 10; i++)
        {
            Assert.InRange(DndCharacter.Ability(), 3, 18);
        }
        {{- else if test.property == "character" && (test.scenarios | array.contains "random") }}
        for (var i = 0; i < 10; i++)
        {
            var sut = DndCharacter.Generate();
            Assert.InRange(sut.Strength, 3, 18);
            Assert.InRange(sut.Dexterity, 3, 18);
            Assert.InRange(sut.Constitution, 3, 18);
            Assert.InRange(sut.Intelligence, 3, 18);
            Assert.InRange(sut.Wisdom, 3, 18);
            Assert.InRange(sut.Charisma, 3, 18);
            Assert.Equal(sut.Hitpoints, 10 + DndCharacter.Modifier(sut.Constitution));
        }
        {{- else if test.property == "character" }}
        for (var i = 0; i < 10; i++)
        {
            var sut = DndCharacter.Generate();
            Assert.Equal(sut.Strength, sut.Strength);
            Assert.Equal(sut.Dexterity, sut.Dexterity);
            Assert.Equal(sut.Constitution, sut.Constitution);
            Assert.Equal(sut.Intelligence, sut.Intelligence);
            Assert.Equal(sut.Wisdom, sut.Wisdom);
            Assert.Equal(sut.Charisma, sut.Charisma);
        }        
        {{ else }}
        Assert.Equal({{ test.expected }}, {{ testedClass }}.{{ test.testedMethod }}({{ test.input.score }}));
        {{ end -}}
    }
    {{ end }}
    [Fact(Skip = "Remove this Skip property to run this test")]
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
     
        var actualDistribution = new Dictionary<int, int>(expectedDistribution);
        foreach (var key in actualDistribution.Keys)
            actualDistribution[key] = 0;        
     
        const int times = 250;
        const int possibleCombinationsCount = 6*6*6*6; // 4d6
        for (var i = 0; i < times * possibleCombinationsCount; i++)
            actualDistribution[DndCharacter.Ability()]++;
     
        const double minTimes = times * 0.8;
        const double maxTimes = times * 1.2;
        foreach (var k in expectedDistribution.Keys)
            Assert.InRange(actualDistribution[k], expectedDistribution[k] * minTimes, expectedDistribution[k] * maxTimes);
    }
}
