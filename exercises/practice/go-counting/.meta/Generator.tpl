using System;
using System.Collections.Generic;
using Xunit;

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        var board = 
        {{- for line in test.input.board }}
            {{ if for.last -}}
            {{ line | string.literal -}};
            {{- else -}}
            {{ line | string.append "\n" | string.literal }} +
            {{- end -}}
        {{- end }}
        var sut = new {{ testedClass }}(board);        
        {{- if test.expected.error }}
            var coordinate = ({{ test.input.x }}, {{ test.input.y }});
            Assert.Throws<ArgumentException>(() => sut.Territory(coordinate));
        {{- else if test.property == "territory" }}
            var coordinate = ({{ test.input.x }}, {{ test.input.y }});
            var (territoryOwner, territoryCoordinates) = sut.Territory(coordinate);
            var expectedOwner = {{ test.expected.owner | string.downcase | enum "Owner" }};
            var expectedCoordinates = new HashSet<(int, int)>{{ if test.expected.territory.empty? }}(){{ else }}{ {{ for territory in test.expected.territory }}({{ territory | array.join ", " }}){{ if !for.last }}, {{ end }}{{ end }} }{{ end }};
            Assert.Equal(expectedOwner, territoryOwner);
            Assert.Equal(expectedCoordinates, territoryCoordinates);
        {{- else if test.property == "territories" }}
            var actual = sut.Territories();
            var expected = new Dictionary<Owner, HashSet<(int, int)>>
            {
                [Owner.Black] = new HashSet<(int, int)>() { {{ for territory in test.expected.territoryBlack }}({{ territory | array.join ", " }}){{ if !for.last }}, {{ end }}{{ end }} },
                [Owner.White] = new HashSet<(int, int)>() { {{ for territory in test.expected.territoryWhite }}({{ territory | array.join ", " }}){{ if !for.last }}, {{ end }}{{ end }} },
                [Owner.None]  = new HashSet<(int, int)>() { {{ for territory in test.expected.territoryNone }}({{ territory | array.join ", " }}){{ if !for.last }}, {{ end }}{{ end }} }
            };
            Assert.Equal(expected[Owner.Black], actual[Owner.Black]);
            Assert.Equal(expected[Owner.White], actual[Owner.White]);
            Assert.Equal(expected[Owner.None], actual[Owner.None]);
        {{ end -}}
    }
    {{ end -}}
}
