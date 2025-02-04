using Xunit;

public class {{testClass}}
{
    {{for test in tests}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{test.testMethod}}()
    {
        Assert.{{test.expected ? "True" : "False"}}({{testedClass}}.{{test.testedMethod}}([{{for pair in test.input.dominoes}}({{pair[0]}}, {{pair[1]}}){{if !for.last}}, {{end}}{{end}}]));
    }
    {{end}}
}
