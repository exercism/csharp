using System;
using System.Collections.Generic;
using Xunit;

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        var sut = new BowlingGame();
        {{- if !test.input.previousRolls.empty? }}
        int[] previousRolls = {{ test.input.previousRolls }};
        foreach (var roll in previousRolls)
        {
            sut.Roll(roll);
        }
        {{- end -}}
        {{- if test.expected.error }}
            Assert.Throws<ArgumentException>(() => sut.{{ test.testedMethod }}({{ test.input.roll }}));
        {{ else }}
            Assert.Equal({{ test.expected }}, sut.{{ test.testedMethod }}({{ test.input.roll }}));
        {{ end -}}
    }
    {{ end -}}
}
