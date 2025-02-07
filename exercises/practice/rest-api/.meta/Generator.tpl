{{ func tojson 
    object.to_json $0 | string.replace ".0" "" | string.literal
end }}

using Xunit;

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.shortTestMethod }}()
    {
        var url = {{ test.input.url | string.literal }};
        {{- if test.input.payload }}
        var payload = {{ test.input.payload | tojson }};
        {{- end }}
        var database = {{ test.input.database.users | tojson }};
        var sut = new {{ testedClass }}(database);
        var actual = sut.{{ test.testedMethod }}(url{{ if test.input.payload }}, payload{{ end }});
        var expected = {{ test.expected.users ?? test.expected | tojson }};
        Assert.Equal(expected, actual);
    }
    {{ end -}}
}
