using Xunit;

public class SieveTests
{
    {{for testCase in testCases}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{testCase.methodName}}()
    {
        int[] expected = {{testCase.expected}};
        Assert.Equal(expected, Sieve.Primes({{testCase.input.limit}}));
    }
    {{end}}
}
