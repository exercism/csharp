{{func normalize_predicate
    normalized = string.replace $0 "fn(x) ->" "x => "
    normalized = string.replace normalized "starts_with(x, " "x.StartsWith("
    string.replace normalized  "contains(x, " "x.Contains("
end}}

{{func test_case_type
    if string.contains $0 "strings"
        ret "string[]"
    else if string.contains $0 "lists"
        ret "int[][]"
    else
        ret "int[]"
    end
end}}

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        {{ test.description | test_case_type }} expected = {{ test.expected }};
        {{ test.description | test_case_type }} input = {{ test.input.list }};
        Assert.Equal(expected, input.{{ test.testedMethod }}({{ test.input.predicate | normalize_predicate }}).ToArray());
    }
    {{ end -}}
}
