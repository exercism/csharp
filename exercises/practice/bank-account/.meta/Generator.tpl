{{ func to_tested_method
    string.capitalize $0.operation
end }}

{{ func to_amount
    if $0.amount
        ret $"{$0.amount}m"
    end

    ret ""
end }}

{{ func to_call
    if $0.operation == "balance"
        ret "Balance"
    end

    ret $"{to_tested_method $0}({ to_amount $0 })"
end }}


using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public {{ if test.scenarios | array.contains "concurrent" }}async Task{{ else }}void{{ end }} {{ test.testMethod }}()
    {
        var account = new {{ testedClass }}();
        {{- for op in test.input.operations }}
            {{- if for.last }}
                {{- if test.expected.error }}
                    Assert.Throws<InvalidOperationException>(() => account.{{ op | to_call }});
                {{- else }}
                    Assert.Equal({{ test.expected }}m, account.{{ op | to_call }});
                {{ end -}}
            {{- else if op.operation == "concurrent" }}
            for (int i = 0; i < 500; i++)
            {
                var tasks = new List<Task>();
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < 100; j++)
                    {
                        {{- for nested_op in op.operations }}
                        account.{{ nested_op | to_call }};
                        {{- end -}}
                    }
                }));
                await Task.WhenAll(tasks.ToArray());
            }
            {{- else }}
            account.{{ op | to_call }};
            {{- end -}}
        {{ end -}}
    }
    {{ end -}}
}
