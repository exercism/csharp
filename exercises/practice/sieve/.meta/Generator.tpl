using Xunit;

public class SieveTests
{
    {{for test in tests}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{test.methodName}}()
    {
        int[] expected = {{test.expected}};
        Assert.Equal(expected, Sieve.Primes({{test.input.limit}}));
    }
    {{end}}
}
