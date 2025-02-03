using Xunit;

public class IsogramTests
{
    {{for test in tests}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{test.methodName}}()
    {
        Assert.{{test.expected ? "True" : "False"}}(Isogram.IsIsogram({{test.input.phrase | string.literal}}));
    }
    {{end}}
}
