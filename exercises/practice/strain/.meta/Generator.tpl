using System.Collections.Generic;
using System.Linq;
using Xunit;

{{func normalize_predicate}}
   {{ $0 | string.replace "fn(x) ->" "x => " |
           string.replace "starts_with(x, " "x.StartsWith(" |
           string.replace "contains(x, " "x.Contains(" }}
{{end}}

{{func test_case_type}}
    {{if $0 | string.contains "strings"}}
        string[]
    {{else if $0 | string.contains "lists"}}    
        int[][]
    {{else}}
        int[]
    {{end}}
{{end}}

public class StrainTests
{
    {{for testCase in testCases}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{testCase.testMethodName}}()
    {
        {{testCase.description | test_case_type}} expected = {{testCase.expected}};
        {{testCase.description | test_case_type}} input = {{testCase.input.list}};
        Assert.Equal(expected, input.{{testCase.property | string.capitalize}}({{testCase.input.predicate | normalize_predicate}}).ToArray());
    }
    {{end}}
}
