using System;
using Xunit;

public class AllYourBaseTests
{
    {{for test in tests}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{test.methodName}}()
    {
        {{if test.expected.error}}
        int[] digits = {{test.input.digits}};
        Assert.Throws<ArgumentException>(() => AllYourBase.Rebase({{test.input.inputBase}}, digits, {{test.input.outputBase}}));        
        {{else}}
        int[] digits = {{test.input.digits}};
        int[] expected = {{test.expected}};
        Assert.Equal(expected, AllYourBase.Rebase({{test.input.inputBase}}, digits, {{test.input.outputBase}}));
        {{end}}
    }
    {{end}}
}
