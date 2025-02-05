using System;
using Xunit;

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.shortTestMethod }}()
    {
        {{- if test.property == "create" }}
            {{- if test.expected.error }}
                Assert.Throws<ArgumentOutOfRangeException>(() => {{ testedClass }}.{{ test.testedMethod }}({{ test.input.queen.position.row }}, {{ test.input.queen.position.column }}));
            {{ else }}
                var queen = {{ testedClass }}.{{ test.testedMethod }}({{ test.input.queen.position.row }}, {{ test.input.queen.position.column }});
            {{ end -}}
        {{- else }}
            var whiteQueen = {{ testedClass }}.Create({{ test.input.white_queen.position.row }}, {{ test.input.white_queen.position.column }});
            var blackQueen = {{ testedClass }}.Create({{ test.input.black_queen.position.row }}, {{ test.input.black_queen.position.column }});
            Assert.{{ test.expected ? "True" : "False" }}({{ testedClass }}.{{ test.testedMethod }}(whiteQueen, blackQueen));
        {{ end -}}
    }
    {{ end -}}
}
