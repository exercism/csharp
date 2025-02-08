{{ func to_tree
    children = ""

    for child in $0.children ?? []
        children = children + $", {to_tree child}"
    end

    ret $"new Tree(\"{$0.label}\"{children})"
end }}

using System;
using Xunit;

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.shortTestMethod }}()
    {
        var tree = {{ test.input.tree | to_tree }};
        {{- if test.property == "fromPov" }}
            {{- if test.expected }}
            var expected = {{ test.expected | to_tree }};
            Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}(tree, {{ test.input.from | string.literal }}));
            {{- else }}
            Assert.Throws<ArgumentException>(() => {{ testedClass }}.{{ test.testedMethod }}(tree, {{ test.input.from | string.literal }}));
            {{- end -}}
        {{- else }}
            {{- if test.expected }}
            string[] expected = {{ test.expected }};
            Assert.Equal(expected, Pov.PathTo({{ test.input.from | string.literal }}, {{ test.input.to | string.literal }}, tree));
            {{- else }}
            Assert.Throws<ArgumentException>(() => Pov.PathTo({{ test.input.from | string.literal }}, {{ test.input.to | string.literal }}, tree));
            {{- end -}}        
        {{- end }}
    }
    {{ end -}}
}
