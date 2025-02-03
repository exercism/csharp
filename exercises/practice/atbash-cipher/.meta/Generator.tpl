using Xunit;

public class AtbashCipherTests
{
    {{for test in tests}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{test.shortMethodName}}()
    {
        Assert.Equal({{test.expected | string.literal}}, AtbashCipher.{{test.property | string.capitalize}}({{test.input.phrase | string.literal}}));
    }
    {{end}}
}
