using Xunit;

public class ZebraPuzzleTests
{
    {{for test in tests}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{test.methodName}}()
    {
        Assert.Equal(Nationality.{{test.expected}}, {{test.property | enum "ZebraPuzzle"}}());
    }
    {{end}}
}
