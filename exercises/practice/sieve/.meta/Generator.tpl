using Xunit;

public class SieveTests
{
    {{#test_cases}}
    [Fact{{#unless @first}}(Skip = "Remove this Skip property to run this test"){{/unless}}]
    public void {{method_name path}}()
    {
        Assert.Equal({{expected}}, Sieve.Primes({{input.limit}}));
    }
    {{/test_cases}}
}
