{{ func color 
    case $0
        when "X"
            ret "Black"
        when "O"
            ret "White"
        else
            ret "None"
        end
end }}

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        string[] board = [
        {{- for line in test.input.board }}
            {{ line | string.literal }}{{- if !for.last }},{{ end -}}
        {{ end }}
        ];
        var sut = new {{ testedClass }}(board);
        Assert.Equal({{ test.expected | color | enum "ConnectWinner" }}, sut.Result());
    }
    {{ end -}}
}
