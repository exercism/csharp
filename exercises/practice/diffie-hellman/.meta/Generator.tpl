{{ func toarg(argument)
    if (object.typeof argument) == "number"
        ret $"new BigInteger({argument})"
    end
    
    ret $"DiffieHellman.{string.capitalize argument}"
end }}

using System.Numerics;

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        {{- if test.property == "privateKeyIsInRange" }}
        var p = {{ 7919 | toarg }};
        var privateKeys = Enumerable.Range(0, 1000).Select(_ => {{ testedClass }}.PrivateKey(p));
        foreach (var privateKey in privateKeys)
        {
            Assert.InRange(privateKey, {{ 1 | toarg }}, p);
        }
        {{- else if test.property == "privateKeyIsRandom" }}
        var p = {{ 7919 | toarg }};
        var privateKeys = Enumerable.Range(0, 1000).Select(_ => DiffieHellman.PrivateKey(p)).ToArray();
        Assert.InRange(privateKeys.Distinct().Count(), privateKeys.Length - 100, privateKeys.Length);
        {{- else if test.property == "keyExchange" }}
        {{- for key in test.input | object.keys }}
        var {{key}} = {{ test.input[key] | toarg }};
        {{- end }}
        Assert.Equal(secretA, secretB);
        {{- else }}
        {{- for key in test.input | object.keys }}
        var {{key}} = {{ test.input[key] | toarg }};
        {{- end }}
        Assert.Equal({{ test.expected | toarg }}, {{ testedClass }}.{{ test.testedMethod }}({{ test.input | object.keys | array.join ", " }}));
        {{ end -}}
    }
    {{ end -}}
}
