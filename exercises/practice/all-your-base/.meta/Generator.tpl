using System;
using Xunit;

public class AllYourBaseTests
{
    {{for testCase in testCases}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{testCase.methodName}}()
    {
        {{if testCase.expected.error}}
        int[] digits = {{testCase.input.digits}};
        Assert.Throws<ArgumentException>(() => AllYourBase.Rebase({{testCase.input.inputBase}}, digits, {{testCase.input.outputBase}}));        
        {{else}}
        int[] digits = {{testCase.input.digits}};
        int[] expected = {{testCase.expected}};
        Assert.Equal(expected, AllYourBase.Rebase({{testCase.input.inputBase}}, digits, {{testCase.input.outputBase}}));
        {{end}}
    }
    {{end}}
}
