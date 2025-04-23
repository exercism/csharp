public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        string[] board = [
        {{- for row in test.input.board }}
            {{ row | string.literal }}{{- if !for.last }},{{ end -}}
        {{ end }}
        ];
        var game = new TicTacToe(board);
        {{- if test.expected.error }}
            Assert.Equal({{ "Invalid" | enum "State" }}, game.State);
        {{ else }}
            Assert.Equal({{ test.expected | enum "State" }}, game.State);
        {{ end -}}
    }
    {{ end -}}
}
