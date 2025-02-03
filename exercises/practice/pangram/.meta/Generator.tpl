using Xunit;

public class PangramTests
{
    {{for test in tests}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{test.methodName}}()
    {
        Assert.{{test.expected ? "True" : "False"}}(Pangram.IsPangram({{test.input.sentence | string.literal}}));
    }
    {{end}}
}
