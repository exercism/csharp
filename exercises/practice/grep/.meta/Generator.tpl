using System;
using System.IO;
using Xunit;

public class {{ testClass }} : IDisposable
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.shortTestMethod }}()
    {
        var pattern = {{ test.input.pattern | string.literal }};
        var flags = {{ test.input.flags | array.join " " | string.literal }};
        string[] files = {{ test.input.files }};
        {{- if test.expected.empty? }}
        var expected = "";
        {{- else }}
        var expected =
        {{- for line in test.expected }}
            {{ if for.last -}}
            {{ line | string.literal -}};
            {{- else -}}
            {{ line | string.append "\n" | string.literal }} +
            {{- end -}}
        {{- end -}}
        {{ end }}
        Assert.Equal(expected, {{ testedClass }}.Match(pattern, flags, files));
    }
    {{ end }}
    private const string IliadFileName = "iliad.txt";
    private const string IliadContents =
        "Achilles sing, O Goddess! Peleus' son;\n" +
        "His wrath pernicious, who ten thousand woes\n" +
        "Caused to Achaia's host, sent many a soul\n" +
        "Illustrious into Ades premature,\n" +
        "And Heroes gave (so stood the will of Jove)\n" +
        "To dogs and to all ravening fowls a prey,\n" +
        "When fierce dispute had separated once\n" +
        "The noble Chief Achilles from the son\n" +
        "Of Atreus, Agamemnon, King of men.\n";

    private const string MidsummerNightFileName = "midsummer-night.txt";
    private const string MidsummerNightContents =
        "I do entreat your grace to pardon me.\n" +
        "I know not by what power I am made bold,\n" +
        "Nor how it may concern my modesty,\n" +
        "In such a presence here to plead my thoughts;\n" +
        "But I beseech your grace that I may know\n" +
        "The worst that may befall me in this case,\n" +
        "If I refuse to wed Demetrius.\n";

    private const string ParadiseLostFileName = "paradise-lost.txt";
    private const string ParadiseLostContents =
        "Of Mans First Disobedience, and the Fruit\n" +
        "Of that Forbidden Tree, whose mortal tast\n" +
        "Brought Death into the World, and all our woe,\n" +
        "With loss of Eden, till one greater Man\n" +
        "Restore us, and regain the blissful Seat,\n" +
        "Sing Heav'nly Muse, that on the secret top\n" +
        "Of Oreb, or of Sinai, didst inspire\n" +
        "That Shepherd, who first taught the chosen Seed\n";

    public {{ testClass }}()
    {
        Directory.SetCurrentDirectory(Path.GetTempPath());
        File.WriteAllText(IliadFileName, IliadContents);
        File.WriteAllText(MidsummerNightFileName, MidsummerNightContents);
        File.WriteAllText(ParadiseLostFileName, ParadiseLostContents);
    }

    public void Dispose()
    {
        Directory.SetCurrentDirectory(Path.GetTempPath());
        File.Delete(IliadFileName);
        File.Delete(MidsummerNightFileName);
        File.Delete(ParadiseLostFileName);
    }
}
