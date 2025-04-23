{{ func lines(lines, variable) }}
    {{- if lines.empty? }}
    var {{variable}} = "";
    {{- else if (array.size lines) == 1 }}
    var {{variable}} = {{ lines[0] | string.literal }};
    {{- else }}
    var {{variable}} =
    {{- for line in lines }}
        {{ if for.last -}}
        {{ line | string.literal -}};
        {{- else -}}
        {{ line | string.append "\n" | string.literal }} +
        {{- end -}}
    {{- end }}
    {{- end -}}
{{ end }}

using System.Text;

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        {{- test.input.rows | lines "rows" }}
        {{- test.expected | lines "expected" }}
        Assert.Equal(expected, RunTally(rows));
    }
    {{ end }}
    private string RunTally(string input)
    {
        var encoding = new UTF8Encoding();
        using (var inStream = new MemoryStream(encoding.GetBytes(input)))
        using (var outStream = new MemoryStream())
        {
            Tournament.Tally(inStream, outStream);
            return encoding.GetString(outStream.ToArray());
        }
    }
}
