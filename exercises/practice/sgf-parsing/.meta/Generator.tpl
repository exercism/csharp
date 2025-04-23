{{ func toproperty(name, vals) 
    inner = array.join (array.each vals @string.literal) ", "
    ret "[" + (string.literal name) + "] = new[] { " + inner + " }"
end }}

{{ func toproperties
    if $0.empty?
        ret "new Dictionary<string, string[]>()"
    end

    props = []

    for prop in (object.keys $0)
        props = array.add props (toproperty prop $0[prop])
    end

    ret "new Dictionary<string, string[]> { " + (array.join props ", ") + " }"

end }}

{{ func totree 
    children = array.join (array.each $0.children @totree) ", "
    props = toproperties $0.properties

    if children.empty?
        ret $"new SgfTree({props})"
    else
        ret $"new SgfTree({props}, {children})"
    end
end }}

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        var encoded = {{ test.input.encoded | string.literal }};
        {{- if test.expected.error }}
            Assert.Throws<ArgumentException>(() => SgfParser.ParseTree(encoded));
        {{ else }}
            var expected = {{ test.expected | totree }};
            AssertEqual(expected, SgfParser.ParseTree(encoded));
        {{ end -}}
    }
    {{ end }}
    private void AssertEqual(SgfTree expected, SgfTree actual)
    {
        Assert.Equal(expected.Data, actual.Data);
        Assert.Equal(expected.Children.Length, actual.Children.Length);
        for (var i = 0; i < expected.Children.Length; i++)
        {
            AssertEqual(expected.Children[i], actual.Children[i]);
        }
    }
}
