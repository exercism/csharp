using Xunit;

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        string[] playerA = { {{ test.input.playerA | array.each @string.literal | array.join ", " }} };
        string[] playerB = { {{ test.input.playerB | array.each @string.literal | array.join ", " }} };
        {{ testedClass }}.GameResult expected = new({{ testedClass }}.GameStatus.{{ test.expected.status | pascalize }}, {{ test.expected.tricks }}, {{ test.expected.cards }});
        Assert.Equal(expected, {{ testedClass }}.SimulateGame(playerA, playerB));
    }
    {{ end -}}
}
