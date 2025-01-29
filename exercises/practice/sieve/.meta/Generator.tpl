using Xunit;

public class SieveTests
{
    {{#test_cases}}
    [Fact{{#unless @first}}(Skip = "Remove this Skip property to run this test"){{/unless}}]
    public void {{test_method_name}}()
    {
        int[] expected = [{{expected}}];
        Assert.Equal(expected, Sieve.Primes({{input.limit}}));
    }
    {{/test_cases}}
}
