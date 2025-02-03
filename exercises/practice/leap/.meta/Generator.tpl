using Xunit;

public class {{testClass}}
{
    {{for test in tests}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{test.testMethod}}()
    {
        Assert.{{test.expected ? "True" : "False"}}({{testedClass}}.{{test.testedMethod}}({{test.input}});
    }
}
