using Xunit;

public class RotationalCipherTests
{
    {{for test in tests}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{test.methodName}}()
    {
        Assert.Equal({{test.expected | string.literal}}, RotationalCipher.Rotate({{test.input.text | string.literal}}, {{test.input.shiftKey}}));
    }
    {{end}}
}
